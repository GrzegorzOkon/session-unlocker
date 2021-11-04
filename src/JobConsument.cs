using session_unlocker.src.Tasks;

namespace session_unlocker.src {
    class JobConsument {
        public void Start() {
            while (RunningObjects.jobs.Count > 0) {
                Job job = RunningObjects.jobs.Dequeue();
                new JobExecutor().CheckServer(job);
            }
        } 
    }
}
