using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackLibrary;

namespace Stack1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new ArrayStack(5);

            stack.Push(1);
            stack.Push(3);
            stack.Push(5);
            stack.Push(7);
            stack.Push(6);
            Show(stack);
            Show(stack);
;            //stack.Push(12);
        }
        static void Show(Stack s)
        {
            Console.WriteLine("Top");
            Stack<int> tmp = new ArrayStack<int>(100);
            while (!s.IsEmpty())
            {
                Object o = s.Pop();
                Console.WriteLine(o);
                tmp.Push(o);
            }
            Console.WriteLine("=================");
            while (!tmp.IsEmpty())
            {
                Object o = tmp.Pop();
                s.Push(o);
            }

            //!!!!!!
        }
    }
}