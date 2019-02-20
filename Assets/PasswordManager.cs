using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordManager : MonoBehaviour {

    public GameObject PasswordBox;
    public bool WindowActive = false;
    private DialogueManager dialogueManager;
    private bool Answered = false;

    public Text InputText;

    private PlayerController player;

    // Use this for initialization
    void Start () {
        dialogueManager = FindObjectOfType<DialogueManager>();
        PasswordBox.SetActive(false);
        WindowActive = false;
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (WindowActive && Input.GetKeyDown(KeyCode.Escape))
        {
            PasswordBox.SetActive(false);
            WindowActive = false;
        }
        if (WindowActive && Input.GetKeyDown(KeyCode.Space) && Answered)
        {
            PasswordBox.SetActive(false);
            WindowActive = false;
        }
    }

    public void SubmitAnswer()
    {
        string[] text = new string[1];

        if (InputText.text == "Kimbo" || InputText.text == "kimbo" || InputText.text == "KIMBO")
        {
            text[0] = "Congratulations! You have finished the game. There might be more in the future. But for now, this is it. Thank you for playing. :)";
            Answered = true;
        }
        else
        {
            text[0] = "Wrong password!";
            Answered = true;
        }
        dialogueManager.ShowDialogue(text);
    }

    public void Show()
    {
        PasswordBox.SetActive(true);
        WindowActive = true;
        player.CanMove = false;
    }
}
