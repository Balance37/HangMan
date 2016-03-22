using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            int failTime = 3;
            Console.SetWindowSize(80,50);
            Console.Write("User A please enter a word: ");
            string word = Console.ReadLine();
            char[] characters = word.ToCharArray();
            int length = characters.Length;
            int charLeft = length;
            char[] correctChar = new char[length];
            //Has correct charaters array containing "_" for printing out
            for(int j = 0; j<length; j++)
            {
                correctChar[j] = '_';
            }
            //Prints out "_ _ _ _ _" 
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.SetCursorPosition(45, 20);
            for (int i = 0; i < length; i++)
            {
                Console.Write("_ ");
            }
            //Hides the word
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("*******************************************************************");
            Console.SetCursorPosition(left, top);

            for (int playTime = length + 3; playTime > 0; playTime-- )
            {
                bool continueLoop = false;
                
                //Check if the user has successfully enter all characters
                if (playTime - failTime < 1)
                {
                    Console.WriteLine("Congratulation!! You win!!");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                bool check = false;
                Console.Write("User B please enter a character and hit enter, you can only fail {0} times: ", failTime);
                try
                {
                    char guess = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    check = CheckIfIn(guess, characters);
                    Console.ReadKey();
                    if (check == false)//if guess is incorrect
                    {
                        failTime--;
                        Console.WriteLine("Sorry, wrong guess");
                        if (failTime < 0)
                        {
                            Console.WriteLine("Sorry, you lose, the correct word is {0}", word);
                            Console.WriteLine("Please hit enter to exit");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    else//if guess is correct
                    {
                        for (int k = 0; k < length; k++ )//check if the input has exited
                        {
                            if(guess==correctChar[k])
                            {
                                Console.WriteLine("Please enter a character hasn't been guessed before");
                                playTime++;
                                continueLoop = true;
                            }
                        }
                        if(continueLoop == true)
                        {
                            continue;
                        }

                        //Prints out correct characters
                        correctChar = CopyCorrect(correctChar, guess, characters);
                        int left1 = Console.CursorLeft;
                        int top1 = Console.CursorTop;
                        Console.SetCursorPosition(45, 20);
                        for (int j = 0; j < length;j++ )
                        {
                            Console.Write("{0} ",correctChar[j]);
                        }
                        Console.SetCursorPosition(left1, top1);
                        playTime = playTime - (NumDuplicate(guess, characters) - 1);
                        Console.WriteLine("Good job!!");
                    }
                    Console.WriteLine("Play time left: {0}", playTime - 1);
                }
                catch(Exception)
                {
                    Console.WriteLine();
                }
            }     
        }

        //Checks if input character is in the word
        static bool CheckIfIn(char character, char[] characters)
        {
            bool check = false;
            int length = characters.Length;
            for (int i=0; i<length;i++)
            {
                if(character == characters[i])
                {
                    check = true;
                    return check;
                }
            }
            return check;
        }

        //Checks a character appears how many times in a word
        static int NumDuplicate(char character, char[] characters)
        {
            int count = 0;
            int length = characters.Length;
            for (int i = 0; i < length; i++)
            {
                if (character == characters[i])
                {
                    count++;
                }
            }
            return count;
        }

        //Copy correct characters into an array which would be printed out
        static char[] CopyCorrect(char[] correctChar, char guess, char[] characters)
        {
            for (int i = 0; i < characters.Length; i++ )
            {
                if(guess==characters[i])
                {
                    correctChar[i] = guess;
                }
            }
                return correctChar;
        }

    }

}