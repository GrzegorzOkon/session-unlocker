namespace session_unlocker.src
{
    class Version
    {
        private static string name = "Session Unlocker";
        private static int major = 1;
        private static int minor = 0;
        private static int release = 2;
        private static string revision = "21 October 2021";

        public static string Info => name + " " + major + "." + minor + "." + release + " (revision " + revision + ")";
    }
}