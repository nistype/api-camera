using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Plus.Communication.Packets.Outgoing.Rooms.Camera
{
    class CameraRoomThumbnailSavedComposer : ServerPacket
    {
        public CameraRoomThumbnailSavedComposer() : base(ServerPacketHeader.CameraRoomThumbnailSaved)
        {
           
        }
    }
}
