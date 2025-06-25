using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class GameObject
    {
        protected Transform transform;
        protected Animation currentAnimation;
        protected Image image;

        public Transform Transform => transform;

        public GameObject(float positionX, float positionY, int scaleX, int scaleY)
        {
            transform = new Transform(positionX, positionY, scaleX, scaleY);
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentImage, transform.PosX, transform.PosY);
        }

        public abstract void Update();
    }
}
