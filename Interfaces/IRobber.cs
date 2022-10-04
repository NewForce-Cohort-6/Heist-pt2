using System;

namespace heistTheSequel
{
    public interface IRobber
    {
        // A string property for Name
        string Name {get; set;}
        // An integer property for SkillLevel
        int SkillLevel {get; set;}
        // An integer property for PercentageCut
        int PercentageCut {get; set;}

        // Get members type easily
        string Type {get;}  
              // A method called PerformSkill that takes in a Bank parameter and doesn't return anything.
        void PerformSkill (Bank bank);
    }
}

// Each type of robber will have a special skill that will come in handy while knocking over banks. Start by creating an interface called IRobber. The interface should include:
