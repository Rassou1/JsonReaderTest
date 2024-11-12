namespace JsonReaderTest;

using System;

public enum BanType { Sabotage, Racism, Sexism, Cheating }
public class BanRecord
{
    
    
    public Dictionary<BanType, int> Bans { get; set; }
    //Uses enum here instead of strings for better consistency between bans + easier searching.
    
    public string Name { get; set; }
    //Implement later, will work now with just ID
    
    public string PlayerID { get; set; }

    public BanRecord(string playerID) 
    {
        this.PlayerID = playerID;
        Bans = new Dictionary<BanType, int>();
    }

}
