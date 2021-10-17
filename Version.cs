namespace session_unlocker
{
    class Version {
        private static string name = "Session Unlocker";
        private static int major = 1;
        private static int minor = 0;
        private static int release = 0;
        private static string revision = "17 October 2021";

        public static string getVersionInfo() {
            return name + " " + major + "." + minor + "." + release + " (revision " + revision + ")";
        }
    }
}