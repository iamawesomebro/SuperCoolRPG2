using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCoolRPG2
{
    public interface IPlayer
    {

        string Name { get; set; }

        bool isFighting { get; set; }

        bool isDead { get; set; } 

        int MaxHP { get; set; }

        int HP { get; set; }

        int Exp { get; set; }

        int Level { get; set; }

        int Strength { get; set; }

        int Defense { get; set; }

        Location CurrentLocation { get; set; }

    }
}
