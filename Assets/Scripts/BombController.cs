using UnityEngine;

public class BombController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float Speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDown();
    }

    private void moveDown()
    {
        rb.linearVelocity = new Vector2(0, Speed * -1);
    }

    private void OnMouseDown()
    {
        Destroy(this.gameObject);
    }
}
