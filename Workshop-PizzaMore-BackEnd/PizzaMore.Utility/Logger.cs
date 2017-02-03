using System;
using System.IO;
using System.Net;

namespace PizzaMore.Utility
{
    public static class Logger
    {
        public static void Log(string message)
        {
            File.AppendAllText(@"Logs/log.txt", message + Environment.NewLine);
        }
    }
}