using System;
using System.Linq;

namespace session_unlocker
{
    class Program
    {
        static void Main(string[] args) {
            if (isVersionRequest()) {
                Console.WriteLine(Version.Info);
            } else if (isLoginPresent(out string login)) {
                Environment.Login = login;
                Console.WriteLine("Startujemy...");
            } else {
                Console.WriteLine("Brak loginu. Parametr wymagany. Dodaj przełącznik -l lub -login z wartością.");
            }

            bool isVersionRequest() {
                if (args.Length > 0 && args.Contains("-V"))
                    return true;
                return false;
            }

            bool isLoginPresent(out string login) {
                login = null;
                for (int i = 0; i < args.Length; i++) {
                    if (args[i].StartsWith("-l") && i + 1 < args.Length) {
                        login = args[i + 1];
                        return true;
                    }
                }
                return false;
            }
        }
    }
}