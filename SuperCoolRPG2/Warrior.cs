using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCoolRPG2
{
    class Warrior: Player , IPlayer
    {

        public override string ClassString { get { return "Warrior"; } }

        public int HP = 10;
        public int Strength = 5;
    }
}
