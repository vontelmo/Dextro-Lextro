using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Animation
    {
        private string name;
        private List<Image> images;
        private float speedAnimation;
        private bool isLooping;

        private int currentFrame;
        private float currentTime;

        public Image CurrentImage => images[currentFrame];

        public Animation(string name, List<Image> images, float speedAnimation, bool isLooping)
        {
            this.name = name;
            this.images = images;
            this.speedAnimation = speedAnimation;
            this.isLooping = isLooping;
        }

        public void Update()
        {
            currentTime += Time.DeltaTime;

            if (currentTime > speedAnimation)
            {
                currentFrame++;
                currentTime = 0;

                if(currentFrame >= images.Count)
                {
                    if (isLooping) 
                    {
                        currentFrame = 0;
                    }
                    else
                    {
                        currentFrame--;
                    }
                }
            }
        }

    }
}
