using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    public GameObject lowestYSpawn;
    public GameObject largestYSpawn;
    public GameObject Shuriken;
    public Transform lowestYPlayerFollower;
    public Transform highestYPlayerFollower;

    private GameObject shurikenSpawner;
    private float time;
    public float delay;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= delay)
        {
            spawnShuriken();
            time = 0f;
        }
        followOnXOnly();
    }

    private void followOnXOnly()
    {
        lowestYSpawn.transform.position = new Vector3(lowestYPlayerFollower.position.x, lowestYPlayerFollower.position.y, lowestYSpawn.transform.position.z);
        largestYSpawn.transform.position = new Vector3(highestYPlayerFollower.position.x, highestYPlayerFollower.position.y, largestYSpawn.transform.position.z);
    }

    private void spawnShuriken()
    {
        shurikenSpawner = Instantiate(Shuriken);
        shurikenSpawner.transform.position = new Vector2(lowestYSpawn.transform.position.x, Random.Range(lowestYSpawn.transform.position.y, largestYSpawn.transform.position.y));
    }

}
