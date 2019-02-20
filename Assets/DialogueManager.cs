using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject DialogueBox;
    public Text DialogueText;
    public bool JustClosed = false;
    private PlayerController player;

    public bool DialogueActive;
    private string CurrentText = "";
    private int DialoguesIndex;
    private string[] Texts;

    public float speed = 0.01f;
    public string TextToTypewrite;
    private bool IsWriting;

    // Use this for initialization
    void Start () {
        DialogueActive = false;
        DialogueBox.SetActive(false);
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		if(DialogueActive && Input.GetKeyDown(KeyCode.Space) && DialoguesIndex < Texts.Length - 1)
        {
            if(IsWriting)
            {
                IsWriting = false;
            }
            else
            {
                DialoguesIndex++;
                //DialogueText.text = Texts[DialoguesIndex];
                TextToTypewrite = Texts[DialoguesIndex];
                StartCoroutine(ShowText());
            }         
        }
        else if (DialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (IsWriting)
            {
                IsWriting = false;
            }
            else
            {
                DialogueActive = false;
                DialogueBox.SetActive(false);
                player.CanMove = true;
            }
        }
    }

    public void ShowBox(string dialogue)
    {
        DialogueActive = true;
        DialogueBox.SetActive(true);
        player.CanMove = false;
        DialogueText.text = dialogue;
    }

    public void ShowDialogue(string[] dialogues)
    {
        Texts = dialogues;
        DialogueActive = true;
        DialogueBox.SetActive(true);
        player.CanMove = false;
        //DialogueText.text = Texts[0];
        TextToTypewrite = Texts[0];
        StartCoroutine(ShowText());
        DialoguesIndex = 0;
    }

    IEnumerator ShowText()
    {
        IsWriting = true;

        for(int i = 0; i <= TextToTypewrite.Length; i++)
        {
            if(IsWriting)
            {
                CurrentText = TextToTypewrite.Substring(0, i);
                DialogueText.text = CurrentText;
                yield return new WaitForSeconds(speed);
            }
            else
            {
                DialogueText.text = Texts[DialoguesIndex];
                break;
            }

        }

        IsWriting = false;
    }

    /*IEnumerator WaitASecond()
    {
        yield return new WaitForSeconds(15);
    }*/
}
