using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyGame
{
    public class DragonHead : GameObject
    {

        private int direction;

        public int Direction => direction;

        private float timer;
        private float shootInterval = 1.9f;
        private DynamicPoolFB pool;

        public DragonHead(float positionX, float positionY, int direction) : base(positionX, positionY, 25, 25)
        {
            transform = new Transform(positionX, positionY, 10f, 10f);
            List<Image> images = new List<Image>();
            image = Engine.LoadImage("assets/DragonCanon.png");
            images.Add(image);

            pool = new DynamicPoolFB();

            currentAnimation = new Animation("canonIdle", images, 1f, false);

            this.direction = direction;
        }



        public override void Update()
        {
            timer += Time.DeltaTime;

            if (timer >= shootInterval)
            {
                ShootFireball();
                timer = 0;
            }
        }

        private void ShootFireball()
        {
            Fireball newFireball = pool.GetFireball(this);
            newFireball.Transform.SetPosition(transform.PosX, transform.PosY);
            GameManager.Instance.LevelController.GameObjectList.Add(newFireball);
        }

    }
}
