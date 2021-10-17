using System;
using System.Linq;

namespace session_unlocker
{
    class Program
    {
        static void Main(string[] args) {
            if (args.Length > 0 && args.Contains("-V")) {
                Console.WriteLine(Version.getVersionInfo());
            } else {
                Console.WriteLine("Startujemy...");
            }
        }
    }
}