using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialogueUI;
    public Text nameText;
    public Text dialogueText;
    public Button choice1Button;
    public Button choice2Button;
    public Button nextButton;

    private Dialogue currentDialogue;
    private DialogueLine currentDialogueLine;
    private int currentLineIndex = 0;

    //Allow to use easily DialogueManager method in other scripts
    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance DialogueManager dans la console");
            return;
        }
        instance = this;
    }

    void Start()
    {
        // You can load your dialogue data from an external source (e.g., JSON, XML) or create it programmatically.
        // For simplicity, we'll create a sample dialogue here.
        currentDialogue = CreateSampleDialogue();
        currentDialogueLine = currentDialogue.lines[0];

        // Set up event listeners for buttons
        choice1Button.onClick.AddListener(OnChoice1Selected);
        choice2Button.onClick.AddListener(OnChoice2Selected);
        nextButton.onClick.AddListener(OnNextButtonClicked);

        // Start the dialogue
        StartDialogue();
    }

    public void ChangingDialogue(Dialogue _newdialogue)
    {
        //change the dialogue to read
        currentDialogue = _newdialogue;
        currentDialogueLine = currentDialogue.lines[0];
    }

    public void StartDialogue()
    {
        DialogueUI.SetActive(true); //show the UI interface
        currentLineIndex = 0;
        DisplayLine(currentDialogue.lines[currentLineIndex]); //show the dialogue line by line
    }

    private void DisplayLine(DialogueLine line)
    {
        currentDialogueLine = line;
        nameText.text = currentDialogue.name;
        dialogueText.text = line.text;
        choice1Button.gameObject.SetActive(line.hasChoice); //show the choice button1 if there is a choice
        choice2Button.gameObject.SetActive(line.hasChoice); //show the choice button2 if there is a choice
        nextButton.gameObject.SetActive(!line.hasChoice); //show the next button if there is not a choice
        if (line.hasChoice == true) //set the text of the choice buttons
        {
            choice1Button.GetComponentInChildren<Text>().text = line.choice1.text;
            choice2Button.GetComponentInChildren<Text>().text = line.choice2.text;
        }
    }

    private void OnNextButtonClicked()
    {
        // if the next button is played, show the following line
        currentLineIndex++;
        if (currentLineIndex < currentDialogue.lines.Length)
        {
            DisplayLine(currentDialogue.lines[currentLineIndex]);
        }
        else
        {
            // Dialogue is over
            EndDialogue();
        }
    }

    private void OnChoice1Selected()
    {
        currentDialogueLine.choice1.isChosen = true; //set that the choice 1 is chosen
        HandleChoice(currentDialogueLine.choice1); //continue the dialogue
    }

    private void OnChoice2Selected()
    {
        currentDialogueLine.choice2.isChosen = true; //set that the choice 2 is chosen
        HandleChoice(currentDialogueLine.choice2); //continue the dialogue
    }

    private void HandleChoice(Choice choice)
    {
        // Handle the chosen choice (e.g., change variables, trigger events)
        Debug.Log("Selected Choice: " + choice.text);
        // Advance to the line of the selected choice
        DisplayLine(choice.answer);
    }

    public void EndDialogue()
    {
        // Close the UI dialogue
        Debug.Log("End of Dialogue");
        DialogueUI.SetActive(false);
    }

    // First dialogue
    private Dialogue CreateSampleDialogue()
    {
        //Initialize the first dialogue
        Dialogue dialogue = new Dialogue();
        dialogue.name = "Narrator";

        dialogue.lines = new DialogueLine[]
        {
            new DialogueLine("Hello there! What are you still doing there ?", false),
            new DialogueLine(
                "Humans are coming ! You should run !",
                true,
                new Choice(
                    "I can't fly...",
                    new DialogueLine(
                        "Find some or you're gonna die !",
                        true,
                        new Choice(
                            "I don't wanna die",
                            new DialogueLine(
                                "That's pretty commun. But you should be aware that humans LOVE dodo.",
                                false
                            )
                        ),
                        new Choice(
                            "I wanna die",
                            new DialogueLine(
                                "That's original. I suppose you should be happy, then.",
                                true,
                                new Choice(
                                    "I am unique",
                                    new DialogueLine(
                                        "Fine. I suppose you should be happy, then.",
                                        false
                                    )
                                ),
                                new Choice(
                                    "I am so sad...",
                                    new DialogueLine(
                                        "Oh....... Well, I guess it doesn't matter to you, but...",
                                        true,
                                        new Choice("hhh", new DialogueLine("eeee", false)),
                                        new Choice("22", new DialogueLine("222", false))
                                    )
                                )
                            )
                        )
                    )
                ),
                new Choice(
                    "I want to stay here",
                    new DialogueLine(
                        "That's okay. But you should be aware that humans LOVE dodo.",
                        false
                    )
                )
            ),
            new DialogueLine("Humans EAT dodo.", false),
        };
        return dialogue;
    }
}

//Implementation of the classes of this system

[System.Serializable]
public class Dialogue
{
    public string name;
    public DialogueLine[] lines;
}

[System.Serializable]
public class DialogueLine
{
    public string text;
    public bool hasChoice;
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
            Debug.Log(
                "A dialogue choice is not selectable to avoid surcharging the system. Consider changing your dialoguelines"
            );
        }
    }
}

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
