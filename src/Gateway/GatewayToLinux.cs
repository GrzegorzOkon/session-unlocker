using Renci.SshNet;
using Renci.SshNet.Common;
using session_unlocker.src.Tasks;
using System;

namespace session_unlocker.src.Gateway
{
    public class GatewayToLinux : IGateway {
        public GatewayToLinux(Job job) {
            initSession();

            void initSession() {
                KeyboardInteractiveAuthenticationMethod keybAuth = new KeyboardInteractiveAuthenticationMethod(job.Login);
                keybAuth.AuthenticationPrompt += new EventHandler<AuthenticationPromptEventArgs>(HandleKeyEvent);
                var connectionInfo = new ConnectionInfo(job.Ip, job.Login, new AuthenticationMethod[] { keybAuth });

                void HandleKeyEvent(object sender, AuthenticationPromptEventArgs e) {
                    foreach (AuthenticationPrompt prompt in e.Prompts) {
                        if (prompt.Request.IndexOf("Password:", StringComparison.InvariantCultureIgnoreCase) != -1) {
                            prompt.Response = job.Password;
                        }
                    }
                }

                using (var client = new SshClient(connectionInfo)) {
                    client.HostKeyReceived += delegate (object sender, HostKeyEventArgs e) {
                        e.CanTrust = true;
                    };
                    client.Connect();
                    Console.WriteLine("Connected");
                    client.Disconnect();
                    Console.WriteLine("Disconnected");
                }
            }
        }

        //public Session Connection { get; set; }

        public string ExecuteCommand() {
            return null;
        }

        public void close() {
            //Connection.disconnect();
        }
    }
}
