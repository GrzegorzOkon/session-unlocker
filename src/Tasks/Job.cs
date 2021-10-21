namespace session_unlocker.src.Tasks
{
    public class Job {
        public Job(string ip, int port, string login, string password) {
            Ip = ip;
            Port = port;
            Login = login;
            Password = password;
        }

        public string Ip { get; }
        public int Port { get; }
        public string Login { get; }
        public string Password { get; }
    }
}
