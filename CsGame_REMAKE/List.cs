using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsGame_REMAKE
{
    internal class List
    {
        public List<string> pyramid = new List<string>();
        public List<string> desert = new List<string>();
        public List<string> secret = new List<string>();
        public List<string> combat = new List<string>();
        public void itemsPyramid()
        {
            pyramid.Add("Hay");
            pyramid.Add("Iron bar");
            pyramid.Add("Bronze bar");
            pyramid.Add("Bricks");
        }
        public void itemDesert()
        {
            desert.Add("Rocks");
            desert.Add("Rope");
            desert.Add("Small chunks of wood");
            desert.Add("Glass");
            desert.Add("Cloth");
        }
        public void itemSecret()
        {
            secret.Add("ENERGYSWORD");
            secret.Add("HL");
            secret.Add("FSBERSERK");
            secret.Add("ZENITH");
            secret.Add("BLOODMOON");
            secret.Add("PLEB");
            secret.Add("TENSAZANGETSU");
            secret.Add("kamonevim");
        }
        public void combatEnemy()
        {
            combat.Add("Snake");
            combat.Add("Scorpion");
        }

    }
}
