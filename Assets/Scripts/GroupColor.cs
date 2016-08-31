using UnityEngine;
using System.Collections;

public class GroupColor : MonoBehaviour {

    public static Vector4 GetClampedRandomColor(float smallestColorValue = 0.25f) {

        //get a random color and apply to all it's children
        Vector4 color = Random.ColorHSV();
        color.w = 1;

        color.x = Mathf.Clamp(color.x, smallestColorValue, 2);
        color.y = Mathf.Clamp(color.y, smallestColorValue, 2);
        color.z = Mathf.Clamp(color.z, smallestColorValue, 2);

        return color;
    }

	// Use this for initialization
	void Start () {


        Vector4 color = GetClampedRandomColor();

        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
            sr.color = color;
	}
}
