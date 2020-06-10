using Plus.Communication.Packets.Outgoing.Rooms.Camera;
using Plus.HabboHotel.GameClients;
 
namespace Plus.Communication.Packets.Incoming.Rooms.Camera
{
    public class CameraRoomPictureEvent : IPacketEvent
    {
        public void Parse(GameClient Session, ClientPacket Packet)
        {
            int count = Packet.PopInt();
            byte[] bytes = Packet.ReadBytes(count);
            PlusEnvironment.GetGame().GetCameraManager().RenderImage(bytes, false, Session.GetHabbo());
 
            Session.SendPacket(new CameraURLComposer(PlusEnvironment.GetGame().GetCameraManager().GetPhotoForHabbo(Session.GetHabbo()) + ".png"));
 
            Session.SendPacket(new CameraPriceComposer(1, 1, 0));
        }
    }
}
