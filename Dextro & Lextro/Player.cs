using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public enum PlayerType {Dextro, Lextro};
    
    public class Player : GameObject , IPlayeable
    {
        private PlayerController playerController;
        public Transform Transform 
        {
            get 
            {
                return transform;
            }
            set 
            {
                transform = value;
            }
        }


        public Player(float positionX, float positionY, PlayerType playerType) : base (positionX, positionY, 50,50) 
        {
            transform = new Transform(positionX, positionY, 50, 50);
            playerController = new PlayerController(Transform, playerType);



            List<Image> images = new List<Image>();

            if (playerType == PlayerType.Dextro)
            {
                for (int i = 1; i <= 6; i++)
                {
                    Image imagen = Engine.LoadImage($"assets/Player/Idle/PlayerDextro{i}.png");
                    images.Add(imagen);
                }
            }
            if (playerType == PlayerType.Lextro)
            {
                for (int i = 1; i <= 6; i++)
                {
                    Image imagen = Engine.LoadImage($"assets/Player/Idle/PlayerLextro{i}.png");
                    images.Add(imagen);
                }
            }

            currentAnimation = new Animation("MageIdle", images, 0.1f, true);
        }

        public override void Update()
        {

            playerController.Update();
            currentAnimation.Update();

        }

    }
        
}
