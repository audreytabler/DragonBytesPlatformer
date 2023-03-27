using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitAMoment());
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
    /*public void startFirstScene()
    {
        /*StartCoroutine(waitAMoment());
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        Debug.Log("First scene should play now...");
    }*/
    private IEnumerator waitAMoment()
    {
        yield return new WaitForSeconds(1f);
    }

    // Update is called once per frame
}
