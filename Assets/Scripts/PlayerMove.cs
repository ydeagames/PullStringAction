using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //public Vector2 force;
    Rigidbody2D _rigidbody;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //_rigidbody.AddForce(force);

        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, (Vector2) transform.position + Vector2.right, step);
    }
}
