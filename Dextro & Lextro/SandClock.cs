using MyGame;
using System;
using System.Collections.Generic;

public class SandClock : GameObject
{
	public SandClock(float positionX, float positionY, float timer) : base(positionX, positionY, 100, 100)
    {

        transform = new Transform(positionX, positionY, 10f, 10f);
        List<Image> images = new List<Image>();
        for (int i = 1; i <= 28; i++)
        {
            image = Engine.LoadImage($"assets/SandClock/SandClock{i}.png");
            images.Add(image);
        }
        currentAnimation = new Animation("SandClockIdle", images, timer/30 , false);


    }

    public override void Update()
    {
        currentAnimation.Update();
    }
}
