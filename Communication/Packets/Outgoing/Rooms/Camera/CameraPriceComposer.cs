using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Communication.Packets.Outgoing.Rooms.Camera
{
    class CameraPriceComposer : ServerPacket
    {
        public CameraPriceComposer(int purchaseCreditCost, int purchaseDucketCost, int publishDucketCost)
            : base(ServerPacketHeader.CameraPrice)
        {
            base.WriteInteger(purchaseCreditCost);
            base.WriteInteger(purchaseDucketCost);
            base.WriteInteger(publishDucketCost);
        }
    }
}
