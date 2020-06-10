using CameraAPI;
using Plus.Communication.Packets.Outgoing.Inventory.Furni;
using Plus.Communication.Packets.Outgoing.Inventory.Purse;
using Plus.Communication.Packets.Outgoing.Rooms.Camera;
using Plus.Communication.Packets.Outgoing.Rooms.Notifications;
using Plus.Database.Interfaces;
using Plus.HabboHotel.GameClients;
using Plus.HabboHotel.Items;
using Plus.Utilities;
using System;

namespace Plus.Communication.Packets.Incoming.Rooms.Camera
{
    class CameraPurchaseEvent : IPacketEvent
    {
        public void Parse(GameClient Session, ClientPacket Packet)
        {
            String photoUrl = PlusEnvironment.GetGame().GetCameraManager().GetPhotoForHabbo(Session.GetHabbo());
            if (String.IsNullOrEmpty(photoUrl))
                return;

            if (Session.GetHabbo().Duckets < 1)
            {
                Session.SendPacket(new RoomNotificationComposer("camera", "errors", "${catalog.alert.notenough.activitypoints.description.0}"));
                return;
            }

            string roomId = photoUrl.Split('-')[0];
            string timestamp = photoUrl.Split('-')[1];

            int posterId = 777954881;
            Int32.TryParse(CameraUtils.Value("camera.poster.id"), out posterId);

            if (!PlusEnvironment.GetGame().GetItemManager().GetItem(posterId, out ItemData Item))
                return;
            if (Item == null)
                return;

            int photoId;
            using (IQueryAdapter dbClient = PlusEnvironment.GetDatabaseManager().GetQueryReactor())
            {
                dbClient.SetQuery("INSERT INTO `camera_photos` (creator_id, creator_name, file_name, reports, deleted, ip_address, created_at) VALUES (@uid,@name,@fileName,@reports,@deleted,@ip_address,@created_at)");
                dbClient.AddParameter("uid", Session.GetHabbo().Id);
                dbClient.AddParameter("name", Session.GetHabbo().Username);
                dbClient.AddParameter("fileName", photoUrl);
                dbClient.AddParameter("reports", 0);
                dbClient.AddParameter("deleted", "0");
                dbClient.AddParameter("ip_address", Session.GetConnection().GetIp());
                dbClient.AddParameter("created_at", timestamp);
                photoId = Convert.ToInt32(dbClient.InsertQuery());
            }

            Item photoPoster = ItemFactory.CreateSingleItemNullable(Item, Session.GetHabbo(), "{\"w\":\"" + StringCharFilter.EscapeJSONString(photoUrl) + "\", \"n\":\"" + StringCharFilter.EscapeJSONString(Session.GetHabbo().Username) + "\", \"s\":\"" + Session.GetHabbo().Id + "\", \"u\":\"" + photoId + "\", \"t\":\"" + timestamp + "\"}", "");

            if (photoPoster != null)
            {
                Session.GetHabbo().GetInventoryComponent().TryAddItem(photoPoster);

                Session.SendPacket(new FurniListAddComposer(photoPoster));
                Session.SendPacket(new FurniListUpdateComposer());
                Session.SendPacket(new FurniListNotificationComposer(photoPoster.Id, 1));
                Session.GetHabbo().Duckets--;
                Session.SendPacket(new HabboActivityPointNotificationComposer(Session.GetHabbo().Duckets, -1));

                PlusEnvironment.GetGame().GetAchievementManager().ProgressAchievement(Session, "ACH_CameraPhotoCount", 1);
            }

            Session.SendPacket(new CameraPurchaseSuccesfullComposer());

            Session.GetHabbo().GetInventoryComponent().UpdateItems(false);

           
        }
    }
}