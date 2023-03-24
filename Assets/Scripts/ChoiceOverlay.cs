using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Ink.Runtime;

public class ChoiceOverlay : MonoBehaviour
{

    VisualElement shadow;
    public Button choice1;
    public Button choice2;
    public Button choice3;
    public Button choice4;

    public static string[] currentChoiceBuffs = new string[5]; //stores effects of current choices

    private void Start()
    {
        hideAll();
    }
    void OnEnable()
    {

        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;
      

        shadow = root.Q<VisualElement>("Shadow");

        //allows us to access and change the UI dialogueBox and name_text UI components
        choice1 = root.Q<Button>("Choice1");
        choice2 = root.Q<Button>("Choice2");
        choice3 = root.Q<Button>("Choice3");
        choice4 = root.Q<Button>("Choice4");
        shadow.visible = false;

        //choice1.style.opacity.ps


        //when messagebox clicked, set chatbox
        choice1.RegisterCallback<ClickEvent>(ev =>DialogueManager.MakeChoice(0));
        choice2.RegisterCallback<ClickEvent>(ev => DialogueManager.MakeChoice(1));
        choice3.RegisterCallback<ClickEvent>(ev => DialogueManager.MakeChoice(2));
        choice4.RegisterCallback<ClickEvent>(ev => DialogueManager.MakeChoice(3));

    }
    IEnumerator fadeIn()
    {
        
        shadow.visible = true;

        shadow.style.opacity = 0.0f;
        for (float i = 0.0f; i <= 1.0f; i += 0.01f)
        {
            shadow.style.opacity = i;
            choice1.style.opacity = i;
            yield return new WaitForSeconds(0.01f); //adds delay between displaying characters
        }

    }

    //method to fade out shadowbox
    IEnumerator fadeOut()
    {
        shadow.style.opacity = 1.0f;
        for (float i = 1f; i >= 0.0f; i -= 0.01f)
        {
            shadow.style.opacity = i;
            yield return new WaitForSeconds(0.01f); //adds delay 
        }
        hideAll();
    }

    public void DisplayChoices(List<Choice> currentChoices)
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
            Debug.Log("There were "+ currentChoices.Count +" number of choices which is invalid");
    }
    public void DisplayChoices(string option1)
    {
        StartCoroutine(fadeIn());

        shadow.visible = true;
        choice1.visible = true;
        choice2.visible = false;
        choice3.visible = false;
        choice4.visible = false;

        choice1.text = option1;
    }
    public void DisplayChoices(string option1, string option2)
    {

        shadow.visible = true;
        choice1.visible = true;
        choice2.visible = true;
        choice3.visible = false;
        choice4.visible = false;


        choice1.text = option1;
        choice2.text = option2;
    }
    public void DisplayChoices(string option1, string option2, string option3)
    {

        shadow.visible = true;
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

        shadow.visible = true;
        choice1.visible = true;
        choice2.visible = true;
        choice3.visible = true;
        choice4.visible = true;

        choice1.text = option1;
        choice2.text = option2;
        choice3.text = option3;
        choice4.text = option4;
    }

    void Choice1Select()
    {
        StartCoroutine(fadeOut());

        if (currentChoiceBuffs[1].Contains("grade"))
            FindObjectOfType<StatManager>().updateGrade();
        if (currentChoiceBuffs[1].Contains("energy"))
            FindObjectOfType<StatManager>().updateEnergy();
        if (currentChoiceBuffs[1].Contains("fun"))
            FindObjectOfType<StatManager>().updateFun();
        if (currentChoiceBuffs[1].Contains("social"))
            FindObjectOfType<StatManager>().updateSocial();

        FindObjectOfType<DialogueUIScript>().nextDialogue();
    }
    void Choice2Select()
    {
        StartCoroutine(fadeOut());

        if (currentChoiceBuffs[2].Contains("grade"))
            FindObjectOfType<StatManager>().updateGrade();
        if (currentChoiceBuffs[2].Contains("energy"))
            FindObjectOfType<StatManager>().updateEnergy();
        if (currentChoiceBuffs[2].Contains("fun"))
            FindObjectOfType<StatManager>().updateFun();
        if (currentChoiceBuffs[2].Contains("social"))
            FindObjectOfType<StatManager>().updateSocial();

        FindObjectOfType<DialogueUIScript>().nextDialogue();
    }
    void Choice3Select()
    {
        StartCoroutine(fadeOut());

        if (currentChoiceBuffs[3].Contains("grade"))
            FindObjectOfType<StatManager>().updateGrade();
        if (currentChoiceBuffs[3].Contains("energy"))
            FindObjectOfType<StatManager>().updateEnergy();
        if (currentChoiceBuffs[3].Contains("fun"))
            FindObjectOfType<StatManager>().updateFun();
        if (currentChoiceBuffs[3].Contains("social"))
            FindObjectOfType<StatManager>().updateSocial();

        FindObjectOfType<DialogueUIScript>().nextDialogue();
    }
    void Choice4Select()
    {
        StartCoroutine(fadeOut());

        if (currentChoiceBuffs[4].Contains("grade"))
            FindObjectOfType<StatManager>().updateGrade();
        if (currentChoiceBuffs[4].Contains("energy"))
            FindObjectOfType<StatManager>().updateEnergy();
        if (currentChoiceBuffs[4].Contains("fun"))
            FindObjectOfType<StatManager>().updateFun();
        if (currentChoiceBuffs[4].Contains("social"))
            FindObjectOfType<StatManager>().updateSocial();

        FindObjectOfType<DialogueUIScript>().nextDialogue();
    }

    //method to hide all choices
    public void hideAll()
    {
        shadow.visible = false;
        choice1.visible = false;
        choice2.visible = false;
        choice3.visible = false;
        choice4.visible = false;

    }
    


}
