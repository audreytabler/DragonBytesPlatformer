using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using Label = UnityEngine.UIElements.Label;
using TextAsset = UnityEngine.TextAsset;

public class DialogueUIScript : MonoBehaviour
{
    //text reading from file stuff
    [SerializeField]
    private TextAsset week1;
    [SerializeField]
    public string[] lines;

    //what line of the file we are currently on
    public static long currentLine = 0;
    private void Start()
    {
        //splits text file into seperate lines
        lines = week1.text.Split(new string[] { "\n" }, StringSplitOptions.None);
    }

    //the current options/events the player has to choose from
    public static string[] currentChoices = new string[5]; //stores message and associated stat buff


    //UI Stuff

    [SerializeField]
    public PrefabAssetType ChoiceOverlayHere;

    public VisualElement nameBox;
    public Label nameText;
    public Button messagebox;
    public bool isTyping = false;



    void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;

        //allows us to access and change the UI dialogueBox and name_text UI components
        messagebox = root.Q<Button>("dialogueBox");
        nameBox = root.Q<VisualElement>("name");

        nameText = root.Q<Label>("name_text");

        Button startButton = root.Q<Button>("start");

        //when messagebox clicked, set chatbox
        messagebox.RegisterCallback<ClickEvent>(ev => nextDialogue());

    }
    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        messagebox.text = "";
        foreach (char character in sentence.ToCharArray())
        {
            messagebox.text += character;
            yield return new WaitForSeconds(0.01f); //adds delay between displaying characters
        }

        isTyping=false;
    }
    IEnumerator fadeInChat()
    {
        messagebox.visible = true;
        nameText.visible = true;

        messagebox.style.opacity = 0.0f;
         for (float i = 0.0f; i <= 1.0f; i+=0.01f)
         {
             nameBox.style.opacity = i;
            messagebox.style.opacity = i;
             yield return new WaitForSeconds(0.01f); //adds delay between displaying characters
         }


    }
    IEnumerator fadeOutChat()
    {
        for (float i = 1f; i > 0f; i -= 0.1f)
        {
            nameBox.style.opacity = i;
            messagebox.style.opacity = i;
            yield return new WaitForSeconds(0.05f); //adds delay between displaying characters
        }
        messagebox.visible = false;
        nameText.visible = false;

    }
 


    //Conversation stuff

    public void startDialogue(long lineIndex)
    {
       
        currentLine = lineIndex; //sets starting index so we know what line of dialogue to start on
        StartCoroutine(fadeInChat());  //animate textbox on screen

        nextDialogue();
        
    }

    public void nextDialogue()
    {
        if (isTyping == false)
        {
            if (lines[currentLine].Contains("===")) //three equals represents end of dialogue so we will close the dialogue box
            {
                endDialogue();
                currentLine += 2;
                return;
            }
            if (lines[currentLine].Contains("???")) //three question marks represent question prompt
            {
                currentLine++;
                setChoices();
              //  FindObjectOfType<ChoiceOverlay>().DisplayChoices("Look! A single option!", "Oh hey look! Another option");
                
                return;
                //Debug.Log(ChoiceOverlay.shadow);
                //ChoiceOverlay.shadow.visible = true;
            }
            nameText.text = lines[currentLine++]; //sets 'name' element in the UI to the current line we are on, then increments it
            string message = lines[currentLine++]; // same but with message 
            currentLine++;

            //Call code to update speaking character sprites


            //ensures we are not stuck animating a previous TypeSentence
            StartCoroutine(TypeSentence(message));
        }

    }

    public void endDialogue()
    {
        //animate textbox down
        StartCoroutine(fadeOutChat()); //animate textbox on screen
        SceneManager.LoadScene("Platformer_Scene");

    }

    void setChoices()
    {
        int currentNumOfChoices = 0;
        StatManager.changeVal = int.Parse(lines[currentLine++]); 

        for (int i = 1; (!(lines[currentLine].Contains("???")) && i<=4); i++) //loop until current line equals ??? or i is at end of array
        {
            currentChoices[i] = lines[currentLine++]; //set index of choice to next line from file;


            if (currentChoices[i][0] == '%') //if first character is %, grade boost
            {
                ChoiceOverlay.currentChoiceBuffs[i] = "grade";
            }
            if (currentChoices[i][0] == '~') //if first character is %, energy buff
            {
                ChoiceOverlay.currentChoiceBuffs[i] = "energy";
            }
            if (currentChoices[i][0] == '*') //if first character is *, fun buff
            {
                ChoiceOverlay.currentChoiceBuffs[i] = "fun";
            }
            if (currentChoices[i][0] == '#') //if first character is #, social buff
            {
                ChoiceOverlay.currentChoiceBuffs[i] = "social";
            }
            //FindObjectOfType<ChoiceOverlay>().setChoiceBuffIndex(i+1, "ahh test for now");

            currentNumOfChoices++;
        }
        Debug.Log(currentNumOfChoices);

        currentLine+=2;

        //calls method to ChoiceOverlay depending on how many choices it found

        if (currentNumOfChoices == 0)
        {
            Debug.Log("No player dialogue options found");
        }
        if (currentNumOfChoices == 1)
        {
            FindObjectOfType<ChoiceOverlay>().DisplayChoices(currentChoices[1]);
        }
        if (currentNumOfChoices == 2)
        {
            FindObjectOfType<ChoiceOverlay>().DisplayChoices(currentChoices[1], currentChoices[2]);
        }
        if (currentNumOfChoices == 3)
        {
            FindObjectOfType<ChoiceOverlay>().DisplayChoices(currentChoices[1], currentChoices[2], currentChoices[3]);
        }
        if (currentNumOfChoices == 4)
        {
            FindObjectOfType<ChoiceOverlay>().DisplayChoices(currentChoices[1], currentChoices[2], currentChoices[3], currentChoices[4]);
        }

    }    

}
