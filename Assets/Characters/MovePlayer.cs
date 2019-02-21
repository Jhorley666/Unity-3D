using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    public float speedMove = 3f;
    public bool turn;
    public Animator animator;
    public Rigidbody rigidPlayer;
	void Start () {
        rigidPlayer = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        turn = true;
	}

    void Update() {

    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move));
        rigidPlayer.velocity = new Vector3(0, rigidPlayer.velocity.y, move * speedMove);
        if (move > 0 && !turn)
        {
            Flip();
        }
        else
        {
            if (move < 0 && turn)
            {
                Flip();
            }
        }
    }
    void Flip()
    {
        turn = !turn;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}


