using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TitleSceneController : MonoBehaviour
{

    public static string PlayerName;
    // Start is called before the first frame update
    Button start;
    TextField playerNameIn;
   
    void OnEnable()
    {
        //SceneManager.LoadScene("Start_Menu");

        Debug.Log("scriptRan");

        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;

        //allows us to access and change the UI dialogueBox and name_text UI components
        start = root.Q<Button>("StartButton");
        playerNameIn = root.Q<TextField>("PlayerNameInput");

        Button startButton = root.Q<Button>("start");

        //when messagebox clicked, set chatbox
        start.RegisterCallback<ClickEvent>(ev => clickStart());
    }
    void clickStart()
    {

        Debug.Log("Playername name text is:" + playerNameIn.text+".");
        if (!(playerNameIn.text.Length == 0))
        {
            SceneManager.LoadScene("Platformer_Scene");

            PlayerName = playerNameIn.text;
        }
        else
            Debug.Log("Please enter a name before pressing start");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
