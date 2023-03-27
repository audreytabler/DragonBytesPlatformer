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

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue Box UI")]
    [SerializeField] UIDocument dialoguePanel;
    private static DialogueManager instance;

    [Header("Choices UI")]
    [SerializeField] GameObject choicesPopup;

    [Header("Sprite")]
    [SerializeField] GameObject sprite;

    [Header("ClassroomScene")]
    [SerializeField] GameObject classScene;


    private Story currentStory;
    private string[] choicesText;
    public bool dialogueIsPlaying { get; private set; }

    public VisualElement nameBox;
    public Label nameText;
    public Button messageBox;
    bool isTyping = false;
    bool missionInProgress = false;

    //currentStory.TagsForContentAtPath("your_knot") ... calling a certain knot in story
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple instances of DialogueManager...");
        }
        instance = this;
    }

    private void OnEnable()
    {
        var root = dialoguePanel.rootVisualElement;

        messageBox = root.Q<Button>("dialogueBox");
        nameBox = root.Q<VisualElement>("name");
        nameText = root.Q<Label>("name_text");
        

        //when messagebox clicked, set chatbox
        if(!isTyping)
            messageBox.RegisterCallback<ClickEvent>(ev => ContinueStory());
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
       // messageBox.visible = false;
        //nameBox.visible = false;
        isTyping = false;

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        if (!isTyping)
        {
            messageBox.visible = true;
            nameBox.visible = true;
            nameText.visible = true;
            currentStory = new Story(inkJSON.text);
            nameText.text = (string)currentStory.variablesState["charName"];
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
            else
                StartCoroutine(fadeOutChat());
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        //StopAllCoroutines()
        nameText.text = (string)currentStory.variablesState["charName"];
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
        nameBox.visible = true;
        nameText.visible = true;
        //isTyping = true;

        messageBox.style.opacity = 0.0f;
        for (float i = 0.0f; i <= 1.0f; i += 0.01f)
        {
            nameBox.style.opacity = i;
            messageBox.style.opacity = i;
            yield return new WaitForSeconds(0.01f); //adds delay between displaying characters
        }
       // isTyping = false;


    }

    IEnumerator fadeOutChat()
    {
        dialogueIsPlaying = false;
        for (float i = 1f; i > 0f; i -= 0.1f)
        {
            nameBox.style.opacity = i;
            messageBox.style.opacity = i;
            yield return new WaitForSeconds(0.05f); //adds delay between displaying characters
        }
        messageBox.visible = false;
        nameText.visible = false;
        nameBox.visible = false;

    }

    private void DisplayChoices()
    {
        if (currentStory.currentChoices.Count == 0)
            return;
        FindObjectOfType<ChoiceOverlay>().DisplayChoices(currentStory.currentChoices);
        StartCoroutine(SelectFirstChoice());
    }
    public static void MakeChoice(int choiceIndex)
    {
        Debug.Log("Selected choice "+choiceIndex);
        FindObjectOfType<ChoiceOverlay>().hideAll();


        instance.currentStory.ChooseChoiceIndex(choiceIndex);
       // instance.currentStory.currentChoices.Clear();
        instance.ContinueStory();
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

        currentStory.BindExternalFunction("hasCoffee", (bool status) =>
        {
            missionManager.missionInProgress = status;

        });

        currentStory.BindExternalFunction("startClass", (string hi) =>
        {
            missionManager.ClassNumber++;
            classScene.SetActive(true);
        });
        currentStory.BindExternalFunction("endClass", (string hi) =>
        {

            missionManager.classTime = false;
            //currentStory.variablesState["classTime"] = missionManager.classTime;

            classScene.SetActive(false);
        });
        currentStory.BindExternalFunction("angryProfSprite", (string hi) =>
        {
            //classScene.SetActive(false);
            FindObjectOfType<professorScript>().AngrySprite();
            //professorScript.AngrySprite();
        });
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
    }

}
