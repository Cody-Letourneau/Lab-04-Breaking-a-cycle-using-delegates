using System;
using System.Collections.Generic;

namespace NoCycle
{
    public delegate void RemoveMethod(Helper h);

    public class Manager
    {
        private List<Helper> activeHelpers = new List<Helper>();

        public Helper RequestHelp()
        {
            Console.WriteLine("In the Manager: Creating a new Helper and adding it to the active list.");
            Helper h = new Helper(Remove);
            activeHelpers.Add(h);
            Console.WriteLine("In the Manager: Returning the Helper to the Client.");
            return h;
        }

        public void Remove(Helper h)
        {
            Console.WriteLine("In the Manager: Removing the Helper from the active list.");
            activeHelpers.Remove(h);
            Console.WriteLine("In the Manager: Helper removed successfully.");
        }
    }

    public class Helper
    {
        private RemoveMethod removeMethod;

        public Helper(RemoveMethod whenDone)
        {
            Console.WriteLine("In the Helper: Constructor called with RemoveMethod delegate.");
            removeMethod = whenDone;
        }

        public void DoWork()
        {
            Console.WriteLine("In the Helper: Doing work as requested.");
        }

        public void Finish()
        {
            Console.WriteLine("In the Helper: About to notify via delegate that I'm done.");
            removeMethod(this);
            Console.WriteLine("In the Helper: Cleanup completed.");
        }
    }

    public class Client
    {
        private Manager mgr;

        public Client(Manager manager)
        {
            Console.WriteLine("In the Client: Constructor called with Manager parameter.");
            mgr = manager;
        }

        public void Work()
        {
            Console.WriteLine("In the Client: About to request help to my Manager.");
            Helper h = mgr.RequestHelp();

            Console.WriteLine("In the Client: About to ask the Helper to do work.");
            h.DoWork();

            Console.WriteLine("In the Client: About to ask the Helper to finish.");
            h.Finish();

            Console.WriteLine("In the Client: Work completed.");
        }
    }

    class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegate Pattern Showcase");
            Console.WriteLine("==========================================================================\n");

            Console.WriteLine("Creating Manager object...");
            Manager manager = new Manager();

            Console.WriteLine("Creating Client object and passing Manager...");
            Client client = new Client(manager);

            Console.WriteLine("\nCalling Client's Work method:");
            Console.WriteLine("------------------------------");
            client.Work();

            Console.WriteLine("\nProgram completed successfully.");
            Console.ReadLine();
        }
    }
}