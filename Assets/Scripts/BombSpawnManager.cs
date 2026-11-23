using UnityEngine;

public class BombSpawnManager : MonoBehaviour
{
    private GameObject bombSpawner;
    public GameObject bomb;
    public Transform playerFollower;
    private float time;
    public float delay;
    private int numBomb = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= delay)
        {
            spawnBomb();
            time = 0f;
        }
        followPlayer();
    }

    private void followPlayer()
    {
        bombSpawner.transform.position = new Vector2(playerFollower.transform.position.x, playerFollower.transform.position.y);
    }

    private void spawnBomb()
    {
        bombSpawner = Instantiate(bomb);
    }
}
