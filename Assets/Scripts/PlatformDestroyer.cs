using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    int deleteTime = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < deleteTime; i++)
        {
            if (i == 5)
            {
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("OB"))
        {
            Destroy(this.gameObject);
        }
    }
}
