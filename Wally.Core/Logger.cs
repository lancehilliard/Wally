using System;

namespace Wally.Core {
    public static class Logger {
        private static Action<string> _messageWriter;

        public static void SetMessageWriter(Action<string> messageWriter) {
            _messageWriter = messageWriter;
        }

        public static void Info(string message) {
            Message("INFO", message);
        }

        public static void Error(string message) {
            Message("ERROR", message);
        }

        static void Message(string level, string message) {
            _messageWriter($"{DateTime.Now:T} {level}: {message}");
        }

        public static void Error(string message, Exception exception) {
            Error($"{message}: {exception}");
        }
    }
}