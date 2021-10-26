using session_unlocker.src.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace session_unlocker.src.Config {
    public class AppConfigReader {
        public static IDictionary<string, string> readParameters(string filepath) {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try {
                foreach (string line in File.ReadAllLines(filepath)) {
                    if (isLineWithParameter(line)) {
                        int index = line.IndexOf('=');
                        string key = line.Substring(0, index).Trim();
                        string value = line.Substring(index + 1).Trim();
                        result.Add(key, value);
                    }
                }
            } catch (Exception e) {
                throw new ConfigurationException(e.Message);
            }
            return result;

            bool isLineWithParameter(string line) {
                if (!string.IsNullOrEmpty(line) &&  !line.StartsWith(";") && !line.StartsWith("#") &&
                    !line.StartsWith("'") && line.Contains("="))
                    return true;
                return false;
            }
        }
    }
}
