using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordHolder : MonoBehaviour {

    private PasswordManager passwordManager;
    public PlayerController.Directions looking;

    // Use this for initialization
    void Start () {
        passwordManager = FindObjectOfType<PasswordManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "George")
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            if (Input.GetKeyDown(KeyCode.E) && player.direction == looking)
            {
                passwordManager.Show();
            }
        }
    }
}
