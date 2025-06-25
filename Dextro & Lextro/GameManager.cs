using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tao.Sdl;

namespace MyGame
{
    public enum GameState
    {
        Menu, Game, Win, Lose
    }

    public class GameManager
    {
        private List<string> levelNames = new List<string> { "Level0.json", "Level1.json", "Level2.json", "Level3.json", "Level4.json", "Level5.json" };
        private int currentLevelIndex = 0;

        private float portalsCoolDown = 0;
        public float PortalsCoolDown { get { return portalsCoolDown; } set { portalsCoolDown = value; } }
        private float timer = 30f;
        private LevelController levelController;
        public LevelController LevelController => levelController;
        public float Timer => timer;
        public string CurrentLevel => levelNames[currentLevelIndex];
        private GameState gameStage = GameState.Menu;
        private Image mainMenu = Engine.LoadImage("assets/MainMenu.png");
        private Image gameOver = Engine.LoadImage("assets/GameOver.png");
        private Image victory = Engine.LoadImage("assets/victory.png");
        private static GameManager instance;
        public static GameManager Instance { 
            get 
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }; 
                return instance;
            } 
        }
        public void Initialize()
        {
            levelController = new LevelController();
            levelController.InitializeLevel(CurrentLevel);
        }
        public void Update()
        {

            switch (gameStage)
            {
                case GameState.Menu:
                    if (Engine.GetKey(Engine.KEY_ESP))
                    {
                        ChangeGameStage(GameState.Game);
                    }
                    break;
                case GameState.Game: 
                    levelController.Update();
                    timer -= Time.DeltaTime;
                    if (timer <= 0)
                    {
                        ChangeGameStage(GameState.Lose);
                    }
                    if (Collision.IsBoxColliding(levelController.Player1.Transform, levelController.Player2.Transform))
                    {
                        LoadNextLevel();
                    }
                    break;
                case GameState.Win:
                    currentLevelIndex = 0;
                    if (Engine.GetKey(Engine.KEY_R))
                    {
                        ChangeGameStage(GameState.Menu);
                    }
                    break;
                case GameState.Lose:
                    if (Engine.GetKey(Engine.KEY_R))
                    {
                        RestartGame();
                    }
                    break;
            }
            float fps = 1.0f / Time.DeltaTime;
            //Console.WriteLine($"FPS: {fps}");
        }
        public void Render()
        {
            Engine.Clear();

            switch (gameStage)
            {
                case GameState.Menu:
                    Engine.Draw(mainMenu, 0, 0);
                    break;
                case GameState.Game:
                    levelController.Render();
                    break;
                case GameState.Win:
                    Engine.Draw(victory, 0, 0);
                    break;
                case GameState.Lose:
                    Engine.Draw(gameOver, 0, 0);
                    break;
            }
            Engine.Show();
        }

        public void ChangeGameStage(GameState gameStage)
        {
            this.gameStage = gameStage;
        }

        public void PortalHandler()
        {
            portalsCoolDown = 0;
        }

        public void LoadCurrentLevel()
        {
            levelController = new LevelController();
            levelController.InitializeLevel(CurrentLevel);
            timer = 30f;
        }

        public void LoadNextLevel()
        {
            currentLevelIndex++;

            if (currentLevelIndex >= levelNames.Count)
            {
                ChangeGameStage(GameState.Win);
            }
            else
            {
                LoadCurrentLevel();
            }
        }

        public void RestartGame()
        {
            timer = 30f;
            portalsCoolDown = 0;

            levelController.RestartLevel();
            ChangeGameStage(GameState.Game);
        }


    }
}
