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
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace RollTheDice
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //vytvoření objektu třídy Game (soubor Game.cs), v níž je logika aplikace
        public Game game = new Game();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            int userNumber = 0;
            game.GenerateNumber();
            try
            {
                userNumber = Convert.ToInt32(tbxNumberInput.Text);
            }
            catch
            {
                MessageBox.Show("Invalid input, please try again (numbers 1 - 6)");
            }
            if (game.CheckIfWin(userNumber))
            {
                ChangeImage(game.CurrentNumber);
                MessageBox.Show("You win!");
                score.Text = Convert.ToString(game.Score);
                lives.Text = Convert.ToString(game.Lives);
            }
            else
            {
                ChangeImage(game.CurrentNumber);
                MessageBox.Show("Try again :)");
                lives.Text = Convert.ToString(game.Lives);
                score.Text = Convert.ToString(game.Score);
            }
            tbxNumberInput.Text = "";

            //resetování obrázku na původní
            imgDice.Source = new BitmapImage(new Uri(@$"Images/dice_default.png", UriKind.Relative));
        }
        public void ChangeImage(int diceNumber)
        {
            imgDice.Source = new BitmapImage(new Uri(@$"Images/dice{diceNumber}.png", UriKind.Relative));
            //díky interpolaci řetěžců (znak dolaru) můžeme vložit hozené číslo do názvu souboru
            // -> tím se při hodu čísla 3 vytvoří adresa "Images/dice3.png"
            //    která odkazuje na obrázek s hozeným číslem 3 na hrací kostce ve složce Images
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            game.Score = 0;
            game.Lives = 5;

            lives.Text = Convert.ToString(game.Lives);
            score.Text = Convert.ToString(game.Score);
        }
    }
}
