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
        public static List<string> secret = new List<string>();
        public static List<string> endings = new List<string>();
        public List<string> Foundcodes = new List<string>();
        public static List<string> pockets = new List<string>();
        #endregion
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

            secret.Add("energysword");
            secret.Add("hl");
            secret.Add("fsberserk");
            secret.Add("zenith");
            secret.Add("bloodmoon");
            secret.Add("noob");
            secret.Add("tensazangetsu");
            secret.Add("livinghell");

            combatDesert.Add("Snake");
            combatDesert.Add("Scorpion");

            combatOcean.Add("Piranna");
            combatOcean.Add("Shark");
        }
    }
}
