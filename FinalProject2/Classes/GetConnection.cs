using FinalProject2.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FinalProject2.DAO_s
{
    public static class GetConnection
    {
      
        private static ConfigJson config;

        static GetConnection()
        {
            string configFile = File.ReadAllText("C:\\Users\\levid\\source\\repos\\FinalProject2\\ConnectionString.json");
            config = JsonConvert.DeserializeObject<ConfigJson>(configFile);
        }
       
        public static string GetTestConn { get { return TestingGetConnection.GetTestConn; } }
        public static string GetConn { get { return config.ConnectionString; } }
       
    }
}
   