using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour {

    //horizontal area where blocks can spawn
    public int leftEdge, rightEdge;

    //spawn delay is the amount of time before spawning a block
    //blocks will spawn with an initial delay, and then begin spawining faster
    //eventually the spawn delay will reach a limit of finalBlockSpawnDelay
    public float initialBlockSpawnDelay, finalBlockSpawnDelay;
    private float currentBlockSpawnDelay;

    //the different types of blocks that can be spawned
    public GameObject[] blockTypes;

    void Start() {

        currentBlockSpawnDelay = initialBlockSpawnDelay;
        StartCoroutine(spawnBlock());
    }

    IEnumerator spawnBlock() {

        while (true && blockTypes.Length > 0) {

            //spawn a block in a random position
            //choose a block type to spawn
            int idBlockToSpawn = Random.Range(0, blockTypes.Length - 1);

            //choose a position to spawn the block
            int spawnLocationX = Random.Range(leftEdge, rightEdge);
            float spawnLocationY = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, Camera.main.nearClipPlane)).y;

            GameObject spawnedBlock = Instantiate(blockTypes[idBlockToSpawn]) as GameObject;
            spawnedBlock.transform.position = new Vector3(spawnLocationX, spawnLocationY, spawnedBlock.transform.position.z);

            //make sure the block isn't outside the boundaries
            forceIntoWorldBounds(spawnedBlock);
            Debug.Log(spawnedBlock.transform.position.x);

            yield return new WaitForSeconds(currentBlockSpawnDelay);
        }

        yield return null;
    }

    void forceIntoWorldBounds(GameObject obj) {

        //get the bounds of the object, move it until the bounds are within limits
        Bounds objectBounds = GroupHelper.getWorldBounds(obj);

        //off of the left edge, move it inside the bounds
        //add 2 to the left edge when moving because this sets position of the center of the group, and some groups have 2 blocks to the left of the middle so it will hang of the edge
        if (objectBounds.min.x < leftEdge)
            obj.transform.position = new Vector3(leftEdge + 2, obj.transform.position.y, obj.transform.position.z);

        if(objectBounds.max.x > rightEdge)
            obj.transform.position = new Vector3(rightEdge - 4, obj.transform.position.y, obj.transform.position.z);
    }
}
