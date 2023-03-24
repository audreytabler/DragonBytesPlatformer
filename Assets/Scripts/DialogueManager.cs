using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Label = UnityEngine.UIElements.Label;
using UnityEngine.EventSystems;


public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue Box UI")]
    [SerializeField] UIDocument dialoguePanel;
    private static DialogueManager instance;

    [Header("Choices UI")]
    [SerializeField] GameObject choicesPopup;

    [Header("Sprite")]
    [SerializeField] GameObject sprite;


    private Story currentStory;
    private string[] choicesText;
    public bool dialogueIsPlaying { get; private set; }

    public VisualElement nameBox;
    public Label nameText;
    public Button messageBox;
    bool isTyping = false;


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
        messageBox.visible = false;
        nameBox.visible = false;

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        nameText.text = (string)currentStory.variablesState["charName"];
        StartCoroutine(fadeInChat());
        dialogueIsPlaying = true;


        ContinueStory();

    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            StartCoroutine(TypeSentence(currentStory.Continue()));
            
        }
        else
            StartCoroutine(fadeOutChat());
    }

    IEnumerator TypeSentence(string sentence)
    {
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
        nameText.visible = true;
        isTyping = true;

        messageBox.style.opacity = 0.0f;
        for (float i = 0.0f; i <= 1.0f; i += 0.01f)
        {
            nameBox.style.opacity = i;
            messageBox.style.opacity = i;
            yield return new WaitForSeconds(0.01f); //adds delay between displaying characters
        }
        isTyping = false;


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

    }

    private void DisplayChoices()
    {
        if (currentStory.currentChoices.Count == 0)
            return;
        FindObjectOfType<ChoiceOverlay>().DisplayChoices(currentStory.currentChoices);
        Debug.Log("There are currently " + currentStory.currentChoices.Count + " choices");
        StartCoroutine(SelectFirstChoice());
    }
    public static void MakeChoice(int choiceIndex)
    {
        Debug.Log("Selected choice "+choiceIndex);
        FindObjectOfType<ChoiceOverlay>().hideAll();


        instance.currentStory.ChooseChoiceIndex(choiceIndex);
       // instance.currentStory.currentChoices.Clear();
        instance.ContinueStory();
        return;

    }

    private IEnumerator SelectFirstChoice()
    {
        yield return new WaitForEndOfFrame();
        
    }

}
