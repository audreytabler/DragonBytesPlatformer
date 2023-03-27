using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
//using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class professorScript : MonoBehaviour
{

    [SerializeField]
    private Sprite angry;

    [SerializeField]
    public Sprite casual;

    [SerializeField]
    private TextAsset Class1;

    [SerializeField]
    private TextAsset Class2;

    [SerializeField]
    private TextAsset Class3;
     static Image myIMGcomponent;

    [SerializeField]
    SpriteRenderer myRenderer;

    Story currentStory;

    private void Start()
    {
        //classScene.SetActive(false);
    }


    void OnEnable()
    {

        myRenderer.sprite = casual;

        Debug.Log("Sup the classroom is awake");
        if (missionManager.ClassNumber == 1)
        {
            currentStory = new Story(Class1.text);
            DialogueManager.GetInstance().EnterDialogueMode(Class1);
        }
        if (missionManager.ClassNumber == 2)
        {
            currentStory = new Story(Class2.text);
            DialogueManager.GetInstance().EnterDialogueMode(Class2);
        }
        if (missionManager.ClassNumber == 3)
        {
            currentStory = new Story(Class3.text);
            DialogueManager.GetInstance().EnterDialogueMode(Class3);
        }

    }

    public void AngrySprite()
    {
        myRenderer.sprite = angry;
    }

    public void NormalSprite() {
        myRenderer.sprite = casual;

    }

  
}
