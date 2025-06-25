using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class Collision
    {
        public static bool IsBoxColliding(Transform a, Transform b)
        {
            float distanceX = Math.Abs((a.PosX + a.ScaleX / 2) - (b.PosX + b.ScaleX / 2));
            float distanceY = Math.Abs((a.PosY + a.ScaleY / 2) - (b.PosY + b.ScaleY / 2));

            float sumHalfScaleXs = (a.ScaleX / 2) + (b.ScaleX / 2);
            float sumHalfScaleYs = (a.ScaleY / 2) + (b.ScaleY / 2);
            
            return distanceX <= sumHalfScaleXs && distanceY <= sumHalfScaleYs;
        }
    }
}
