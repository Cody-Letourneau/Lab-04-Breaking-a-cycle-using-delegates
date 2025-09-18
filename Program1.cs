using System;
using System.Collections.Generic;

namespace CycleBreakDemo
{
    public class Manager
    {
        private List<Helper> activeHelpers = new List<Helper>();

        public Helper RequestHelp()
        {
            Console.WriteLine("In the Manager: Creating a new Helper and adding it to the active list.");
            Helper h = new Helper(this);
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
        private Manager myMgr;

        public Helper(Manager myMgr)
        {
            Console.WriteLine("In the Helper: Constructor called.");
            this.myMgr = myMgr;
        }

        public void DoWork()
        {
            Console.WriteLine("In the Helper: Doing work as requested.");
        }

        public void Finish()
        {
            Console.WriteLine("In the Helper: About to notify my Manager that I'm done.");
            myMgr.Remove(this);
            Console.WriteLine("In the Helper: Cleanup completed.");
        }
    }

    public class Client
    {
        private Manager mgf;

        public Client(Manager m)
        {
            Console.WriteLine("In the Client: Constructor called with Manager parameter.");
            mgf = m;
        }

        public void Work()
        {
            Console.WriteLine("In the Client: About to request help to my Manager.");
            Helper h = mgf.RequestHelp();

            Console.WriteLine("In the Client: About to ask the Helper to do work.");
            h.DoWork();

            Console.WriteLine("In the Client: About to ask the Helper to finish.");
            h.Finish();

            Console.WriteLine("In the Client: Work completed.");
        }
    }

    class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Object Collaboration");
            Console.WriteLine("==========================================\n");

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