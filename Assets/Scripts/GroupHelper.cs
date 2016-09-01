using UnityEngine;
using System.Collections;

public class GroupHelper : MonoBehaviour {

    //calculates an approximation to the bounding box of the given group object
    //the z value is fixed to 0 since we this is 2D
	public static Bounds getWorldBounds(GameObject group) {

        //determine the bottom left and the top right of the bounding box
        Vector3 bottomLeft = new Vector3(float.MaxValue, float.MaxValue, 0);
        Vector3 topRight = new Vector3(-float.MaxValue, -float.MaxValue, 0);

        var spriteRenderers = group.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer spr in spriteRenderers) {

            bottomLeft.x = Mathf.Min(bottomLeft.x, spr.bounds.min.x);
            bottomLeft.y = Mathf.Min(bottomLeft.y, spr.bounds.min.y);

            topRight.x = Mathf.Max(topRight.x, spr.bounds.max.x);
            topRight.y = Mathf.Max(topRight.y, spr.bounds.max.y);
        }

        var sprite = group.GetComponent<SpriteRenderer>();

        if (sprite != null) {

            bottomLeft.x = Mathf.Min(bottomLeft.x, sprite.bounds.min.x);
            bottomLeft.y = Mathf.Min(bottomLeft.y, sprite.bounds.min.y);

            topRight.x = Mathf.Min(topRight.x, sprite.bounds.max.x);
            topRight.y = Mathf.Min(topRight.y, sprite.bounds.max.y);
        }

        Bounds bounds = new Bounds();
        bounds.SetMinMax(bottomLeft, topRight);

        return bounds;
    }
}
