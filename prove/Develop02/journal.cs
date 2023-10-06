//THIS CLASS IS A JOURNAL CLASS.
public class Journal{
    //vairiable are shows response from user

    private List<Entry> _entries = new List<Entry>();

    //create a method that adds to the journal list
    public void AddEntry()
    {
        Entry entry = new Entry();
        _entries.Add(entry);

    }
    public class PromptRandomizer
    {
            //create instance for this class to select randoms
    

             //create list of choices
        public List<string> _prompts = new List<string>
        {
        "What was the most asked question today?",
        "Did i complete my step count today as part of exercie program?",
        "Did i pray and read my scriptures?",
        "How much did i spend today?",
        "Did anyone talk to me and made my day?"
        };

    //use random to select from the list
        public string ChoosePrompt()
        {
            Random random = new Random();
            int i = random.Next(_prompts.Count);
            return _prompts[i];
        }
    }
}
