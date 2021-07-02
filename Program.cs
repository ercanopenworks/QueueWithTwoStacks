using System;
using System.Collections.Generic;

namespace QueueWithTwoStacks
{
    class Program
    {
        public static class MyQue<T>
        {
            private static Stack<T> stackNewestOnTop = new Stack<T>();
            private static Stack<T> stackOldestOnTop = new Stack<T>();

            public static void enque(T value)
            {
                stackNewestOnTop.Push(value);
            }

            public static T deque()
            {
                reverseCopyStack();
                return stackOldestOnTop.Pop();
            }

            public static T peek()
            {
                reverseCopyStack();
                return stackOldestOnTop.Peek();
            }

            private static void reverseCopyStack()
            {
                if (stackOldestOnTop.Count == 0)
                {
                    while (stackNewestOnTop.Count > 0)
                    {
                        stackOldestOnTop.Push(stackNewestOnTop.Pop());
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            
            List<string> listQuery= new List<string>();
            int q = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < q; i++)
            {
                var query = Console.ReadLine();
                if (!string.IsNullOrEmpty(query))
                {
                    listQuery.Add(query);
                }
            }

            for (int i = 0; i < listQuery.Count; i++)
            {
                if (listQuery[i].Length > 1)
                {
                    var item = listQuery[i].Split(" ");
                    var query = item[0];
                    var value = item[1];
                    if (query == "1")
                    {
                        MyQue<string>.enque(value);
                    }
                }
                else 
                {
                    if (listQuery[i] == "2")
                    {
                        MyQue<string>.deque();
                    }
                    else if (listQuery[i] == "3")
                    {
                        Console.WriteLine(MyQue<string>.peek());
                    }
                }
            }
        }
    }
}
