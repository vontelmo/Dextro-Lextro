using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public enum FloorType { Small, Medium, Large, Wall };
    
    public class Floor : GameObject , IPlatform
    {

        public Floor(float positionX, float positionY, FloorType floorType) : base (positionX, positionY, 1, 1)
        {

            List<Image> images = new List<Image>();


            switch (floorType) 
            {
                case FloorType.Small:
                    transform = new Transform(positionX, positionY, 200, 50);
                    image = Engine.LoadImage("assets/Floor.png");
                    images.Add(image);
                    break;
                case FloorType.Medium:
                    transform = new Transform(positionX, positionY, 450, 50);
                    image = Engine.LoadImage("assets/FloorM.png");
                    images.Add(image);
                    break;
                case FloorType.Large:
                    transform = new Transform(positionX, positionY, 900, 50);
                    image = Engine.LoadImage("assets/FloorL.png");
                    images.Add(image);
                    break;
                case FloorType.Wall:
                    transform = new Transform(positionX, positionY, 50, 900);
                    image = Engine.LoadImage("assets/Wall.png");
                    images.Add(image);
                    break;
            }
            currentAnimation = new Animation("floorIdle", images, 1f, false);
        }

        public override void Update()
        {
            currentAnimation.Update();
        }

        public void Destroy()
        {
            GameManager.Instance.LevelController.GameObjectList.Remove(this);
        }
    }
}
