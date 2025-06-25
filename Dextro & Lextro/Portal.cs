using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyGame
{
    
    public enum PortalType { Orange, Blue };
    public class Portal : GameObject , IInteraction
    {

        private int portalId;
        private float teleportCooldown = 5f;
        private PortalType portalType;
        public event Action OnTeleport;

        public Portal(float positionX, float positionY, PortalType portalType, int ID) : base(positionX, positionY, 1, 1)
        {
            transform = new Transform(positionX, positionY, 50, 50);
            this.portalId = ID;
;
            this.portalType = portalType;

            List<Image> images = new List<Image>();

            switch (portalType)
            {
                case PortalType.Orange:
                    transform = new Transform(positionX, positionY, 25, 50);
                    image = Engine.LoadImage("assets/Portal1.png");
                    images.Add(image);
                    break;
                case PortalType.Blue:
                    transform = new Transform(positionX, positionY, 25, 50);
                    image = Engine.LoadImage("assets/Portal2.png");
                    images.Add(image);
                    break;
            }
            currentAnimation = new Animation("floorIdle", images, 1f, false);
        }


        public void Teleport()
        {
            if (GameManager.Instance.PortalsCoolDown < teleportCooldown) return;

            for (int i = 0; i < GameManager.Instance.LevelController.GameObjectList.Count; i++)
            {

                if (GameManager.Instance.LevelController.GameObjectList[i] is IPlayeable player)
                {
                    if (Collision.IsBoxColliding(transform, player.Transform))
                    {

                        Portal targetPortal = GameManager.Instance.LevelController.portalList.FirstOrDefault(p => p.portalId == this.portalId && p.portalType != this.portalType && p != this);

                        if (targetPortal != null)
                        {

                            player.Transform.PosX = targetPortal.transform.PosX + targetPortal.transform.ScaleX / 2 - player.Transform.ScaleX / 2;
                            player.Transform.PosY = targetPortal.transform.PosY + targetPortal.transform.ScaleY / 2 - player.Transform.ScaleY / 2;

                            OnTeleport?.Invoke();
                        }
                    }
                }
            }
        }


        public override void Update()
        {
            GameManager.Instance.PortalsCoolDown += Time.DeltaTime;

            Teleport();
        }
    }
}
