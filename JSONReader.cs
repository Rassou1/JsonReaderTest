namespace JsonReaderTest;

using System;
using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;  //For .NET use
using System.Text.Json;	//For non-.NET use


public class JSONReader
{
    public static JObject wholeJsonFile;
    public static string currentFileName;
    public BanRecord banRecord;
    
    public JSONReader()
	{
        
    }

   /* public static void ReadJson(string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            Console.WriteLine(fileName);
            string steamIDToBan = Console.ReadLine();
            if (steamIDToBan != null)
            {
                GetBanRecord(steamIDToBan, fs);
            }
        }

    }

    public static void GetBanRecord(string steamIDToBan, FileStream fileStream)
    {
        using (JsonDocument banRecordJson = JsonDocument.Parse(fileStream))
        {
            // Find the array of ban records
            JsonElement root = banRecordJson.RootElement;
            JsonElement records = root.GetProperty("records");

            //Look through every record
            foreach (JsonElement record in records.EnumerateArray())
            {
                // Check if the steamID of each record matches the player we're looking for
                string steamID = record.GetProperty("steamID").GetString();
                Console.WriteLine($"{steamID}");
                if (steamID == steamIDToBan)
                {
                    // Deserialize the player
                    BanRecord selectedPlayer = JsonSerializer.Deserialize<BanRecord>(record.GetRawText());

                    // For testing purposes, just printing out the player's info to console for the moment.
                    Console.WriteLine($"ID: {selectedPlayer.PlayerID}, Name: {selectedPlayer.Name}");

                    if (selectedPlayer.Bans != null)
                    {
                        Console.WriteLine("Reasons:");
                        foreach (var reason in selectedPlayer.Bans)
                        {
                            Console.WriteLine($"- {reason.Key}: {reason.Value}");
                        }
                    }
                    break;
                }
            }
        }
    }*/
    //Below are old methods that separated the JSON file's contents into separate strings. Deprecated maybe.


    //Reads the JSON file by using a streamreader. This method is to be called on awake in the ReasonReader class. - Messenger
 //   public static void OldReadJson(string fileName)
	//{
 //       currentFileName = fileName;
 //       StreamReader file = File.OpenText(fileName);
 //       JsonTextReader reader = new JsonTextReader(file);
 //       wholeJsonFile = JObject.Load(reader);
 //   }

    

 //   public static BanRecord OldGetBanRecord(JObject player)
 //   {
 //       //Converts the info in the JSON file into primitive C# types. - Messenger
 //       string id = Convert.ToString(player.GetValue("playerID"));
 //       string name = Convert.ToString(player.GetValue("name"));
 //       int racismBans = Convert.ToInt32(player.GetValue("racismBans"));

 //       //Uses said type to return a ban record.
 //       BanRecord playerBanRecord = new BanRecord(id, name, racismBans);
 //       return playerBanRecord;
 //   }

    
    
}
