using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGame_REMAKE
{
    internal class Lists
    {
        public List<string> pyramid = new List<string>();
        public List<string> desert = new List<string>();
        public List<string> secret = new List<string>();
        public List<string> combat = new List<string>();
        public List<string> combatOcean = new List<string>();
        public List<string> endings = new List<string>();
        public Lists()
        {
            pyramid.Add("Hay");
            pyramid.Add("Iron bar");
            pyramid.Add("Bronze bar");
            pyramid.Add("Bricks");

            desert.Add("Rocks");
            desert.Add("Rope");
            desert.Add("Small chunks of wood");
            desert.Add("Glass");
            desert.Add("Cloth");

            secret.Add("ENERGYSWORD");
            secret.Add("HL");
            secret.Add("FSBERSERK");
            secret.Add("ZENITH");
            secret.Add("BLOODMOON");
            secret.Add("PLEB");
            secret.Add("TENSAZANGETSU");
            secret.Add("kamonevim");

            combat.Add("Snake");
            combat.Add("Scorpion");

            combatOcean.Add("Piranna");
            combatOcean.Add("Shark");
        }

    }
}
