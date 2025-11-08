
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public Vector2 velocity = new Vector2(5f, 0f);

    public Transform wallDetector;

    public LayerMask wallDetectorLayerMask;

    public bool faceRight = true;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Physics2D.Linecast(transform.position + Vector3.up, wallDetector.position, wallDetectorLayerMask))
        {
            faceRight = !faceRight;
        }


        if(faceRight)
        {
            rigidBody.linearVelocity = velocity;
        }
        else
        {
            rigidBody.linearVelocity = -velocity;
        }
    }
}