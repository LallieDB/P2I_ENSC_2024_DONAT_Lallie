[System.Serializable]
public class Choice
{
    public string text; // the text of the chosen option
    public bool isChosen; // if the option is chosen vy the player
    public DialogueLine answer; //the next line if you choose this choice

    public Choice(string text, DialogueLine answer)
    {
        this.text = text;
        this.answer = answer;
        isChosen = false;
    }
}
