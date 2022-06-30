using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackLibrary;

namespace StateCalcExpression
{
    class Parser 
    {
        public State state;
        List<string> result;
        string expresion;
        public Parser(string expresion) 
        {
            this.expresion = expresion;
            result = new List<string>();
            state = new Nparsing(this);
        }
        public void AddResult(string el) 
        {
            result.Add(el);
        }
        public void Run(char ch) 
        {
            state.Handle(ch);
        }
        public List<string> Result() 
        {
            return result;
        }
    }
    abstract class State
    {
        protected Parser parser;
        public State(Parser parser)
        {
            this.parser = parser;
        }

        public abstract void Handle(char ch);
    }
    class Nparsing : State
    {
        string t = "";
        public Nparsing(Parser parser) : base(parser)
        {
        }
        public override void Handle(char ch)
        {
            if (Char.IsDigit(ch) || ch.ToString() == ",")
            {
                t = t + ch.ToString();
            }
            else
            {
                if (Char.IsDigit(ch) == false)
                {
                    parser.AddResult(t);
                    t = ch.ToString();
                    parser.state = new Oparsing(parser);
                }
                else
                {
                    throw new Exception();
                }
            }
            
        }
    }
    class Oparsing : State
    {
        string t = "";
        public Oparsing(Parser parser) : base(parser)
        {
        }
        public override void Handle(char ch)
        {
            if (Char.IsDigit(ch) == false)
            {
                t = t + ch.ToString();
            }
            else
            {
                if (Char.IsDigit(ch))
                {
                    parser.AddResult(t);
                    t = ch.ToString();
                    parser.state = new Nparsing(parser);
                }
                else
                {
                    throw new Exception();
                }

            }
            
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser("5+3,2");
            parser.Run();
            parser.Result();