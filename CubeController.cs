using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class CubeController : MonoBehaviour
{
    public GameObject player;  // The object that will be moved
    public float speed = 20f;  // Movement speed of the object
    public TMP_InputField playerInputField;
    public Button submitButton;
    public TMP_Text TextOutput;


    // ArrayList to hold valid commands
    private ArrayList validCommands = new ArrayList { "up", "down", "left", "right", "red", "blue", "yellow", "white", "black" };

    void Start()
    {
        submitButton.onClick.AddListener(SubmitInput);
    }

    public void SubmitInput()
    {
        ProcessCommand(playerInputField.text);
        playerInputField.text = "";  // Clear input field after processing command
    }

    private void ProcessCommand(string command)
    {
        string phrase = command.ToLower();


        if (phrase.Contains("up"))
        {
            player.transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else if (phrase.Contains("down"))
        {
            player.transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        else if (phrase.Contains("left"))
        {
            player.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (phrase.Contains("right"))
        {
            player.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (phrase.Contains("red"))
        {
            player.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (phrase.Contains("black"))
        {
            player.GetComponent<Renderer>().material.color = Color.black;
        }
        else if (phrase.Contains("blue"))
        {
            player.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (phrase.Contains("white"))
        {
            player.GetComponent<Renderer>().material.color = Color.white;
        }
        else
        {
            Debug.Log("Invalid command: " + command);
        }
    }

}
  

