using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCoolRPG2
{
    public enum MonsterClass 
    {
        Warrior,
        Mage,
    }
    public class Monster : IPlayer
    {
        public int ID { get; set; }
        public int Defense { get; set; }
        public bool isFighting { get; set; } //is mob currently in battle
        public int Strength { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; } //How much a mob is worth in xp, not how much it has.
        public string Name { get; set; }
        public int RewardGold { get; set; }
        public int HP { get; set; }
        public Location CurrentLocation { get; set; }
        MonsterClass MClass { get; set; }

        public Monster(int id, string name, int level, MonsterClass mclass)
        {

            int wildCard = RNG.NumberBetween(1, this.Level);

            Defense = wildCard;
            ID = id;
            Name = name;
            Level = level;
            HP = GetHP(level, mclass);
            Exp = GetXPReward(level);
            RewardGold = GetRewardGold(level);
            MClass = mclass;
        }

        static public int GetXPReward(int level)
        {
            if (level * (int)1.5 <= 0)
            {
                return 1;
            }
            else
            {
                return level * (int)1.5;
            }
        }

        static public int GetRewardGold(int level)
        {
            return level * 2;
        }

        static public int GetHP(int level, MonsterClass mclass)
        {
            switch (mclass)
            {
                case MonsterClass.Warrior:
                    return 9 * level;
                case MonsterClass.Mage:
                    return 1 * level;
                default:
                    return 1;
            }
        }
    }

}
