using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyGame
{
    public class Fireball : GameObject, IDamageable
    {
        public event Action<Fireball> OnFireballDeactivate;

        private float speed = 250;
        private float deltaSpeed;
        private int direction;
        public Fireball(float positionX, float positionY, int direction) : base(positionX, positionY, 10, 10)
        {
            transform = new Transform(positionX, positionY, 10f, 10f);

            List<Image> images = new List<Image>();
            image = Engine.LoadImage("assets/Fireball.png");
            images.Add(image);

            currentAnimation = new Animation("fireBallIdle", images, 1f, false);
            this.direction = direction;
        }

        public override void Update()
        {
            deltaSpeed = speed * Time.DeltaTime;

            if (direction == -1) { transform.Translate(-1, 0, deltaSpeed); }
            else if (direction == 1) { transform.Translate(1, 0, deltaSpeed); }
            else { return; }

            DeactivateFB();

        }

        public void DeactivateFB()
        {
            for (int i = 0; i < GameManager.Instance.LevelController.GameObjectList.Count; i++)
            {
                if (GameManager.Instance.LevelController.GameObjectList[i] is IPlatform floor)
                {
                    if (Collision.IsBoxColliding(transform, floor.Transform))
                    {
                        GameManager.Instance.LevelController.GameObjectList.Remove(this);
                        OnFireballDeactivate?.Invoke(this);
                    }
                }
            }
        }
    }
}

