using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackLibrary;

namespace ExpresionCalculatoins
{
    internal class Program
    {
        static List<string> Parsing(string source) 
        {
            List<string> result = new List<string>();
            int state = 1;
            string t = "";
            for (int i = 0; i < source.Length;i++) 
            {
                char ch = source[i];
                switch (state) 
                {
                    case 1:
                        if (Char.IsDigit(ch) || ch.ToString() == ",")
                        {
                            t = t + ch.ToString();
                        }
                        else 
                        {
                            if (Char.IsDigit(ch) == false)
                            {   
                                result.Add(t);
                                t = ch.ToString();
                                state = 2;
                                break;
                            }
                            else 
                            {
                                throw new Exception();
                            }
                        }
                        break;

                    case 2:
                        if (Char.IsDigit(ch) == false)
                        {
                            t = t + ch.ToString();
                        }
                        else 
                        {
                            if (Char.IsDigit(ch))
                            {
                                result.Add(t);
                                t = ch.ToString();
                                state = 1;
                                break;
                            }
                            else 
                            {
                                throw new Exception();
                            }

                        }
                        break;
                }
                    
            }
            result.Add(t);
            return result;
        }
        static List<string> ExpresionToPolish(List<string> parsed) 
        {
            List<string> result = new List<string>();
            StackLibrary.Stack<string> oper_stack = new ArrayStack<string>(100);
            foreach (string el in parsed)
            {
                //Если символ является бинарной операцией 
                if ((el == "+" ) || (el == "-") || (el == "*") || (el == "/")) 
                {
                    if (oper_stack.Size() != 0)
                    {
                        string operation = oper_stack.Pop();
                        if (operation == "*" || operation == "/" || operation == "**")
                        {
                            result.Add(operation);
                            oper_stack.Push(el);
                        }
                        else
                        {
                            if ((operation == "+" || operation == "-") && (el == "+" || el == "-"))
                            {
                                result.Add(operation);
                                oper_stack.Push(el);
                            }
                            else
                            {
                                oper_stack.Push(operation);
                                oper_stack.Push(el);
                            }
                        }
                        
                    }
                    else 
                    {

                        oper_stack.Push(el);
                    }

                }
                else 
                {
                    result.Add(el);
                }
            }
            while (oper_stack.Size() != 0) 
            {
                result.Add(oper_stack.Pop());
            }
            return result;
        }

        static double Calc(List<string> polish)
        {
            StackLibrary.Stack<string> IntStack = new ArrayStack<string>(100);
            int l = polish.Count;
            int opsCount = 0;
            List<string> ops = new List<string>();
            for (int i = 0; i < l; i++)
            {
                if (polish[i] == "+" || polish[i] == "-" || polish[i] == "*" || polish[i] == "/" || polish[i] == "**")
                {
                    opsCount++;
                    ops.Add(polish[i]);
                }
                else
                {
                    IntStack.Push(polish[i]);
                }
            }
            for (int i = 0; i < opsCount; i++)
            {
                if (IntStack.Size() != 1)
                {
                    string el1 = IntStack.Pop();
                    string el2 = IntStack.Pop();
                    if (ops[i].ToString() == "+")
                    {
                        double res = Convert.ToDouble(el1) + Convert.ToDouble(el2);
                        IntStack.Push(res.ToString());
                    }
                    if (ops[i].ToString() == "-")
                    {
                        double res = Convert.ToDouble(el1) - Convert.ToDouble(el2);
                        IntStack.Push(res.ToString());
                    }
                    if (ops[i].ToString() == "*")
                    {
                        double res = Convert.ToDouble(el1) * Convert.ToDouble(el2);
                        IntStack.Push(res.ToString());
                    }
                    if (ops[i].ToString() == "/")
                    {
                        double res = Convert.ToDouble(el1) / Convert.ToDouble(el2);
                        IntStack.Push(res.ToString());
                    }
                    if (ops[i].ToString() == "**")
                    {
                        double res = Math.Pow(Convert.ToDouble(el2),Convert.ToDouble(el1));
                        IntStack.Push(res.ToString());
                    }
                }
            }
            double ans = Convert.ToDouble(IntStack.Pop());
            return ans;

        }

        static void Main(string[] args)
        {
            string s = "2+34*78";
            List<string> parsed = Parsing(s);
            List<string> posilsh = ExpresionToPolish(parsed);
            double result = Calc(posilsh);
            Console.WriteLine(result);
        }
    }
}
