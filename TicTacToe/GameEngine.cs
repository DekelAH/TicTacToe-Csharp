using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameEngine
    {
        // 2D array
        private char[,] gameboard =
        {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

        private int turns = 0;

        private int player = 2;
        private int input = 0; // none of the fields in the array is equal to 0
        private bool inputCorrect = true;

        public void GameStart()
        {
            do
            {
                // Checking player value and setting a sign
                if (player == 2)
                {
                    player = 1;
                    SetPlayerSign('X', input);

                }
                else if (player == 1)
                {
                    player = 2;
                    SetPlayerSign('O', input);
                }

                SetBoard();
                GameRules();
                CheckInput();

            } while (true);
        }
        public void CheckInput()
        {
            do
            {
                Console.Write($"\nPlayer {player}: Choose your Move! ");

                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please enter a number.");
                }

                if (input == 1 && gameboard[0, 0] == '1')
                {
                    inputCorrect = true;
                }
                else if (input == 2 && gameboard[0, 1] == '2')
                {
                    inputCorrect = true;
                }
                else if (input == 3 && gameboard[0, 2] == '3')
                {
                    inputCorrect = true;
                }
                else if (input == 4 && gameboard[1, 0] == '4')
                {
                    inputCorrect = true;
                }
                else if (input == 5 && gameboard[1, 1] == '5')
                {
                    inputCorrect = true;
                }
                else if (input == 6 && gameboard[1, 2] == '6')
                {
                    inputCorrect = true;
                }
                else if (input == 7 && gameboard[2, 0] == '7')
                {
                    inputCorrect = true;
                }
                else if (input == 8 && gameboard[2, 1] == '8')
                {
                    inputCorrect = true;
                }
                else if (input == 9 && gameboard[2, 2] == '9')
                {
                    inputCorrect = true;
                }
                else
                {
                    Console.WriteLine("\nIncorrect input. Please use anotehr field");
                    inputCorrect = false;
                }


            } while (!inputCorrect);
        }
        public void GameRules()
        {
            char[] playerCharacters = { 'X', 'O' };

            foreach (char playerSign in playerCharacters)
            {
                if (gameboard[0, 0] == playerSign && gameboard[0, 1] == playerSign && gameboard[0, 2] == playerSign
                   || gameboard[1, 0] == playerSign && gameboard[1, 1] == playerSign && gameboard[1, 2] == playerSign
                   || gameboard[2, 0] == playerSign && gameboard[2, 1] == playerSign && gameboard[2, 2] == playerSign
                   || gameboard[0, 0] == playerSign && gameboard[1, 0] == playerSign && gameboard[2, 0] == playerSign
                   || gameboard[0, 1] == playerSign && gameboard[1, 1] == playerSign && gameboard[2, 1] == playerSign
                   || gameboard[0, 2] == playerSign && gameboard[1, 2] == playerSign && gameboard[2, 2] == playerSign
                   || gameboard[0, 0] == playerSign && gameboard[1, 1] == playerSign && gameboard[2, 2] == playerSign
                   || gameboard[0, 2] == playerSign && gameboard[1, 1] == playerSign && gameboard[2, 0] == playerSign)
                {

                    if (playerSign == 'X')
                    {
                        Console.WriteLine("\nPlayer 2 has won!!!");
                    }
                    else
                    {
                        Console.WriteLine("\nPlayer 1 has won!!!");
                    }

                    Console.WriteLine("Please press any key to reset the game!");
                    Console.ReadKey();
                    ResetBoard();
                    break;
                }
                else if (turns == 10)
                {
                    Console.WriteLine("We have a DRAW!");
                    Console.WriteLine("Please press any key to reset the game!");
                    Console.ReadKey();
                    ResetBoard();
                    break;
                }
            }
        }
        public void SetPlayerSign(char playerSign, int input)
        {

            switch (input)
            {
                case 1:
                    gameboard[0, 0] = playerSign;
                    break;
                case 2:
                    gameboard[0, 1] = playerSign;
                    break;
                case 3:
                    gameboard[0, 2] = playerSign;
                    break;
                case 4:
                    gameboard[1, 0] = playerSign;
                    break;
                case 5:
                    gameboard[1, 1] = playerSign;
                    break;
                case 6:
                    gameboard[1, 2] = playerSign;
                    break;
                case 7:
                    gameboard[2, 0] = playerSign;
                    break;
                case 8:
                    gameboard[2, 1] = playerSign;
                    break;
                case 9:
                    gameboard[2, 2] = playerSign;
                    break;
            }
        }
        public void SetBoard()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {gameboard[0, 0]}  |  {gameboard[0, 1]}  |  {gameboard[0, 2]}");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {gameboard[1, 0]}  |  {gameboard[1, 1]}  |  {gameboard[1, 2]}");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {gameboard[2, 0]}  |  {gameboard[2, 1]}  |  {gameboard[2, 2]}");
            Console.WriteLine("     |     |");
            turns++;
        }

        public void ResetBoard()
        {
            char[,] initialGameboard =
            {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };

            gameboard = initialGameboard;
            turns = 0;
            SetBoard();
        }
    }


}
