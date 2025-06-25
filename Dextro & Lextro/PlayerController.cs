using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PlayerController
    {
        public Transform transform;
        private float speed = 250;
        private float deltaSpeed;
        private float timer;

        private float velocityY = 0;
        private float gravity;

        private PlayerType playerType;

        private bool onFloor;


        public PlayerController(Transform trans, PlayerType playerTypes)
        {
            transform = trans;
            playerType = playerTypes;

        }

        public void Update()
        {
            timer += Time.DeltaTime;

            onFloor = false;

            deltaSpeed = speed * Time.DeltaTime;
           
            VagueAntiCollitioner();


            switch (playerType)
            {
                case PlayerType.Lextro:
                    if (Engine.GetKey(Engine.KEY_LEFT))
                    {
                        transform.Translate(-1, 0, deltaSpeed);
                    }
                    if (Engine.GetKey(Engine.KEY_RIGHT))
                    {
                        transform.Translate(1, 0, deltaSpeed);
                    }
                    if (Engine.GetKey(Engine.KEY_UP))
                    {
                        Jump();
                    }
                    break;
                case PlayerType.Dextro:
                    if (Engine.GetKey(Engine.KEY_A))
                    {
                        transform.Translate(-1, 0, deltaSpeed);
                    }
                    if (Engine.GetKey(Engine.KEY_D))
                    {
                        transform.Translate(1, 0, deltaSpeed);
                    }
                    if (Engine.GetKey(Engine.KEY_W))
                    {
                        Jump();
                    }
                    break;
            }

            Gravity();

            //Engine.Debug(onFloor.ToString());

        }
        public void Gravity()
        {
            
            if (!onFloor)
            {
                gravity = 800;
                velocityY += gravity * Time.DeltaTime;
            }
            if (onFloor) 
            {
                gravity = 0; // resetea si está en el piso
            }

            transform.Translate(0, 1, velocityY * Time.DeltaTime);
        }



        public void VagueAntiCollitioner()
        {


            for (int i = 0; i < GameManager.Instance.LevelController.GameObjectList.Count; i++)
            {
                if (GameManager.Instance.LevelController.GameObjectList[i] is IDamageable damageable)
                {
                    if (!Collision.IsBoxColliding(transform, damageable.Transform)) continue;
                        
                    GameManager.Instance.ChangeGameStage(GameState.Lose);

                }

                if (GameManager.Instance.LevelController.GameObjectList[i] is IPlatform floor)
                {
                    if (!Collision.IsBoxColliding(transform, floor.Transform)) continue;

                    float playerCenterX = transform.PosX + transform.ScaleX / 2;
                    float playerCenterY = transform.PosY + transform.ScaleY / 2;

                    float floorCenterX = floor.Transform.PosX + floor.Transform.ScaleX / 2;
                    float floorCenterY = floor.Transform.PosY + floor.Transform.ScaleY / 2;

                    float deltaX = playerCenterX - floorCenterX;
                    float deltaY = playerCenterY - floorCenterY;

                    float intersectX = Math.Abs(deltaX) - (transform.ScaleX / 2 + floor.Transform.ScaleX / 2);
                    float intersectY = Math.Abs(deltaY) - (transform.ScaleY / 2 + floor.Transform.ScaleY / 2);

                    if (Math.Abs(intersectX) < Math.Abs(intersectY))
                    {
                        // Colisión lateral
                        if (deltaX > 0)
                        {
                            transform.PosX += -intersectX;
                        }
                        else
                        {
                            transform.PosX -= -intersectX;
                        }
                    }
                    else
                    {
                        // Colisión vertical
                        if (deltaY > 0)
                        {

                            transform.PosY += -intersectY;
                        }
                        else
                        {
                            transform.PosY -= -intersectY;
                            onFloor = true;
                        }
                    }
                }
            }

        }

        public void Jump()
        {
            float jumpCooldown = 0.5f;

            if (timer > jumpCooldown && onFloor)
            {
                velocityY = -495; // ajustá esta fuerza de salto
                timer = 0;
            }
        }




    }
}