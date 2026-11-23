using UnityEngine;

public class OBPlayerFollower : MonoBehaviour
{
    public GameObject OBBottom;
    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    private void followPlayer()
    {
        OBBottom.transform.position = new Vector2(Player.transform.position.x, OBBottom.transform.position.y);
    }
}
