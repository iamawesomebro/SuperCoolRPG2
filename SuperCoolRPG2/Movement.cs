using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCoolRPG2
{
    class Movement
    {
        MainWindow game;
        Player player;

        public Movement(MainWindow game)
        {
            this.game = game;
        }

        public void MoveTo(Location newLocation)
        {
            

            player.CurrentLocation = newLocation;
           
            game.rtbLocation.Text = newLocation.Name + Environment.NewLine;
            game.rtbLocation.Text += newLocation.Description + Environment.NewLine;

            Game.GenerateRandomMonster(player.Level, player.CurrentLocation);

            if (player.CurrentLocation.areaMonsterList.Count != 0)
            {
                foreach (Monster monster in player.CurrentLocation.areaMonsterList)
                {
                    game.SendTextToTextBox("A " + monster.Name + " is here." + Environment.NewLine);
                }
            }

            game.UpdateMonsterListInUI();
        }
    }
}
