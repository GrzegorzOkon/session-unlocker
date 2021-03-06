namespace session_unlocker.src
{
    class Version
    {
        private static readonly string name = "Session Unlocker";
        private static readonly int major = 1;
        private static readonly int minor = 0;
        private static readonly int release = 8;
        private static readonly string revision = "08 November 2021";

        public static string Info => name + " " + major + "." + minor + "." + release + " (revision " + revision + ")";
    }
}