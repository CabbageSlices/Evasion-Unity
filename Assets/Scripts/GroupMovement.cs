using UnityEngine;
using System.Collections;

public class GroupMovement : MonoBehaviour {

    public float speed = 5;

	void Start () {

        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
	}

    void OnCollisionExit2D(Collision2D collision) {

        //if player touches side of block, don't stop block from falling
        if (collision.gameObject.tag.ToLower() == "player" && GetComponent<Rigidbody2D>().velocity.y < 0)
            return;

        //stop blocks from falling or jumping upwards when it hits something
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
