using session_unlocker.src.Config;
using session_unlocker.src.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace session_unlocker.src {
    class Program {
        static void Main(string[] args) {
            if (isVersionRequest()) {
                Console.WriteLine(Version.Info);
            } else if (isLoginPresent(out string login)) {
                RunningEnvironment.Login = login;
                IDictionary<string, string> settings = AppConfigReader.ReadFile("./settings/program.config");
                RunningObjects.setJobs(settings);
                Start();
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

        public static void Start() {
            new JobConsument().Start();
        } 
    }
}