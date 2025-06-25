using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Time
    {
        static private float deltaTime;
        static private float timeLastFrame;
        static private DateTime initialTime;

        static public float DeltaTime => deltaTime;

        static public void Initialize()
        {
            initialTime = DateTime.Now;
        }
        static public void Update()
        {
            float currentTime = (float)(DateTime.Now - initialTime).TotalSeconds;
            deltaTime = currentTime - timeLastFrame;
            timeLastFrame = currentTime;
        }
    }
}
