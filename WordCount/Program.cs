using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = " To be or not  to be ? That is the question. ";
            string[] Words = sentence.Split(new Char[] { ' ', '?', '!', ',', '.'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string w in Words)
            {
                Console.WriteLine(w);
            }
            
        }
    }
}
