using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatoCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "a a a zz    zdssf e eg ggt";
            while (s[0] == ' ')
            {
                s = s.Remove(0,1);
            }
            int count = 0;
            for (int i = 1; i < s.Length; i++) 
            {
                if (s[i] != s[i - 1] && s[i] != ' ')
                {
                  count++;
                }
                
            }
            Console.WriteLine(count+1);
        }
    }
}
