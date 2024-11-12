using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;  //For .NET use

namespace JsonReaderTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, BanRecord> banDictionary;
            string filePath = "../../../../JsonReaderTest\\bans.json";
            banDictionary = JSONReader.ReadJson(filePath);

            while (true)
            {
                BanReader.FindPlayer(banDictionary, filePath);
            }
        }
    }
}
