using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatternSamples
{
    internal class SingletonPattern
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Thread-Safe Singleton Pattern");

            // Create multiple threads to test thread safety
            var tasks = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    var instance = SingletonThreadSafe.Instance;
                    Console.WriteLine($"Thread {Task.CurrentId}: {instance.GetInstanceInfo()}");
                    Thread.Sleep(100); // Simulate some work
                }));
            }

            // Wait for all threads to complete
            Task.WaitAll(tasks.ToArray());

            // Verify instance equality
            var instance1 = SingletonThreadSafe.Instance;
            var instance2 = SingletonThreadSafe.Instance;

            Console.WriteLine($"\nInstance Equality Check:");
            Console.WriteLine($"Instance1 HashCode: {instance1.GetHashCode()}");
            Console.WriteLine($"Instance2 HashCode: {instance2.GetHashCode()}");
            Console.WriteLine($"Are instances equal: {ReferenceEquals(instance1, instance2)}");
        }
    }
    // Singleton Pattern = Static + Thread Safe + Lazy Loading + Performance
    public class Singleton  // 1. Single class whole part
    {
        //2. Thread safety
        public static readonly object lockObject = new object();

        //3. Private constructor to prevent external instantiation
        private Singleton()
        {
            
        }
        private static Singleton _instance; //1.Single class whole part

    }
    public sealed class SingletonThreadSafe
    {
        // Private static instance - will hold the single instance
        private static SingletonThreadSafe _instance;

        // Object for thread synchronization
        private static readonly object _lockObject = new object();

        // Some example data
        private readonly DateTime _created;
        private int _counter;

        // Private constructor ensures no external instantiation
        private SingletonThreadSafe()
        {
            _created = DateTime.Now;
            _counter = 0;
        }

        // Public property for accessing the singleton instance
        public static SingletonThreadSafe Instance
        {
            get
            {
                //Aim is the single instance should be shared by all the threads
                // First check - not thread safe but prevents unnecessary locking
                if (_instance == null)
                {
                    // Lock for thread safety
                    lock (_lockObject)
                    {
                        // Second check - ensures only one instance is created
                        if (_instance == null)
                        {
                            _instance = new SingletonThreadSafe();
                        }
                    }
                }
                return _instance;
            }
        }

        // Example business method
        public string GetInstanceInfo()
        {
            _counter++;
            return $"Instance created at: {_created}, Access count: {_counter}";
        }
    }
}
