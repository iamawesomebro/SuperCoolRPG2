using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SuperCoolRPG2
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location NorthLocation { get; set; }
        public Location SouthLocation { get; set; }
        public Location WestLocation { get; set; }
        public Location EastLocation { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
        private List<IPlayer> AreaMontsterList { get { return areaMonsterList; } set { areaMonsterList = value; OnPropertyChanged(); } }
        public List<IPlayer> areaMonsterList = new List<IPlayer>();

        public Location(int id, string name, string desc)
        {
            ID = id;
            Name = name;
            Description = desc;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

}
