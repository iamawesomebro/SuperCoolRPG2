using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SuperCoolRPG2
{
    public class Player :IPlayer, INotifyPropertyChanged
    {
        private int level;
        private int exp;
        private int hp;
        private int strength;


        public bool isFighting { get; set; }
        public bool isDead { get; set; }

        public int HP { get { return this.hp; } set { this.hp = value; NotifyPropertyChanged(); } }
        public int MaxHP { get; set; }

        public int Defense { get; set; }

        public int Level { get { return this.level; } set { this.level = value; NotifyPropertyChanged(); } }

        public int Strength { get { return this.strength; } set { this.strength = value; NotifyPropertyChanged(); } }

        public List<Item> Inventory = new List<Item>();

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

        public string ClassString { get; set; }

        public Location CurrentLocation { get; set; }

        public Weapon EquippedWeapon { get; set; }

        public int Exp { get { return this.exp; } set { this.exp = value; NotifyPropertyChanged(); } }

        


        private void NotifyPropertyChanged([CallerMemberName] string property = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(property));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
