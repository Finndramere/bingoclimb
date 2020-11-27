using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    private float moveSpeed = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += moveSpeed * Time.deltaTime;
        transform.position = temp;
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "SideBound")
        {
            moveSpeed *= -1f;

            Vector3 temp = transform.localScale;
            temp.x *= -1f;
            transform.localScale = temp;
        }

    }


}
