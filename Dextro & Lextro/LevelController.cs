using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class LevelController
    {
        private Font font;
        private Image fondo = Engine.LoadImage("assets/background_2.0.png");
        private Player player1;
        private Player player2;

        private List<GameObject> gameObjectList = new List<GameObject>();
        public List<GameObject> GameObjectList => gameObjectList;

        public Player Player1 => player1;
        public Player Player2 => player2;

        public List<Portal> portalList = new List<Portal>();

        


        public void InitializeLevel(string levelName)
        {
            font = Engine.LoadFont("assets/Fonts/arial.ttf", 20);
            LevelData data = LevelLoader.LoadLevelFromJson(levelName);
            if (data.players != null)
            {
                foreach (var p in data.players)
                {
                    PlayerType type = (PlayerType)Enum.Parse(typeof(PlayerType), p.type);
                    var player = new Player(p.x, p.y, type);
                    gameObjectList.Add(player);
                    if (type == PlayerType.Dextro) player1 = player;
                    if (type == PlayerType.Lextro) player2 = player;
                }
            }
            if (data.floors != null)
            {
                foreach (var f in data.floors)
                {
                    FloorType type = (FloorType)Enum.Parse(typeof(FloorType), f.type);
                    var floor = FloorFactory.CreateFloor(f.x, f.y, type);
                    gameObjectList.Add(floor);
                }
            }
            if (data.portals != null)
            {
                foreach (var p in data.portals)
                {
                    PortalType type = (PortalType)Enum.Parse(typeof(PortalType), p.type);
                    var portal = new Portal(p.x, p.y, type, p.id);
                    gameObjectList.Add(portal);
                    portalList.Add(portal);
                }
            }
            if (data.dragonHeads != null)
            {
                foreach (var dh in data.dragonHeads)
                {
                    var dragonHead = new DragonHead(dh.x, dh.y, dh.direction);
                    gameObjectList.Add(dragonHead);
                }
            }
            if (data.sandClocks != null)
            {
                foreach (var sc in data.sandClocks)
                {
                    var sandClock = new SandClock(sc.x, sc.y, sc.timer);
                    gameObjectList.Add(sandClock);
                }
            }

            if (data.spikes != null)
            {
                foreach (var s in data.spikes)
                {
                    var spikes = new Spikes(s.x, s.y);
                    gameObjectList.Add(spikes);
                }
            }
        }

        public void RestartLevel()
        {
            gameObjectList.Clear();
            portalList.Clear();

            InitializeLevel(GameManager.Instance.CurrentLevel); 
        }


        public void Update()
        {

            for (int i = 0; i < gameObjectList.Count; i++)
            {
                gameObjectList[i].Update();
            }
            foreach (Portal portal in portalList) 
            {
                portal.OnTeleport += GameManager.Instance.PortalHandler;
            }

        }

        public void Render()
        {
            float TimerText = GameManager.Instance.Timer;
            Engine.Draw(fondo, 0, 0);
            Engine.DrawText(TimerText.ToString(), 50, 50, 255, 255, 255, font);

            for (int i = 0; i < gameObjectList.Count; i++)
            {
                gameObjectList[i].Render();
            }
        }


    }
}
