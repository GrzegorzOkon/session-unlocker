using System;

namespace session_unlocker.src.Exceptions {
    class ConfigurationException : Exception {
        public ConfigurationException() {}
        public ConfigurationException(string message) : base(message) {}
        public ConfigurationException(string message, Exception inner) : base(message, inner) {}
    }
}
