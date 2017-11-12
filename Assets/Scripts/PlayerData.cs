using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    [Serializable]
    public class PlayerData
    {
        public int Health;
        public int Experience;

        public PlayerData() { }

        public PlayerData(int h, int e)
        {
            Health = h;
            Experience = e;
        }
    }
}
