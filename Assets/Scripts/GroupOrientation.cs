using UnityEngine;
using System.Collections;

public class GroupOrientation : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //set a random rotation
        int rotation = Random.Range(0, 4) * 90;
        transform.Rotate(new Vector3(0, 0, rotation));
	}
}
