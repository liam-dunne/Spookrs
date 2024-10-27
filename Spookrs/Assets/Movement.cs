using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed = 500f;
    [SerializeField]
    Vector2 direction;

    [SerializeField]
    private Vector2 input_direction;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.velocity = input_direction*speed*Time.deltaTime;
    }
    public void setInput(Vector2 direction)
    {
        input_direction = direction.normalized;
    }

}
