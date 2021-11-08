using session_unlocker.src.Tasks;
using System.Collections.Generic;

namespace session_unlocker.src {
    public class RunningObjects {
        public static Queue<Job> jobs = new Queue<Job>();

        public static void setJobs(IDictionary<string, string> settings) {
            if (settings.TryGetValue("Server", out string connectionInfos)) {
                foreach (string connectionInfo in connectionInfos.Split(';')) {
                    string ip = extractIP(connectionInfo);
                    int port = extractPort(connectionInfo);
                    string login = extractLogin(connectionInfo);
                    string password = extractPassword(connectionInfo);
                    jobs.Enqueue(new Job(ip, port, login, password));
                }
            };

            string extractIP(string connectionInfo) {
                return connectionInfo.Substring(0, connectionInfo.IndexOf(":"));
            }

            int extractPort(string connectionInfo) {
                return int.Parse(connectionInfo.Substring(connectionInfo.IndexOf(":") + 1, connectionInfo.IndexOf("[") - connectionInfo.IndexOf(":") - 1));
            }

            string extractLogin(string connectionInfo) {
                return connectionInfo.Substring(connectionInfo.IndexOf("[") + 1, connectionInfo.IndexOf(",") - connectionInfo.IndexOf("[") - 1);
            }

            string extractPassword(string connectionInfo) {
                return connectionInfo.Substring(connectionInfo.IndexOf(",") + 1, connectionInfo.IndexOf("]") - connectionInfo.IndexOf(",") - 1);
            }
        }
    }
}
