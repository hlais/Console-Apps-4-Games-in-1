using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ConsoleAppGames
{
    class Program
    {
        //m_variables
        public static Random _random = new Random();
        static int _score = 0;
        public static int _option = 0;

        //m_variables for knots and cross 
        public static List<char> _positionOnBoard = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static int _player = 1;
        public static int _choice;
        public static int _flag = 0;
        //end of global variables

        public static bool hasTheGameEnded = false;
    

        static void Main(string[] args)
        {
            ///welcome to the collection of simple games by Halim
            
            Console.Title = "Halim's Fun Console App Games";

            GameSelectScreen();


            Console.ReadKey();
          
        }


        public static void GameSelectScreen()
        {
            Console.Clear();//cleaning up previous game 

            //heading, inc fancy color and score
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t CURRENT SCORE: " + _score);
            Console.WriteLine("\n\n");
            //end of heading

            Console.WriteLine(" Please select a game. Choose a number and hit enter \n\n");

            //The games
            Console.WriteLine("1\t- Hang Man");
            Console.WriteLine("2\t- Number Guessing Games");
            Console.WriteLine("3\t- Knots and Crosses");
            Console.WriteLine("4\t- Number Re-arranging Game");

            string input = Console.ReadLine();

            //to prevent incorrect input
            _option = ValidInputChecker(input,1,4);

            switch (_option)
            {
                case 1:
                    HangMan();
                    break;

                case 2:
                    NumberGuessingGame();
                    break;

                case 3:
                    KnotsAndCrosses();
                    break;

                case 4:
                    RearrangeTheNumbersGame();
                    break;

                default:
                    Console.WriteLine("There is no way you reached this code ;) ");
                    break;
            }

            Console.ReadLine();
        }

        public static void HangMan()
        {
            //variables for the game
            int lives = 5;
            bool won = false;
            int lettersRevealed = 0;
            string input;
            char guess;
            //end

            //the titles to the movie - Dont peak 
            string[] wordBank = { "Grudge", "Titanic", "Batman", "Matrix", "Leon", "Frozen" };
            
            //Fancy Title 
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nWelcome to hang man \nGuess the movie title:\n\n");
            //End Fancy title
            //wait until we load game- to create loading effect.
            Thread.Sleep(2000);

            string wordToGuess = wordBank[_random.Next(0, wordBank.Length)];
            string wordToGuessUppercase = wordToGuess.ToUpper();

            //print out missing letters, 
            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                displayToPlayer.Append('_');
            }

            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            
            //Game Begin:
            while (!won && lives > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Guess a Letter: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                    continue;
                }

                if (wordToGuessUppercase.Contains(guess))
                {
                    correctGuesses.Add(guess);

                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuessUppercase[i] == guess)
                        {
                            displayToPlayer[i] = wordToGuess[i];
                            lettersRevealed++;
                        }
                    }

                    if (lettersRevealed == wordToGuess.Length)
                        won = true;
                }
                else
                {
                    incorrectGuesses.Add(guess);
                    Console.WriteLine("Nope, there's no '{0}' in it!", guess);

                    lives--;
                    printHangMan(lives);
                }

                Console.WriteLine(displayToPlayer.ToString());
            }

            
            if (won)
            {
                Win();
            }
            else
            {
                Console.WriteLine("Too bad it was'{0}'", wordToGuess);
                Lose();
            }
            GameSelectScreen();
            Console.ReadLine();
        }
        //Helper method to determine win
        private static void Win()
        {
            Console.WriteLine("\t\t You won!");
            Console.WriteLine("Points added: +20");
            Thread.Sleep(2000);
            _score += 20;
        }
        //Helper method to determine win
        private static void Lose()
        {
            Console.WriteLine("\t\t You lost! Too bad man");
            Console.WriteLine("Points deducted -20");
            Thread.Sleep(2000);
            _score -= 20;
        }

        //Method to print board for HANGMAN GAME
        public static void printHangMan(int chancesLeft)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            switch (chancesLeft)
            {
                case 5:
                    Console.WriteLine("  ____   ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine("_|___    ");
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("  ____   ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |    O  ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine("_|___    ");
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("  ____   ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |   _O_ ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine("_|___    ");
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("  ____   ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |   _O_ ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |       ");
                    Console.WriteLine("_|___    ");
                    Console.WriteLine();
                    break;
                case 1:
                    Console.WriteLine("  ____   ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |   _O_ ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |   /   ");
                    Console.WriteLine("_|___    ");
                    Console.WriteLine();
                    break;
                case 0:
                    Console.WriteLine("  ____   ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |   _O_ ");
                    Console.WriteLine(" |    |  ");
                    Console.WriteLine(" |   / \\ ");
                    Console.WriteLine("_|___    ");
                    Console.WriteLine();
                    break;
            }
        }

      
       

        public static void KnotsAndCrosses()
        {
            string strChoice;
            //to allow computer to choose. 
            int cpuChoice = 0; 
            
             Console.WriteLine(" Welcome to: KNOTS AND CROSSES \n");
            //wait until we load game.
            Thread.Sleep(2000);

            do
            {

                Console.WriteLine("Player 1 : X \t\t\t Player 2 (com) : O \n");
                if (_player % 2 == 0)
                {
                    Console.WriteLine("Computer's turn");

                    //-*Future update required to improve random pick of COM choices*.
                   cpuChoice = _random.Next(1, 9);
                    Thread.Sleep(2000);
                   
                }
                else
                {
                    Console.WriteLine("Player 1 turn: \nPlease mark your position on grid:");
                }
                
                //only allow player 1 to make a move
                if (_player % 2 != 0)
                {
                    board();
                    strChoice = Console.ReadLine();
                    _choice = ValidInputChecker(strChoice, 1, 9);
                }
                

                if (_positionOnBoard[_choice] != 'X' && _positionOnBoard[_choice] != 'O'
                    || _positionOnBoard[cpuChoice] != 'X' && _positionOnBoard[cpuChoice] != 'O')
                {
                    if (_player % 2 == 0)
                    {
                        _positionOnBoard[cpuChoice] = 'O';
                         board();
                        _player++;
                    }
                    else
                    {
                        _positionOnBoard[_choice] = 'X';
                        _player++;
                    }
                }
                else
                {
                    Console.WriteLine("Try again buster, {0} is already marked with {1}", _choice, _positionOnBoard[_choice]);
                }

                _flag = checkForWin();
            }
            while (_flag != 1 && _flag != -1);
            if (_flag == 1)
            {
                if (_player % 2 == 0)
                {

                    Win();
                    
                }
                if (_player %2 !=0)
                {
                    Lose();
                }
            }
            else
            {
                //no points added, simply reset values and go main menu;
                Console.WriteLine("Draw");
               
            }

            resetKnotsAndCross(_positionOnBoard, _player, _flag); 
            GameSelectScreen();
            Console.ReadLine();

        }
       
        //knots and cross board
        static void board()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" {0}  |  {1}  |  {2}  ", _positionOnBoard[1], _positionOnBoard[2], _positionOnBoard[3]);
            Console.WriteLine("____|_____|____");

            Console.WriteLine(" {0}  |  {1}  |  {2}  ", _positionOnBoard[4], _positionOnBoard[5], _positionOnBoard[6]);
            Console.WriteLine("____|_____|____");

            Console.WriteLine(" {0}  | {1}   | {2}   ", _positionOnBoard[7], _positionOnBoard[8], _positionOnBoard[9]);
            Console.WriteLine("    |     |   ");
        }
        static int checkForWin()
        {
            if (_positionOnBoard[1] == _positionOnBoard[2] && _positionOnBoard[2] == _positionOnBoard[3])
            {
                return 1;
            }
            else if (_positionOnBoard[4] == _positionOnBoard[5] && _positionOnBoard[5] == _positionOnBoard[6])
            {
                return 1;
            }
            else if (_positionOnBoard[7] == _positionOnBoard[8] && _positionOnBoard[8] == _positionOnBoard[9])
            {
                return 1;
            }

            else if (_positionOnBoard[1] == _positionOnBoard[4] && _positionOnBoard[4] == _positionOnBoard[7])
            {
                return 1;
            }
            else if (_positionOnBoard[2] == _positionOnBoard[5] && _positionOnBoard[5] == _positionOnBoard[8])
            {
                return 1;
            }
            else if (_positionOnBoard[3] == _positionOnBoard[6] && _positionOnBoard[6] == _positionOnBoard[9])
            {
                return 1;
            }

            else if (_positionOnBoard[1] == _positionOnBoard[5] && _positionOnBoard[5] == _positionOnBoard[9])
            {
                return 1;
            }
            else if (_positionOnBoard[3] == _positionOnBoard[5] && _positionOnBoard[5] == _positionOnBoard[7])
            {
                return 1;
            }

            else if
                (_positionOnBoard[1] != '1' && _positionOnBoard[2] != '2' && _positionOnBoard[3] != '3'
                     && _positionOnBoard[4] != '4' && _positionOnBoard[5] != '5' && _positionOnBoard[6] != '6'
                     && _positionOnBoard[7] != '7' && _positionOnBoard[8] != '8' && _positionOnBoard[9] != '9')

            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        //reseting values
        private static void resetKnotsAndCross(List<char> board, int player, int flag)
        {
           _positionOnBoard = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
           _player = 1;
           _flag = 0;
        }
   

        public static void NumberGuessingGame()
        {
            int computerGuess = _random.Next(1, 20);
            int attempts = 5;

            bool gameOver = false;
            //Fancy Title: (I like to think :))
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("THE GUESSING GAME\n\n");
            //wait until we load game.
            Thread.Sleep(2000);

            Console.WriteLine("The computer is guessing a number.\nCan you guess the number");

            while (!gameOver)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("YOU CURRENTLY HAVE {0} LIVES REMAINING \n\n", attempts);
                attempts--;

                Console.WriteLine("Pick a number and try to guess what im thinking?");
                string userInput = Console.ReadLine();
                int playerGuess = ValidInputChecker(userInput, 1, 20);

                if (playerGuess > computerGuess)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Please try again the number {0} is too high",playerGuess);

                }
                if (playerGuess < computerGuess)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Please try again the number {0} is to low, try higher", playerGuess);

                }
                if (playerGuess == computerGuess)
                {
                    Win();
                    

                    gameOver = true;

                }

                if (playerGuess != computerGuess && attempts == 0)
                {
                    Console.WriteLine("Wow you suck! Five guesses and it didnt work");
                    Lose();
                    
                    gameOver = true;
                }

            }
            GameSelectScreen();
        }
        //Small method to print out list 
        public static void WriteOutList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine();
        }

        public static void RearrangeTheNumbersGame()
        {
            //to make it feel like a game, we have a penalty for wrong attempts 
            int attemptsPenalty = 5;
            int swapOne, swapTwo;

            //string to enable a call to method ValidInputChecker, list to allow for swapping
            string stringSwapOne, stringSwapTwo;
            List<int> list = new List<int>();

            //For correct order-  to determine win condition.
            List<int> sortedList = new List<int>(list);
            sortedList.Sort();

            //fancy title?
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("THE RE-ARRANGE NUMBERS GAME!!");
            Thread.Sleep(2000);
            
            //generate random numbers and put numbers inside list.
            for (int i = 0; i < 6; i++)
            {
                randomGen:
                int randomNumber = _random.Next(1 , 50);
                if (list.Contains(randomNumber) == false)
                {
                    list.Add(randomNumber);
                }
                //repeat if already contains number
                else goto randomGen;
               
            }
            //Begin game:
            Console.WriteLine("Rearrange the numbers in order");
            while (true)
            {
                swapOne = 0;
                swapTwo = 0 ;
                WriteOutList(list);

                while (list.Contains(swapOne) == false)
                {
                    Console.WriteLine("Whats the first number you want to Swap \t\t Attempts Countdown {0}",attemptsPenalty);
                    stringSwapOne = Console.ReadLine();
                    swapOne = ValidInputChecker(stringSwapOne, 1, 50);
                }
                //when the user hasnt picked a number in the list
                while (list.Contains(swapTwo) == false || swapTwo == swapOne)
                {
                    Console.WriteLine("Whats the second number you want to swap");
                    stringSwapTwo = Console.ReadLine();
                    swapTwo = ValidInputChecker(stringSwapTwo, 1, 50);
                    attemptsPenalty--;

                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == swapOne)
                    {
                        list[i] = swapTwo;
                    }
                    else if (list[i] == swapTwo)
                    {
                        list[i] = swapOne;
                    }
                }
                if (attemptsPenalty < 1)
                {
                    //Lose state
                    Lose();
                    break;
                }
     
                if (list.SequenceEqual(sortedList) == true)
                {
                        //win state!
                        WriteOutList(list);
                        Win();
                        break;
                }
            }
            GameSelectScreen();
        }
        //Method to make sure user is not puting incorrect input
        private static int ValidInputChecker(string input, int minRange, int maxRange)

        {
            int choice = 0;
            bool isValidInput = false;

           //repeat until we get valid input 
            while (!isValidInput)
            {
                Start:
                
                isValidInput = Int32.TryParse(input, out choice);
                if (!isValidInput)
                {
                    //this will get run if we dont get int type value
                    Console.WriteLine("Please try again, inputting valid input");
                    
                    input = Console.ReadLine();
                    continue;

                }
                //incorrect number range
                if (choice > maxRange || choice < minRange)
                {
                    Console.WriteLine("Please try again, but options are only {0}- {1}", minRange, maxRange);
                    input = Console.ReadLine();
                    goto Start;

                }
                if (choice >= minRange && choice <= maxRange)
                {

                    isValidInput = true;
                    return choice;
                }
            }
            //return valid choice
            return choice;
        }
    }
    ///End of Games
}