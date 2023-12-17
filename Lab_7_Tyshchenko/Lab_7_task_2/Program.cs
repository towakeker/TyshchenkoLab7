using System;
using System.Threading;

namespace Lab_7_task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                int resourceCount = 5;
                ResourceManager resourceManager = new ResourceManager(resourceCount);

                for (int i = 0; i < 10; i++)
                {
                    int threadId = i;
                    Thread thread = new Thread(() =>
                    {
                        Resource acquiredResource = resourceManager.AcquireResource(threadId);
                        if (acquiredResource != null)
                        {
                            Console.WriteLine($"Thread {threadId} acquired resource {acquiredResource.Id}");
                            Thread.Sleep(1000);
                            Console.WriteLine($"Thread {threadId} released resource {acquiredResource.Id}");
                            resourceManager.ReleaseResource(acquiredResource);
                        }
                    });

                    thread.Start();
                }
            }
        }
    }
}