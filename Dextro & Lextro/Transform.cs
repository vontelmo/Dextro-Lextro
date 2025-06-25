using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    

    public class Transform
    {

        private Vector2 position;

        public float PosX 
        {
            get { return position.x; }
            set { position.x = value; }

        }
        public float PosY
        {
            get { return position.y; }
            set { position.y = value; }
        }

        private Vector2 scale;
        public float ScaleX => scale.x;
        public float ScaleY => scale.y;

        public Transform(float positionX, float positionY, float scaleX, float scaleY)
        {
            position = new Vector2(positionX, positionY);
            scale = new Vector2(scaleX, scaleY);
        }

        public void Translate(float directionX, float directionY, float speed)
        {
            position.x += directionX * speed;
            position.y += directionY * speed;
        }

        public void SetPosition(float posX, float posY)
        {
            position.x = posX;
            position.y = posY;
        }

    }
    
}
