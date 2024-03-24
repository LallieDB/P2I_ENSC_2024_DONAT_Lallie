[System.Serializable]
public class Choice
{
    public string text;
    public bool isChosen;
    public DialogueLine answer;

    public Choice(string text, DialogueLine answer)
    {
        this.text = text;
        this.answer = answer;
        isChosen = false;
    }
}
