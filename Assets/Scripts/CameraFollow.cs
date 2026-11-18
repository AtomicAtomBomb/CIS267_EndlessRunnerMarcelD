using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.3f;

    // Update is called once per frame
    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            Vector3 newPos = new Vector3(target.position.x, 0f, -10f);
            transform.position = newPos;
        }
    }
}
