using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHold : MonoBehaviour {
    public string Dialogue;
    private ChoiceMenuManager choiceMenuManager;

    public string[] Texts1;
    public string[] Texts2;
    public string[] Texts3;
    public PlayerController.Directions[] looking;

    public string[] ButtonLabels = new string[] { "", "", ""};

    // Use this for initialization
    void Start()
    {
        choiceMenuManager = FindObjectOfType<ChoiceMenuManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.name == "George")
        {
            foreach (PlayerController.Directions dir in looking)
            {
                PlayerController player = FindObjectOfType<PlayerController>();
                if (Input.GetKeyDown(KeyCode.E) && player.direction == dir)
                {
                    string[][] D = new string[3][] { Texts1, Texts2, Texts3 };

                    /*D[0][0] = "You tried to tidy the bed.";
                    D[0][1] = "It's beyond saving.";
                    D[1][0] = "It's a rather simple bed.";
                    D[1][1] = "It seems that time has truly been merciless to it.";
                    D[2][0] = "You looked under the bed.";
                    D[2][1] = "There's a notebook in a rather good state.";
                    D[2][2] = "Upon further inspection, it seems to be a diary.";*/


                    choiceMenuManager.Show(ButtonLabels, D);
                }
            }
        }
     }
}

