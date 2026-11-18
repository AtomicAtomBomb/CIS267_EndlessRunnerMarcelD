using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject lowestYSpawn;
    public GameObject highestYSpawn;
    public GameObject platform;
    public float delay;

    private bool spawnPlatforms = true;
    private GameObject spawnAPlatform;
    private float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= delay)
        {
            spawnPlatform();
            time = 0f;
        }
    }

    private void spawnPlatform()
    {
        if (spawnPlatforms == true)
        {
            spawnAPlatform = Instantiate(platform);
        }

        //tell the collectable where to spawn
        spawnAPlatform.transform.position = new Vector2(lowestYSpawn.transform.position.x, Random.Range(lowestYSpawn.transform.position.y, highestYSpawn.transform.position.y));
    }
}
