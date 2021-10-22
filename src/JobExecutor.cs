using session_unlocker.src.Gateway;
using session_unlocker.src.Tasks;

namespace session_unlocker.src {
    class JobExecutor {
        public void checkServer(Job job) {
            IGateway gateway = new GatewayToLinux(job);
            //gateway.close();
        }
    }
}
