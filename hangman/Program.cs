using System;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            // Randomly select word
            string[] words = { "duck", "cow", "monkey", "bird", "sparrow", "fish" };
            Random rnd = new Random();
            int random = rnd.Next(0, 5);
            // Convert word in to searchable characters
            char[] word = words[random].ToCharArray();

            // Splash screen
            Intro();
            Console.WriteLine("press enter to start game");
            Console.ReadLine();

            // Start Game
            int tries = 5;
            string input = "";
            List<char> used = new List<char>();
            string[] guess = new string[word.Length];
            bool correct = false;
            bool GameOver = false;
            // Fill guess var with underscores
            for (int i = 0; i < word.Length; i++)
            {
                guess[i] = "_";

            }

            while (GameOver == false)
            {
                Console.Clear();
                HangMan();

                Console.WriteLine("Tries left: {0}", tries);
                Console.Write("word: ");
                for (int i = 0; i < word.Length; i++)
                {
                    Console.Write(guess[i]);
                }


                Console.WriteLine("\nLetters guessed: {0}", string.Join(",", used.ToArray()));
                Console.Write("\nGuess a letter: ");
                input = Console.ReadLine();

                if (input.Length > 0)
                {
                    if (used.Contains(input[0]))
                    {
                        //do nothing
                    }
                    else
                    {
                        used.Add(input[0]);
                    }
                    // Check user input against word and guess
                    // Do not edit!!!
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (input[0] == word[i])
                        {
                            guess[i] = Convert.ToString(input[0]);
                            correct = true;
                        }
                    }
                }
                if (correct == false)
                {
                    tries -= 1;
                }
                if (string.Join("", guess) == string.Join("", word))
                {
                    GameOver = true;
                }
                else if (tries == 0)
                {
                    GameOver = true;
                }
                correct = false;
            }

            if (string.Join("", guess) == string.Join("", word))
            {
                Console.Clear();
                LiveMan();
                Console.WriteLine("You Win!");
                Console.ReadLine();
            }
            else if (tries == 0)
            {
                Console.Clear();
                DeadMan();
                Console.WriteLine("You Lose!");
                Console.ReadLine();
            }
        }
        static void HangMan()
        {
            /*      |------  
             *      |     |
             *      |     | 
             *      |   (..)
             *      |    /|\
             *      |     |
             * _____|____/_\__
             *       
             */

            Console.WriteLine("      |------    \n" +
                              "      |     |    \n" +
                              "      |     |    \n" +
                              "      |   (..)   \n" +
                              "      |    /|\\  \n" +
                              "      |     |    \n" +
                              " _____|____/_\\__\n" +
                              "");
        }
        static void DeadMan()
        {
            Console.WriteLine("      |------    \n" +
                              "      |     |    \n" +
                              "      |     |    \n" +
                              "      |   (xx)   \n" +
                              "      |    /|\\  \n" +
                              "      |     |    \n" +
                              " _____|____/_\\__\n" +
                              "");
        }
        static void LiveMan()
        {
            Console.WriteLine("      |------.    \n" +
                              "      |          \n" +
                              "      |          \n" +
                              "      |   (._.)   \n" +
                              "      |    /|\\  \n" +
                              "      |     |    \n" +
                              " _____|____/_\\__\n" +
                              "");
        }

        static void Intro()
        {
            Console.WriteLine("___________________________________________________     \n" +
                              " _                                                |     \n" +
                              "| |__   __ _ _ __   __ _ _ __ ___   __ _ _ __     |     \n" +
                              "| '_ \\ / _` | '_ \\ / _` | '_ ` _ \\ / _` | '_ \\  (**)\n" +
                              "| | | | (_| | | | | (_| | | | | | | (_| | | | |  /|\\   \n" +
                              "|_| |_|\\__,_|_| |_|\\__, |_| |_| |_|\\__,_|_| |_|   |  \n" +
                              "                   |___/                         / \\   \n" +
                              "");
        }

    }
}
