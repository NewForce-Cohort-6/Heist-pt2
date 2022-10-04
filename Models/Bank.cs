using System;
using System.Collections.Generic;
using System.Linq;

namespace heistTheSequel
{
    public class Bank
    {
        // An integer property for CashOnHand
        public int CashOnHand { get; set; }
        // An integer property for AlarmScore
        public int AlarmScore {get; set;}
        // An integer property for VaultScore
        public int VaultScore {get; set;}

        // An integer property for SecurityGuardScore
        public int SecurityGuardScore {get; set;}

        // A computed boolean property called IsSecure. If all the scores are less than or equal to 0, this should be false. If any of the scores are above 0, this should be true
        public bool IsSecure { get {
            if( AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0){
                return true;
            }
            else{
                return false;
            };

        }}

        public void Report() 
        {
            List<KeyValuePair<string, int>> stats = new List<KeyValuePair<string, int>>();
            stats.Add(new KeyValuePair<string, int>("Alarm Score", AlarmScore));
            stats.Add(new KeyValuePair<string, int>("Vault Score", VaultScore));
            stats.Add(new KeyValuePair<string, int>("Security Guard Score", SecurityGuardScore));

            List<KeyValuePair<string, int>> orderStats = stats.OrderBy(x => x.Value).ToList();

            var orderStatsQuery = (
                from stat in stats
                orderby stat.Value 
                select stat
            ).ToList();

            Console.WriteLine("Here's some intel on the bank we're hitting:");
            Console.WriteLine($"Most Secure: {orderStats[2].Key}");
            Console.WriteLine($"Least Secure: {orderStatsQuery[0].Key}");

        }
    }

}
// Knocking over banks isn't going to be easy. Alarms... Vaults... Security Guards.... Each of these safeguards is something we'll have to handle for a successful heist. First things first. Let's create a Bank class to represent the security we're up against. Give the Bank class the following properties:

