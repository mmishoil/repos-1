using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackLibrary
{
    public interface Stack<T>
    {
        int Size();
        bool IsEmpty();
        void Push(T o);
        T Pop();
        T Top();
    }
    class StackFullException : Exception
    {
        public StackFullException() : base()
        { }
    }
    public class ArrayStack<T> : Stack<T>
    {
        T[] content;
        int top;
        int capacity;
        public ArrayStack(int c)
        {
            capacity = c;
            content = new T [capacity];
            top = -1;
        }
        public int Size()
        { return top + 1; }
        public bool IsEmpty()
        { return top == -1; }
        public void Push(T o)
        {
            if (Size() > capacity) throw new StackFullException();
            top++;
            content[top] = o;
            capacity++;
        }
        public T Pop()
        {
            return content[top--];
        }
        public T Top()
        {
            return content[top];
        }

    }
}
