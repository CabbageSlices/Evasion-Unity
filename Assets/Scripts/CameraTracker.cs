using UnityEngine;
using System.Collections;

public class CameraTracker : MonoBehaviour {

    //max and min size that camera can be when following
    public float minCameraSize, maxCameraSize;

    //store all the players in the level in order to track them
    private GameObject[] players;

	// Use this for initialization
	void Start () {

        //get all the players in the scene
        players = GameObject.FindGameObjectsWithTag("Player");
        Camera.main.orthographicSize = minCameraSize;
	}
	
	// Update is called once per frame
	void Update () {

        //determine the average position of the players in order to track them
        Vector3 cameraTarget = calculateCameraTarget();

        Camera.main.transform.position = cameraTarget;
	}

    Vector3 calculateCameraTarget() {

        Vector3 target = new Vector3(0, 0, 0);

        int livePlayers = 0;

        foreach(GameObject player in players) {

            if(player != null) {

                target += player.transform.position;
                livePlayers++;
            }
        }

        if(livePlayers > 0)
            target = target / livePlayers;

        target.z = -10;
        return target;
    }
}
