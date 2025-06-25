using System.Collections.Generic;

namespace MyGame
{
    public class LevelData
    {
        public List<PlayerData> players { get; set; }
        public List<FloorData> floors { get; set; }
        public List<PortalData> portals { get; set; }
        public List<DragonHeadData> dragonHeads { get; set; }
        public List<SandClockData> sandClocks { get; set; }
        public List<SpikesData> spikes { get; set; }

    }

    public class PlayerData
    {
        public float x { get; set; }
        public float y { get; set; }
        public string type { get; set; }
    }

    public class FloorData
    {
        public float x { get; set; }
        public float y { get; set; }
        public string type { get; set; } 
    }

    public class PortalData
    {
        public float x { get; set; }
        public float y { get; set; }
        public string type { get; set; }
        public int id { get; set; }
    }

    public class DragonHeadData
    {
        public float x { get; set; }
        public float y { get; set; }
        public int direction { get; set; }
    }

    public class SpikesData
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class SandClockData
    {
        public float x { get; set; }
        public float y { get; set; }
        public float timer { get; set; }
    }

}
