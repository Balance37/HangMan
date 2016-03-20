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
            Console.Write("User A please enter a word: ");
            string word = Console.ReadLine();
            char[] characters = word.ToCharArray();
            int length = characters.Length;
            int charLeft = length;
            for (int i = 0; i < length; i++)
            {
                Console.Write("User B please guess the word and enter a character, you have {0} time(s) left:", charLeft-1);
                char guess = Console.ReadKey().KeyChar;
                if(guess)
                charLeft--;
            }

            Console.ReadKey();
        }
    }
}
