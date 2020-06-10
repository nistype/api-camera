using Plus.Communication.Packets.Outgoing.Rooms.Camera;
using Plus.HabboHotel.GameClients;
 
namespace Plus.Communication.Packets.Incoming.Rooms.Camera
{
    public class RequestCameraConfigurationEvent : IPacketEvent
    {
        public void Parse(GameClient session, ClientPacket packet)
        {
            session.SendPacket(new CameraPriceComposer(1, 1, 0));
        }
    }
}
