using session_unlocker.src.Tasks;
using System;
using Tamir.SharpSsh.java.util;
using Tamir.SharpSsh.jsch;

namespace session_unlocker.src.Gateway
{
    public class GatewayToLinux : IGateway {
        public GatewayToLinux(Job job) {
            initSession();

            void initSession() {
                /*try {
                    JSch jsch = new JSch();
                    Connection = jsch.getSession(job.Login, job.Ip, job.Port);
                    Hashtable config = new Hashtable();
                    config.put("StrictHostKeyChecking", "no");
                    config.put("PreferredAuthentications", "publickey,keyboard-interactive,password");
                    Connection.setConfig(config);
                    Connection.setPassword(job.Password);
                    Console.WriteLine("Connecting SSH to " + job.Ip + " - Please wait for few seconds... ");
                    Connection.connect();
                    Console.WriteLine("Connected");


                    jsch.setKnownHosts(job.Ip);
                    Session session = jsch.getSession(job.Login, job.Ip, 22);
                    session.setPassword(job.Password);
                    System.Collections.Hashtable hashConfig = new System.Collections.Hashtable();
                    hashConfig.Add("StrictHostKeyChecking", "No");
                    session.setConfig(hashConfig);
                    session.getHostKey();
                    Console.WriteLine("Connecting SSH to " + job.Ip + ", " + job.Login + ", " + job.Password + ", " + job.Port 
                        + " - Please wait for few seconds... ");
                    session.connect();
                    Console.WriteLine("Connected");
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }*/
            }
        }

        public Session Connection { get; set; }

        public string ExecuteCommand() {
            return null;
        }

        public void close() {
            Connection.disconnect();
        }
    }
}
