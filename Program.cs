using System;
using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;  //For .NET use
using System.Text.Json;	//For non-.NET use

namespace JsonReaderTest
{
    internal class Program
    {
        public static JSONReader newReader = new JSONReader();
        public static string targetID;
        static void Main(string[] args)
        {
            string jsonFilePath = "TestJson.json";
            int targetId = 1;

            using (FileStream fs = new FileStream(jsonFilePath, FileMode.Open, FileAccess.Read))
            {
                using (JsonDocument doc = JsonDocument.Parse(fs))
                {
                    // Navigate to the "items" array
                    JsonElement root = doc.RootElement;
                    JsonElement items = root.GetProperty("items");

                    // Iterate through each item in the array
                    foreach (JsonElement itemElement in items.EnumerateArray())
                    {
                        // Check the "id" property of each item
                        int id = itemElement.GetProperty("id").GetInt32();
                        if (id == targetId)
                        {
                            // Deserialize the matched item into a BanRecord object
                            BanRecord selectedBanRecord = JsonSerializer.Deserialize<BanRecord>(itemElement.GetRawText());

                            // Display the selected BanRecord's details
                            Console.WriteLine($"PlayerID: {selectedBanRecord.PlayerID}, Name: {selectedBanRecord.Name}");

                            // Display bans (if present)
                            if (selectedBanRecord.Bans != null)
                            {
                                Console.WriteLine("Bans:");
                                foreach (var ban in selectedBanRecord.Bans)
                                {
                                    Console.WriteLine($"- {ban.Key}: {ban.Value}");
                                }
                            }

                            break; // Exit the loop once the matching item is found
                        }
                    }
                }
            }
        
    }
    }
}
