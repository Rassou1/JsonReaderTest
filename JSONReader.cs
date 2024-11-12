namespace JsonReaderTest;

using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;  //For .NET use


public class JSONReader
{
    //I need to implement try/catch here just for error handling that won't break the plugin. Will do soon, this just works for now.
    public JSONReader()
	{
        
    }

    public static Dictionary<string, BanRecord> ReadJson(string fileName)
    {
        string jsonContent = File.ReadAllText(fileName);

        var fullDictionary = JsonConvert.DeserializeObject<Dictionary<string, BanRecord>>(jsonContent);

        return fullDictionary;

    }

    public static void SaveBans(Dictionary<string, BanRecord> bans, string jsonFilePath)
    {
        string fileToSave = JsonConvert.SerializeObject(bans, Formatting.Indented);

        File.WriteAllText(jsonFilePath, fileToSave);
    }


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
