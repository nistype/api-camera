using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Plus.Communication.Packets.Outgoing.Rooms.Camera
{
    class CameraPurchaseSuccesfullComposer : ServerPacket
    {
        public CameraPurchaseSuccesfullComposer() : base(ServerPacketHeader.CameraPurchaseSuccesfull)
        {
 
        }
    }
}
