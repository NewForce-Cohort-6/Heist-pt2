using System;
using System.Collections.Generic;
using System.Linq;

namespace heistTheSequel
{
    class Program
    {
        static void Main(string[] args)
        {


            Hacker Sarah = new Hacker()
            {
                Name = "Sarah",
                SkillLevel = 40,
                PercentageCut = 35
            };
            Hacker Allison = new Hacker()
            {
                Name = "Allison",
                SkillLevel = 35,
                PercentageCut = 20
            };
            LockSpecialist Steve = new LockSpecialist()
            {
                Name = "Steve",
                SkillLevel = 100,
                PercentageCut = 35
            };
            LockSpecialist Phil = new LockSpecialist()
            {
                Name = "Phil",
                SkillLevel = 100,
                PercentageCut = 35
            };
            Muscle Sam = new Muscle()
            {
                Name = "Sam",
                SkillLevel = 100,
                PercentageCut = 35
            };

            List<IRobber> rolodex = new List<IRobber>(){
                Sarah, Allison, Sam, Phil, Steve
            };


            Console.WriteLine("Let's Plan a Heist!");
            while (true)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine($"There are currently {rolodex.Count} operatives in the rolodex.");
                Console.WriteLine("Add a new operative:");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name)) // or (name == "")
                {
                    break;
                }
                string speciality = "";
                while (true)
                {
                    Console.WriteLine("Choose a Speciality:");
                    Console.WriteLine("--------------");
                    Console.WriteLine("1) Hacker");
                    Console.WriteLine("2) Lock Pick Specialist:");
                    Console.WriteLine("3) Muscle");

                    speciality = Console.ReadLine();

                    if (speciality == "1" || speciality == "2" || speciality == "3")
                    {
                        break;
                    }
                }
                Console.WriteLine($"----------");

                Console.WriteLine($"Enter {name}'s skill Level ");
                Console.WriteLine($"1-100");
                int skillLevel = int.Parse(Console.ReadLine());
                Console.WriteLine($"----------");
                Console.WriteLine($"Enter {name}'s percentage cut");
                int cut = int.Parse(Console.ReadLine());

                if (speciality == "1")
                {
                    Hacker newMember = new Hacker()
                    {
                        Name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = cut
                    };
                    rolodex.Add(newMember);
                }
                else if (speciality == "2")
                {
                    LockSpecialist newMember = new LockSpecialist()
                    {
                        Name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = cut
                    };
                    rolodex.Add(newMember);
                }
                else if (speciality == "3")
                {
                    Muscle newMember = new Muscle()
                    {
                        Name = name,
                        SkillLevel = skillLevel,
                        PercentageCut = cut
                    };
                    rolodex.Add(newMember);
                }
            }

            Bank heistTarget = new Bank()
            {
                AlarmScore = new Random().Next(0, 101),
                VaultScore = new Random().Next(0, 101),
                SecurityGuardScore = new Random().Next(0, 101),
                CashOnHand = new Random().Next(50000, 1000001),
            };

            heistTarget.Report();
            List<IRobber> crew = new List<IRobber>();
            int currentCutCapacity = 0;
            Console.WriteLine("************************************");
            Console.WriteLine("Let's build a crew!");

            while(true){
            Console.WriteLine("-------------------");


            for (int i = 0; i < rolodex.Count; i++)
            {
                if(!crew.Contains(rolodex[i]) && currentCutCapacity + rolodex[i].PercentageCut < 90){
                Console.WriteLine($"Operative #{i + 1}");
                Console.WriteLine($"Name: {rolodex[i].Name}");
                Console.WriteLine($"Speciality: {rolodex[i].Type}");
                Console.WriteLine($"Skill Level: {rolodex[i].SkillLevel}");
                Console.WriteLine($"Cut: {rolodex[i].PercentageCut}");
                Console.WriteLine("------------------");
                }
            };

            Console.WriteLine("Select a new crew member:");
            string selection = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(selection)) // or (name == "")
                {
                    break;
                }

            crew.Add(rolodex[int.Parse(selection) - 1]);

            currentCutCapacity = crew.Sum(x => x.PercentageCut);
            Console.WriteLine(currentCutCapacity);
            }
                Console.WriteLine("**--------------------**");
                Console.WriteLine("Let the heist begin!!");

                crew.ForEach( member => member.PerformSkill(heistTarget));

                if(heistTarget.IsSecure)
                {
                    Console.WriteLine("Too bad, the heist was a failure!");

                }
                else
                {
                    Console.WriteLine("Congrats, the heist was a success!");

                    int totalTake = heistTarget.CashOnHand;
                    crew.ForEach(member => {
                    Console.WriteLine($"{member.Name} took home ${(heistTarget.CashOnHand * member.PercentageCut) /100}");

                    totalTake -= ((heistTarget.CashOnHand * member.PercentageCut) / 100);

                    });
                    Console.WriteLine($"We made ${totalTake} profit on this heist.");

                }




        }
    }
}






//  Each crew member should perform his/her skill on the bank. Afterwards, evaluate if the bank is secure. If not, the heist was a success! Print out a success message to the user. If the bank does still have positive values for any of its security properties, the heist was a failure. Print out a failure message to the user.

// If the heist was a success, print out a report of each members' take, along with how much money is left for yourself.
