using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>(){"cat", "dog", "jazz", "music", "programmer", "alphabet", "portal"};

            string wordToGuessStr = words[RandomNumberGenerator.GetInt32(0, words.Count - 1)];
            
            List<char> wordToGuessList = new List<char>();
            List<char> currentWordGuessed = new List<char>();
            
            for (int x = 0; x < wordToGuessStr.Length; x++)
            {
                wordToGuessList.Add(wordToGuessStr[x]);
                currentWordGuessed.Add('_');
            }

            int lives = 5;

            List<char> lettersGuessed = new List<char>();

            bool wordGuessed = false;
            
            while (lives > 0 && !wordGuessed)
            {
                {
                    String dashedLines= "";
                    for (int x = 0; x < (currentWordGuessed.Count); x++)
                    {
                        dashedLines += currentWordGuessed[x].ToString() + " ";
                    }
                    Console.WriteLine(dashedLines);
                }
                
                Console.WriteLine("Guess a letter");
                
                var Input = Console.ReadLine();
                if (!(Input is string))
                {
                    Console.WriteLine("Input must be a String");
                }
                else if (Input.Length != 1)
                {
                    Console.WriteLine("Input must be a single character");
                }
                else
                {
                    Input = Input.ToLower();
                    char charInput = Input[0];
                    if (lettersGuessed.Contains(charInput))
                    {
                        Console.WriteLine("You have already guessed that letter");
                    }
                    else{
                        lettersGuessed.Add(charInput);
                        if(wordToGuessList.Contains(charInput))
                        {
                            for (int x = 0; x < (wordToGuessList.Count); x++)
                            {
                                if (charInput == wordToGuessList[x])
                                {
                                    currentWordGuessed[x] = charInput;
                                }
                            }
                        }
                        else
                        {
                        lives -= 1;
                        }
                        
                        wordGuessed = true;
                        for (int x = 0; x < wordToGuessList.Count; x++)
                        {
                            if(wordToGuessList[x] != currentWordGuessed[x])
                            {
                                wordGuessed = false;
                                break;
                            }
                        }

                        if (!wordGuessed)
                        {
                            Console.WriteLine($"You have {lives} lives left");
                        }
                    }
                }
            }
            
            Console.WriteLine("You guessed the word");
            Console.WriteLine($"The word was {wordToGuessStr}");
        }
    }
}