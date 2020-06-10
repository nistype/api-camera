using Plus.Communication.Packets.Outgoing.Rooms.Camera;
using Plus.HabboHotel.GameClients;
 
namespace Plus.Communication.Packets.Incoming.Rooms.Camera
{
    class CameraRoomThumbnailEvent : IPacketEvent
    {
        public void Parse(GameClient Session, ClientPacket Packet)
        {
            int count = Packet.PopInt();
            byte[] bytes = Packet.ReadBytes(count);
            PlusEnvironment.GetGame().GetCameraManager().RenderImage(bytes, true, Session.GetHabbo());
 
            Session.SendPacket(new CameraRoomThumbnailSavedComposer());
        }
    }
}
