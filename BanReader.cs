using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonReaderTest
{
    internal class BanReader
    {
        //Using console here just to get it to work.
        //Also need to implement more try catches for error handling. For now it works.
        public static void FindPlayer(Dictionary<string, BanRecord> bans, string filePath)
        {
            Console.WriteLine("Who we banning today");
            string input = Console.ReadLine();

            if(bans.ContainsKey(input))
            {
                ViewRecord(bans, filePath, input);
                Console.WriteLine("Bro is now banned");
            }
            else
            {
                Console.WriteLine(input + "isn't real");
                return;
                //Insert code to handle wrong ID.
            }
        }

        private static void ViewRecord(Dictionary<string, BanRecord> bans, string filePath, string input)
        {
            Console.WriteLine("Why are we banning bro");
            string ban = Console.ReadLine();

            if(!Enum.TryParse(ban, out BanType banType))
            {
                Console.WriteLine("Ban does not exist. Try again.");
                ViewRecord(bans, filePath, input);
                //Probably extremely inefficient, but this is the only way I could think of to make a convenient way to view a record
                //again without restarting from 0.
                return;
            }

            string addedBans = Console.ReadLine();
            int? addedBansInt = GetValidInteger(addedBans);
            //Gets a number of bans from the user, then turns it to an int

            BanRecord banRecord = bans[input];
            //Find the player dictionary from the dictionary with all the players in it

            if (banRecord.Bans.ContainsKey(banType))
            {
                Console.WriteLine("How many times we banning bro");
                banRecord.Bans[banType] += addedBansInt.Value;
                //We just add to the bans. Default is always 0. Yippee.
            }

            Console.WriteLine($"Bro {input} has been banned for {banType} {addedBansInt} times"); 

            JSONReader.SaveBans(bans, filePath);
            //Updates the JSON file
        }

        private static int? GetValidInteger(string userInput)
        {
            if (!int.TryParse(userInput, out int result))
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid integer");
                return null;
            }
            return result;
            //Big ups to my boy, i stole this method from him.
        }
    }


}
