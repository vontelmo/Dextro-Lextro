using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class DynamicPoolFB
    {
        private List<Fireball> fireballsInUse = new List<Fireball>();
        private List<Fireball> fireballsAvailable = new List<Fireball>();

        public Fireball GetFireball(DragonHead dragonHead ) 
        {

            Fireball newFireball = null;

            if (fireballsAvailable.Count > 0)
            {
                newFireball = fireballsAvailable[0];
                fireballsAvailable.RemoveAt(0);
            }
            else
            {
                newFireball = new Fireball(dragonHead.Transform.PosX, dragonHead.Transform.PosY, dragonHead.Direction);

                newFireball.OnFireballDeactivate += RecycleFB;
            }

            fireballsInUse.Add(newFireball);
            return newFireball;

        }

        public void RecycleFB(Fireball fireball) 
        {

            fireballsInUse.Remove(fireball);
            fireballsAvailable.Add(fireball);
        }
        
        public void PrintPool()
        {
            Engine.Debug("fbs en uso: " + fireballsInUse.Count);
            Engine.Debug("fbs disponibles: " + fireballsAvailable.Count);


        }

    }
}
