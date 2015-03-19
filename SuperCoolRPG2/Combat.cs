using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web;

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

        public int GetDamage()
        {
            int wildCard = RNG.NumberBetween(1, _player.Level);
            return ( _player.Strength - _monster.Defense ) + wildCard;
        }

        public int GetMobDamage()
        {
            int wildCard = RNG.NumberBetween(1, _monster.Level);
            return (_monster.Strength - _player.Defense) + wildCard;
        }

        public async void StartFight() //The actual turn based fighting part of the code.
        {

            while (_player.isFighting && !_player.isDead )
            {

                int thisDamage = GetDamage();

                _monster.HP -= thisDamage;

                _game.SendTextToTextBox(Environment.NewLine + "You deal  " + thisDamage + "  damage to " + _monster.Name + Environment.NewLine);
                await Task.Delay(1000);

                if(_monster.isDead) //Check to see if the mob gets a chance to attack before death.
                {
                    int mobDamage = GetMobDamage();
                    _player.HP -= mobDamage;

                    _game.SendTextToTextBox(Environment.NewLine + "The  " + _monster.Name + " deals " + mobDamage + " to you!" + Environment.NewLine);
                    await Task.Delay(1000);
                }


                if (_player.isDead)
                {

                }
            }

            getReward(); // mobs death message, exp, rewards, good stuff.
        }
        

        public void isDead()
        {
            if(_monster.HP <= 0 )
            {
                _monster.isDead = true;
            }
            else if(_player.HP <= 0)
            {
                _player.isDead = true;
            }


        }

        public void DeathStuff() //All the bad stuff associated with dying, xp loss, etc.
        {
            int xpLoss = XpPerecent();
            _player.Exp -= xpLoss;
            _game.SendTextToTextBox("You've died. You lost " + xpLoss + " experience. ");
            

        }

        public int XpPerecent()
        {
            return _player.Exp / 10;
            
        }

        public void getReward() //rewards player with xp, gold, and items (one day, one day)
        {
            _game.SendTextToTextBox(Environment.NewLine + "You defeated the " + _monster.Name + Environment.NewLine);
            _player.CurrentLocation.areaMonsterList.Remove(this._monster);
            _game.UpdateMonsterListInUI();
            _player.isFighting = false;
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

                switch (_player.ClassString)
                {
                    case "Warrior":
                        _player.Strength += 2;
                        _player.MaxHP += 4;
                        break;
                    case "Mage":
                        _player.Strength += 1;
                        _player.MaxHP += 2;
                        break;
                }

                _game.SendTextToTextBox(" Your stats are now " + _player.MaxHP + " health, " + _player.Strength + " strength ");
                FullHeal(); //generously heal player after leveling.
            }
        }

        public void FullHeal()
        {
            _player.HP = _player.MaxHP;
        }

    }
}
