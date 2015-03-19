using System;
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
using System.Windows.Shapes;
using System.Diagnostics;

namespace SuperCoolRPG2
{

    /// <summary>
    /// Interaction logic for CharCreation.xaml
    /// </summary>
    public partial class CharCreation : Window
    {
        Player _player = new Player();

        public CharCreation()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            getCharClass(cbPlayerClasses.Text);
            _player.Name = tbName.Text;
            _player.Level = 1;
            MainWindow gameWindow = new MainWindow(_player);
            this.Hide();
            gameWindow.Show();
        }

        public void getCharClass(string input)
        {
           

            switch (input)
            {
                case "Warrior":
                    _player.ClassString = "Warrior";
                    _player.Strength = 5;
                    _player.MaxHP = 10;
                    _player.HP = _player.MaxHP;
                    break;
                case "Mage":
                    _player.ClassString = "Warrior";
                    _player.Strength = 2;
                    _player.MaxHP = 5;
                    break;
            }
        }

    }

}
