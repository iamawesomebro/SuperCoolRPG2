﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SuperCoolRPG2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player _player;
        Movement movement;

        event PropertyChangedEventHandler PropertyChanged;

        public MainWindow(Player _player)
        {

            InitializeComponent();

            this._player = _player;
            movement.MoveTo(Game.LocationByID(Game.LOCATION_ID_START));
            _player.Inventory.Add(Game.ItembyID(Game.WEAPON_ID_NEWBIE_SWORD));

            lblName.DataContext = _player;
            lblClass.DataContext = _player;
            lblExperience.DataContext = _player;
            lblLevel.DataContext = _player;
            lblStrength.DataContext = _player;
            lblHitPoints.DataContext = _player;
        }


        private void btnNorth_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
            movement.MoveTo(_player.CurrentLocation.NorthLocation);
            IncreaseStepCounter();
        }

        private void btnWest_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
            movement.MoveTo(_player.CurrentLocation.WestLocation);
            IncreaseStepCounter();
        }

        private void btnSouth_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
            movement.MoveTo(_player.CurrentLocation.SouthLocation);
            IncreaseStepCounter();
        }

        private void btnEast_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
            movement.MoveTo(_player.CurrentLocation.EastLocation);
            IncreaseStepCounter();
        }

        public void SendTextToTextBox(string text)
        {
            rtbMessages.Text += text;
            rtbMessages.ScrollToEnd();
        }

        public void IncreaseStepCounter()
        {
            ++Game.stepCounter;
        }

        public void ClearTextBox()
        {
            rtbMessages.Text = String.Empty;
        }

        public void UpdateMovementInUi()
        {
            btnNorth.Visibility = (_player.CurrentLocation.NorthLocation == null ? Visibility.Hidden : Visibility.Visible);

            btnWest.Visibility = (_player.CurrentLocation.WestLocation == null ? Visibility.Hidden : Visibility.Visible);

            btnEast.Visibility = (_player.CurrentLocation.EastLocation == null ? Visibility.Hidden : Visibility.Visible);

            btnSouth.Visibility = (_player.CurrentLocation.SouthLocation == null ? Visibility.Hidden : Visibility.Visible);
        }

        public void UpdateMonsterListInUI()
        {

            if (_player.CurrentLocation.areaMonsterList.Count == 0)
            {
                // The area doesn't have any monsters, no use showing the stuff.
                cboMonsters.Visibility = Visibility.Hidden;
                btnUseWeapon.Visibility = Visibility.Hidden;
            }
            else
            {
                cboMonsters.Visibility = Visibility.Visible;
                btnUseWeapon.Visibility = Visibility.Visible;
                cboMonsters.DataContext = _player.CurrentLocation.areaMonsterList;
                cboMonsters.DisplayMemberPath = "Name";
                cboMonsters.SelectedValuePath = "ID";

                cboMonsters.SelectedIndex = 0;
            }
        }

        private void btnUseWeapon_Click(object sender, RoutedEventArgs e)
        {

            Monster _currentMonster = (Monster)cboMonsters.SelectedItem;

            Combat currentFight = new Combat(this._player, _currentMonster, this);

            _player.isFighting = true;

            currentFight.StartFight(); 
            
            
            
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
