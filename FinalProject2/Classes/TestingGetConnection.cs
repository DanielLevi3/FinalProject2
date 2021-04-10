using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FinalProject2.Classes
{
   public static class TestingGetConnection
    {
          
        private static ConfigJson config;

            static TestingGetConnection()
            {
                string configFile = File.ReadAllText("C:\\Users\\levid\\source\\repos\\FinalProject2\\TestingConnectionString.json");
                config = JsonConvert.DeserializeObject<ConfigJson>(configFile);
            }
            public static string GetTestConn { get { return config.ConnectionString; } }
         
        }
    }
    

