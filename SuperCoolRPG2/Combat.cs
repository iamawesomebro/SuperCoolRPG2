using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SuperCoolRPG2
{
    class Combat
    {
        Player _player;
        Monster _monster;
        MainWindow _game;

        public Combat(Player player, Monster monster, MainWindow game)
        {
            this._player = player;
            this._monster = monster; //Whe the player is attacking, this makes it look like it's only going to be a PVE game, lol.
            this._game = game; //All the UI information goes here. Is there a better way to do this? I want to keep the UI and engine away from each other.
        }

        public int GetDamage ()
        {
            int wildCard = RNG.NumberBetween(1, _player.Level);
            return ( _player.Strength - _monster.Defense ) + wildCard;
        }

        public void StartFight() //The actual turn based fighting part of the code.
        {
            
            while(_player.isFighting)
            {
                if(isDead())
                {

                    _game.SendTextToTextBox(Environment.NewLine + "You defeated the " + _monster.Name + Environment.NewLine);
                    _player.CurrentLocation.areaMonsterList.Remove(this._monster);
                    _player.isFighting = false;
                    getReward();

                }
                else
                {
                    int thisDamage = GetDamage();

                    _monster.HP -= thisDamage;

                    _game.SendTextToTextBox(Environment.NewLine + "You deal  " + thisDamage + "  damage to " + _monster.Name + Environment.NewLine);

                    Thread.Sleep(200);
                    _game.ClearTextBox();
                }

            }
        }

        public bool isDead()
        {
            if(_monster.HP <= 0)
            {
                return true;
            }

            return false;
        }

        public void getReward() //rewards player with xp, gold, and items (one day, one day)
        {
            _player.Exp += _monster.Exp;
            checkLevelUp();
        }

        public void checkLevelUp()
        {
            int expNeeded = _player.Level * 1;

            if (_player.Exp == expNeeded)
            {
                _player.Level++;
                _player.Exp = 0;
                _game.SendTextToTextBox("YOU'VE REACHED LEVEL " + _player.Level.ToString());

            }
        }
    }
}
