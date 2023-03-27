using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Label = UnityEngine.UIElements.Label;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class BattlManager : MonoBehaviour
{
    [Header("Dialogue Box UI")]
    [SerializeField] UIDocument dialoguePanel;
    private static BattlManager instance;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private Story currentStory;
    private string[] choicesText;
    public bool dialogueIsPlaying { get; private set; }

    //public VisualElement nameBox;
    //public Label nameText;
    public Button messageBox;
    bool isTyping = false;
    bool missionInProgress = false;

    public Button choice1;
    public Button choice2;
    public Button choice3;
    public Button choice4;

    //currentStory.TagsForContentAtPath("your_knot") ... calling a certain knot in story
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple instances of DialogueManager...");
        }
        instance = this;

       //BattlManager.GetInstance().EnterDialogueMode(inkJSON);
    }

    private void OnEnable()
    {
        var root = dialoguePanel.rootVisualElement;

        messageBox = root.Q<Button>("battleBox");
        Debug.Log(messageBox);



        choice1 = root.Q<Button>("Option1");
        choice2 = root.Q<Button>("Option2");
        choice3 = root.Q<Button>("Option3");
        choice4 = root.Q<Button>("Option4");


        //choice1.style.opacity.ps


        if (!dialogueIsPlaying)
        {
            //when messagebox clicked, set chatbox
            choice1.RegisterCallback<ClickEvent>(ev => makeChoice(0));
            choice2.RegisterCallback<ClickEvent>(ev => makeChoice(1));
            choice3.RegisterCallback<ClickEvent>(ev => makeChoice(2));
            choice4.RegisterCallback<ClickEvent>(ev => makeChoice(3));
        }


        //when messagebox clicked, set chatbox
        if (!isTyping)
            messageBox.RegisterCallback<ClickEvent>(ev => ContinueStory());

        EnterDialogueMode(inkJSON);
    }
    void makeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        // instance.currentStory.currentChoices.Clear();
        instance.ContinueStory();
    }
    public static BattlManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        messageBox.visible = true;
        hideAll();

        isTyping = false;

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        if (!isTyping)
        {
            currentStory = new Story(inkJSON.text);
            //nameText.text = (string)currentStory.variablesState["charName"];
            StartCoroutine(fadeInChat());
            dialogueIsPlaying = true;

            //currentStory.variablesState["classTime"] = missionManager.classTime;
            inkMethodSetting();

            StartCoroutine(TypeSentence(currentStory.Continue()));
        }
    }

    private void ContinueStory()
    {
        if (!isTyping)
        {
            if (currentStory.canContinue)
            {
                StartCoroutine(TypeSentence(currentStory.Continue()));
            }
            //else
                //StartCoroutine(fadeOutChat());
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        //StopAllCoroutines()
        //nameText.text = (string)currentStory.variablesState["charName"];
        isTyping = true;
        messageBox.text = "";
        foreach (char character in sentence.ToCharArray())
        {
            messageBox.text += character;
            yield return new WaitForSeconds(0.01f); //adds delay between displaying characters
        }

        isTyping = false;
        DisplayChoices();
    }

    IEnumerator fadeInChat()
    {
        messageBox.visible = true;

        isTyping = true;

        messageBox.style.opacity = 0.0f;
        for (float i = 0.0f; i <= 1.0f; i += 0.01f)
        {
            messageBox.style.opacity = i;
            yield return new WaitForSeconds(0.01f); //adds delay between displaying characters
        }
        isTyping = false;


    }

    /*IEnumerator fadeOutChat()
    {
        dialogueIsPlaying = false;
        for (float i = 1f; i > 0f; i -= 0.1f)
        {
            //nameBox.style.opacity = i;
            messageBox.style.opacity = i;
            yield return new WaitForSeconds(0.05f); //adds delay between displaying characters
        }
        messageBox.visible = false;
        //nameText.visible = false;
       // nameBox.visible = false;

    }*/

    private void DisplayChoices()
    {
        if (currentStory.currentChoices.Count == 0)
            return;
        //FindObjectOfType<ChoiceOverlay>().DisplayChoices(currentStory.currentChoices);
        ShowBubbles(currentStory.currentChoices);
        Debug.Log("There are currently " + currentStory.currentChoices.Count + " choices");
        StartCoroutine(SelectFirstChoice());
    }
    public static void MakeChoice(int choiceIndex)
    {
        Debug.Log("Selected choice " + choiceIndex);
        FindObjectOfType<ChoiceOverlay>().hideAll();


        instance.currentStory.ChooseChoiceIndex(choiceIndex);
        instance.ContinueStory();
    }
    void ShowBubbles(List<Choice> currentChoices)
    {
        if (currentChoices.Count == 1)
            DisplayChoices(currentChoices[0].text);
        else if (currentChoices.Count == 2)
            DisplayChoices(currentChoices[0].text, currentChoices[1].text);
        else if (currentChoices.Count == 3)
            DisplayChoices(currentChoices[0].text, currentChoices[1].text, currentChoices[2].text);
        else if (currentChoices.Count == 4)
            DisplayChoices(currentChoices[0].text, currentChoices[1].text, currentChoices[2].text, currentChoices[3].text);
        else
            Debug.Log("There were " + currentChoices.Count + " number of choices which is invalid");
    }
    private IEnumerator SelectFirstChoice()
    {
        yield return new WaitForEndOfFrame();

    }
    private IEnumerator waitAMoment()
    {
        yield return new WaitForSeconds(0.2f);

    }

    void inkMethodSetting()
    {

        currentStory.BindExternalFunction("casualProfSprite", (string hi) =>
        {
            //classScene.SetActive(false);
            FindObjectOfType<professorScript>().NormalSprite();
        });
        currentStory.BindExternalFunction("TriggerBossBattle", (string hi) =>
        {
            StartCoroutine(waitAMoment());

            SceneManager.LoadScene("ProfessorBattle");

        });
        currentStory.BindExternalFunction("bossEnding", (string hi) =>
        {
            StartCoroutine(waitAMoment());
            SceneManager.LoadScene("EndCredits");

        });
    }
    public void DisplayChoices(string option1)
    {

        choice1.visible = true;
        choice2.visible = false;
        choice3.visible = false;
        choice4.visible = false;

        choice1.text = option1;
    }
    public void DisplayChoices(string option1, string option2)
    {


        choice1.visible = true;
        choice2.visible = true;
        choice3.visible = false;
        choice4.visible = false;


        choice1.text = option1;
        choice2.text = option2;
    }
    public void DisplayChoices(string option1, string option2, string option3)
    {


        choice1.visible = true;
        choice2.visible = true;
        choice3.visible = true;
        choice4.visible = false;


        choice1.text = option1;
        choice2.text = option2;
        choice3.text = option3;
    }
    public void DisplayChoices(string option1, string option2, string option3, string option4)
    {


        choice1.visible = true;
        choice2.visible = true;
        choice3.visible = true;
        choice4.visible = true;

        choice1.text = option1;
        choice2.text = option2;
        choice3.text = option3;
        choice4.text = option4;
    }

   /* void Choice1Select()
    {

       
    }
    void Choice2Select()
    {
        nextDialogue();
    }
    void Choice3Select()
    {

        FindObjectOfType<DialogueUIScript>().nextDialogue();
    }
    void Choice4Select()
    {
        FindObjectOfType<DialogueUIScript>().nextDialogue();
    }*/

    //method to hide all choices
    public void hideAll()
    {
        choice1.visible = false;
        choice2.visible = false;
        choice3.visible = false;
        choice4.visible = false;

    }
}

