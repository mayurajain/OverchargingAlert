using FluentScheduler;
using System;
using System.Threading;

namespace OverchargingAlert
{
    class Program
    {
        static void Main(string[] args)
        {
            //Visual display of Console
            ConsoleContents();
            //Thread to call background method to schedule battery percentage checks
            new Thread(() => Background()).Start();
            Console.ReadLine();
        }
        private static void ConsoleContents()
        {
            #region Contents to display on console
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                          Warning                                                    ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            string title = @"                                               Please dont close this window.....
                        This is a automatic alert generator for avoiding overcharging of battery";

            Console.WriteLine(title);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Version:        v1.0");
            Console.WriteLine("     Developer:      Mayur Jain");
            Console.WriteLine();
            #endregion
        }

        //To Schedule battery percentage checks
        public static void Background()
        {
            JobManager.Initialize(new MyRegistry());
        }
    }
}
