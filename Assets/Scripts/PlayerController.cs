using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 6;
    public float jumpImpulse = 26;

    private bool isGrounded { set; get; }

	// Use this for initialization
	void Start () {

        //set a random color
        Vector4 color = GroupColor.GetClampedRandomColor(0.4f);
        GetComponent<SpriteRenderer>().color = color;

        gameObject.tag = "Player";
	}
	
	void Update () {

        float input = Input.GetAxis("HorizontalP1");
        GetComponent<Rigidbody2D>().velocity = new Vector2(input * speed, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetAxis("JumpP1") > 0 && isGrounded) {

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpImpulse), ForceMode2D.Impulse);
            isGrounded = false;
        }

        //if player is falling or jumping then don't let him jump
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) > 0.1)
            isGrounded = false;

        if (GetComponent<Rigidbody2D>().velocity.y > jumpImpulse)
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpImpulse);

    }

    void OnCollisionEnter2D(Collision2D collision) {

        //if player is standing on top of the collided block, then let him jump again
        if (collision.contacts.Length == 0)
            return;

        var contact = collision.contacts[0];

        //don't set isGrounded to the if condition because collisions from other blocks might disable jumping again
        if(Vector2.Dot(contact.normal, Vector2.up) > 0.5) {

            isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision) {

        OnCollisionEnter2D(collision);
    }
}
