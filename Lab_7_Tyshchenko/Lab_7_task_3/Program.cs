using System;
using System.Threading;

namespace Lab_7_task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                LogConflict conflictLog = new LogConflict();

                Thread thread1 = new Thread(() => ExecuteOperations("Thread 1", conflictLog));
                Thread thread2 = new Thread(() => ExecuteOperations("Thread 2", conflictLog));

                thread1.Start();
                thread2.Start();

                thread1.Join();
                thread2.Join();
                
                Console.ReadLine();
            }

            static void ExecuteOperations(string threadId, LogConflict.ConflictLog conflictLog)
            {
                for (int i = 0; i < 5; i++)
                {
                    conflictLog.AddOperation(threadId, $"Operation {i + 1}");
                    Thread.Sleep(100);
                }
            }
        }
    }
}