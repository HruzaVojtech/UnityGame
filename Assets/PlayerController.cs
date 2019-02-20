using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float MoveSpeed;
    public Directions direction;

    public bool CanMove = true;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Horizontal") > 0.5f && CanMove)
        {
            direction = Directions.right;
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime, 0f, 0f));
        }

        if (Input.GetAxisRaw("Horizontal") < -0.5f && CanMove)
        {
            direction = Directions.left;
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime, 0f, 0f));
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f && CanMove)
        {
            direction = Directions.up;
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime, 0f));
        }

        if (Input.GetAxisRaw("Vertical") < -0.5f && CanMove)
        {
            direction = Directions.down;
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime, 0f));
        }

        if (CanMove)
        {
            anim.SetFloat("X", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("Y", Input.GetAxisRaw("Vertical"));
        }
    }

    public enum Directions { up, down, left, right}
}
