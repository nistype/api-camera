using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Plus.Communication.Packets.Outgoing.Rooms.Camera
{
    class CameraURLComposer : ServerPacket
    {
        public CameraURLComposer(string imageURL) : base(ServerPacketHeader.CameraURL)
        {
            base.WriteString(imageURL);
        }
    }
}
