using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollTheDice
{
    public class Game
    {
        #region Vlastnosti
        public int Score { get; set; }
        public int Lives { get; set; }
        public int CurrentNumber { get; set; }
        #endregion

        //generátor náhodných čísel
        private Random generator = new Random();

        #region Metody
        //konstruktor (metoda, která se zavolá při vytvoření)
        public Game()
        {
            Lives = 5;
            Score = 0;
        }
        //

        //metoda, která vygeneruje náhodné číslo na kostce
        public void GenerateNumber()
        {
            int number = generator.Next(1, 7);
            CurrentNumber = number;
        }

        public bool CheckIfWin(int chosenNumber)
        {
            if (chosenNumber == CurrentNumber)
            {
                Score++;
                return true;
            }
            else
            {



                Lives--;



                if (Lives == 0)
                {
                    Lives = 5;
                    Score = 0;
                }
                return false;
            }
        }
        //metoda, pro restartování počátečního stavu hry
        public void ResetGame()
        {
            Score = 0;
            Lives = 5;


        }
        #endregion
    }
}
