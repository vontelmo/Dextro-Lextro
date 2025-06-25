using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Spikes : GameObject, IDamageable
    {
        public Spikes(float positionX, float positionY) : base(positionX, positionY, 50, 10)
        {


            transform = new Transform(positionX, positionY, 10f, 10f);
            List<Image> images = new List<Image>();

            image = Engine.LoadImage("assets/Spikes.png");
            images.Add(image);

            currentAnimation = new Animation("SpikeIdle", images, 0f, false);



        }

        public override void Update()
        {
            currentAnimation.Update();
        }
    }
}
