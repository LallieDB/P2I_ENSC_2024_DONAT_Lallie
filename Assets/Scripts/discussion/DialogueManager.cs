using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class DialogueManager : MonoBehaviour
{
    public GameObject DialogueUI;
    public Text nameText;
    public Text dialogueText;
    public Button choice1Button;
    public Button choice2Button;
    public Button nextButton;

    private Dialogue currentDialogue;
    private int currentLineIndex = 0;

    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance DialogueManager dans la console");
            return;
        }
        instance=this;
    }

    void Start()
    {
        // You can load your dialogue data from an external source (e.g., JSON, XML) or create it programmatically.
        // For simplicity, we'll create a sample dialogue here.
        currentDialogue = CreateSampleDialogue();

        // Set up event listeners for buttons
        choice1Button.onClick.AddListener(OnChoice1Selected);
        choice2Button.onClick.AddListener(OnChoice2Selected);
        nextButton.onClick.AddListener(OnNextButtonClicked);

        // Start the dialogue
        StartDialogue();
    }

    public void ChangingDialogue(Dialogue _newdialogue)
    {
        currentDialogue=_newdialogue;
    }

    public void StartDialogue()
    {
        DialogueUI.SetActive(true);
        currentLineIndex = 0;
        DisplayLine(currentDialogue.lines[currentLineIndex]);
    }

    private void DisplayLine(DialogueLine line)
    {
        nameText.text=currentDialogue.name;
        dialogueText.text = line.text;
        choice1Button.gameObject.SetActive(line.hasChoice);
        choice2Button.gameObject.SetActive(line.hasChoice);
        nextButton.gameObject.SetActive(!line.hasChoice);
        if (line.hasChoice==true)
        {
            choice1Button.GetComponentInChildren<Text>().text = currentDialogue.lines[currentLineIndex].choice1.text;
            choice2Button.GetComponentInChildren<Text>().text = currentDialogue.lines[currentLineIndex].choice2.text;
        }
        

    }

    private void OnNextButtonClicked()
    {
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
        HandleChoice(currentDialogue.lines[currentLineIndex].choice1);
    }

    private void OnChoice2Selected()
    {
        HandleChoice(currentDialogue.lines[currentLineIndex].choice2);
    }

    private void HandleChoice(Choice choice)
    {
        // Handle the chosen choice (e.g., change variables, trigger events)
        Debug.Log("Selected Choice: " + choice.text);

        // Advance to the next line
        // currentLineIndex++;
        // if( choice.firstChoice==false)
        //     currentLineIndex++;
        DisplayLine(choice.answer);
    }

    public void EndDialogue()
    {
        // Reset the dialogue UI or close the dialogue box
        Debug.Log("End of Dialogue");
        DialogueUI.SetActive(false);

    }

    // Sample dialogue data (you can replace this with loading from an external source)
    private Dialogue CreateSampleDialogue()
    {
        Dialogue dialogue = new Dialogue();
        dialogue.name= "Narrator";

        dialogue.lines = new DialogueLine[]
        {
            new DialogueLine("Hello there! What are you still doing there ?", false),
            new DialogueLine("Humans are coming ! You should run !", true, new Choice("I can't fly...",new DialogueLine("Find some or you're gonna die !", false)), new Choice("I want to stay here", new DialogueLine("That's okay. But you should be aware that humans LOVE dodo.", false))),
            // new DialogueLine("Find some or you're gonna die !", false),
            // new DialogueLine("That's okay. But you should be aware that humans LOVE dodo.", false),
            new DialogueLine("Humans EAT dodo.", false)
        };

        return dialogue;
    }
}

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
        this.text = text;
        this.hasChoice = hasChoice;
        this.choice1 = choice1;
        this.choice2 = choice2;
    }
}

[System.Serializable]
public class Choice
{
    public string text;
    public bool firstChoice;
    public DialogueLine answer;

    public Choice(string text, bool firstChoice)
    {
        this.text = text;
        this.firstChoice=firstChoice;
    }
    public Choice(string text, DialogueLine answer)
    {
        this.text = text;
        this.answer=answer ;
    }
}
