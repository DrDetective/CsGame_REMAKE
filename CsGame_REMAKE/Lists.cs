using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGame_REMAKE
{
    internal class Lists
    {
        #region Desert
        public List<string> pyramidItems = new List<string>();
        public List<string> desertItems = new List<string>();
        public List<string> combatDesert = new List<string>();
        #endregion
        #region Ocean
        public List<string> combatOcean = new List<string>();
        #endregion
        #region Other
        public List<string> secret = new List<string>();
        public List<string> endings = new List<string>();
        public List<string> codes = new List<string>();
        public List<string> pockets = new List<string>();
        #endregion

        //public Dictionary<int, string> Betterpockets = new Dictionary<int, string>();
        //public static string[] pockets;
        public Lists()
        {
            pyramidItems.Add("Hay");
            pyramidItems.Add("Iron bar");
            pyramidItems.Add("Bronze bar");
            pyramidItems.Add("Bricks");

            desertItems.Add("Rocks");
            desertItems.Add("Rope");
            desertItems.Add("Small chunks of wood");
            desertItems.Add("Glass");
            desertItems.Add("Cloth");

            //secret.Add("ENERGYSWORD");
            //secret.Add("HL");
            //secret.Add("FSBERSERK");
            //secret.Add("ZENITH");
            //secret.Add("BLOODMOON");
            //secret.Add("PLEB");
            //secret.Add("TENSAZANGETSU");
            //secret.Add("kamonevim");

            combatDesert.Add("Snake");
            combatDesert.Add("Scorpion");

            combatOcean.Add("Piranna");
            combatOcean.Add("Shark");
        }
    }
}
