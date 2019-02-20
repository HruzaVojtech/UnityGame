using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceMenuManager : MonoBehaviour
{

    public GameObject ChoiceMenuBox;
    public bool MenuActive = false;
    private DialogueManager dialogueManager;
    public string[] Option1Texts;
    public string[] Option2Texts;
    public string[] Option3Texts;

    public Text ButtonText1;
    public Text ButtonText2;
    public Text ButtonText3;

    private PlayerController player;

    // Use this for initialization
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        ChoiceMenuBox.SetActive(false);
        MenuActive = false;
        //player.CanMove = true;
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuActive && Input.GetKeyDown(KeyCode.Escape))
        {
            ChoiceMenuBox.SetActive(false);
            MenuActive = false;
            player.CanMove = true;
        }
    }

    public void FirstOption()
    {
        ChoiceMenuBox.SetActive(false);
        MenuActive = false;
        //player.CanMove = true;
        dialogueManager.ShowDialogue(Option1Texts);
    }

    public void SecondOption()
    {
        ChoiceMenuBox.SetActive(false);
        MenuActive = false;
        //player.CanMove = true;
        dialogueManager.ShowDialogue(Option2Texts);
    }

    public void ThirdOption()
    {
        ChoiceMenuBox.SetActive(false);
        MenuActive = false;
        //player.CanMove = true;
        dialogueManager.ShowDialogue(Option3Texts);
    }

    public void Show(string[] buttons, string[][] buttonDialogues)
    {
        Option1Texts = buttonDialogues[0];
        Option2Texts = buttonDialogues[1];
        Option3Texts = buttonDialogues[2];

        ChoiceMenuBox.SetActive(true);
        MenuActive = true;
        player.CanMove = false;
        ButtonText1.text = buttons[0];
        ButtonText2.text = buttons[1];
        ButtonText3.text = buttons[2];
    }
}