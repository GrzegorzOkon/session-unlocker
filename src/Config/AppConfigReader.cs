﻿using session_unlocker.src.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace session_unlocker.src.Config {
    public class AppConfigReader {
        public static IDictionary<string, string> ReadFile(string filepath) {
            IDictionary<string, string> result = null;
            try {
                result = ReadParameters(filepath);
                Validate(result);
            } catch (Exception e) {
                throw new ConfigurationException(e.Message);
            }
            return result;
        }

        private static IDictionary<string, string> ReadParameters(string filepath) {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try {
                foreach (string line in File.ReadAllLines(filepath)) {
                    if (IsLineWithParameter(line)) {
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

            bool IsLineWithParameter(string line) {
                if (!string.IsNullOrEmpty(line) &&  !line.StartsWith(";") && !line.StartsWith("#") &&
                    !line.StartsWith("'") && line.Contains("="))
                    return true;
                return false;
            }
        }

        private static void Validate(IDictionary<string, string> parameters) {
            ValidateServer(parameters);
        }

        public static void ValidateServer(IDictionary<string, string> parameters) {
            if (parameters.TryGetValue("Server", out string ConnectionInfo)) {
                foreach (string ci in ConnectionInfo.Split(';')) {
                    if (IsIPAbsent(ci)) {
                        Environment.Exit(101);
                    } 
                }
            } else {
                Environment.Exit(101);
            }

            bool IsIPAbsent(string ConnInfo) {
                if (ConnInfo.Contains(":") && ConnInfo.Substring(0, ConnInfo.IndexOf(":")).Length > 0) return false;
                return true;
            }
        }
    }
}
