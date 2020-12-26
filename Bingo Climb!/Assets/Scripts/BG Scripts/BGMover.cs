using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class BGMover : MonoBehaviour
{
    public float moveSpeed = 5f;

    private GameObject[] sideBounds;
    private float cameraY;
    private float boundHeight;

    public GameObject[] enemies;
    public GameObject[] spawnPositions;


    // Start is called before the first frame update
    void Awake()
    {
        
        sideBounds = GameObject.FindGameObjectsWithTag("SideBound");
        cameraY = Camera.main.gameObject.transform.position.y-15;

        boundHeight = GetComponent<BoxCollider2D> ().bounds.size.y;

    }

    

    // Update is called once per frame
    void Update()
    {
        Move();
        Reposition();

    }


    
    void Move() {
        Vector3 temp = transform.position;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;
    }

    void Reposition()
    {
        if(transform.position.y < cameraY)
        {
            float highestBoundsY = sideBounds[0].transform.position.y;

            for(int i = 1; i <sideBounds.Length; i++)
            {
                if (highestBoundsY < sideBounds[i].transform.position.y)
                {
                    highestBoundsY = sideBounds[i].transform.position.y;
                }
            }

            Vector3 temp = transform.position;
            temp.y = highestBoundsY + boundHeight-1;
            transform.position = temp;

            SpawnEnemies();

        }
        
    }

    void SpawnEnemies()
    {
        if (Random.Range(0, 10) > 0)
        {
            int randomEnemyIndex = Random.Range(0, enemies.Length);

            if(randomEnemyIndex == 0)
            {
                Instantiate(enemies[randomEnemyIndex], new Vector3(0f, transform.position.y, 3f),Quaternion.identity);
            }
            else
            {
                GameObject enemyObj = Instantiate(enemies[randomEnemyIndex]);
                Vector3 enemyScale = enemyObj.transform.localScale;

                if (Random.Range(0, 2) > 0)
                {
                    enemyObj.transform.position = spawnPositions[0].transform.position;
                    enemyScale.x = -Mathf.Abs(enemyScale.x);
                }
                else
                {
                    enemyObj.transform.position = spawnPositions[1].transform.position;
                    enemyScale.x = Mathf.Abs(enemyScale.x);
                }
                enemyObj.transform.localScale = enemyScale;
            }
        }
    }

}

















