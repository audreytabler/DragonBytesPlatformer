using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;


public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Visual Cue")]
    [SerializeField] GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);

        Story currentStory = new Story(inkJSON.text);

    }
    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetButtonDown("Fire1"))//fire1 is T
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
            visualCue.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            playerInRange = true;

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            playerInRange = false;
    }
}

