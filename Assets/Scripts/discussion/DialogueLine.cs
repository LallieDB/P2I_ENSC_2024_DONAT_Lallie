[System.Serializable]
public class DialogueLine
{
    public string text; // the text of the dialogue line
    public bool hasChoice; //if the player has none or two choices options
    public Choice choice1;
    public Choice choice2;

    public DialogueLine(string text, bool hasChoice, Choice choice1 = null, Choice choice2 = null)
    {
        //verification that there are two choices if the dialogueline is declared as having choices
        if (choice1 == null || choice2 == null)
        {
            hasChoice = false;
        }
        //verification that we don't have more than 2 successive choices
        else if (choice1 != null && choice1.answer.hasChoice == true)
        { // if the first choice has two choices, then those choices don't have choice
            HasChoiceWhenItShouldnt(choice1.answer.choice1);
            HasChoiceWhenItShouldnt(choice1.answer.choice2);
        }
        if (choice2 != null && choice2.answer.hasChoice == true)
        { // if the second choice has two choices, then those choices don't have choice
            HasChoiceWhenItShouldnt(choice2.answer.choice1);
            HasChoiceWhenItShouldnt(choice2.answer.choice2);
        }

        this.text = text;
        this.hasChoice = hasChoice;
        this.choice1 = choice1;
        this.choice2 = choice2;
    }

    public void HasChoiceWhenItShouldnt(Choice choice)
    { //this method take a choice and if this choice has more choice, then those and their following
        // are not selected anymore and a message is display to prevent the programmer than there is a change in his dialogues
        if (choice.answer.hasChoice == true)
        {
            choice.answer.hasChoice = false;
        }
    }
}