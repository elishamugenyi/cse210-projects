using System;
using System.Collections.Generic;

//create a class for prompt randoms.

public class PromptGeneration
{
    //create instance for this class to select randoms
    

    //create list of choices
    private List<string> Prompts {get; set;} = new List<string>();
    private int CurrentIndex {get; set;} = 0;

        //method to initialize and set prompts
    public PromptGeneration()
    {
            
        Prompts.Add("What was the most asked question today?");
        Prompts.Add("Did i complete my step count today as part of exercie program?");
        Prompts.Add("Did i pray and read my scriptures?");
        Prompts.Add("How much did i spend today?");
        Prompts.Add("Did anyone talk to me and made my day?");
    }

    //use random to select from the list
    public string ChoosePrompt()
    {
        if (CurrentIndex < Prompts.Count)
        {
            string prompt = Prompts[CurrentIndex];
            CurrentIndex++;
            return prompt;
        }
        else
        {
            CurrentIndex = 0;
            return ChoosePrompt();
        }
    }
}