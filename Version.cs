namespace session_unlocker
{
    class Version {
        private static string name = "Session Unlocker";
        private static int major = 1;
        private static int minor = 0;
        private static int release = 1;
        private static string revision = "18 October 2021";

        public static string Info => name + " " + major + "." + minor + "." + release + " (revision " + revision + ")";
    }
}