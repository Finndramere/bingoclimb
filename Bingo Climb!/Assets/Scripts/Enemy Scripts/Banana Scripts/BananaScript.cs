﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1f;

    private float cameraY;
    // Start is called before the first frame update
    void Start()
    {
        cameraY = Camera.main.transform.position.y - 100f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Deactivate();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;
    }

    void Deactivate()
    {
        if (transform.position.y < cameraY)
        {
            gameObject.SetActive(false);
        }
    }
}
