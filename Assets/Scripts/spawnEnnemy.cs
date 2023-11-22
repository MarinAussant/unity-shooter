using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class spawnEnnemy : MonoBehaviour
{

    public GameObject[] normalEnemyPrefabs;
    public GameObject[] bossEnemyPrefabs;

    private float timeToSpawn = 11f;
    private float timeStamp = 0.0f;
    public int nbSpawnMob = 0; 

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeStamp += Time.deltaTime;

        if(timeStamp >= timeToSpawn)
        {
            if (nbSpawnMob % 10 == 9)
            {
                if (timeToSpawn > 2)
                {
                    timeToSpawn -= 2;
                }

                Instantiate(bossEnemyPrefabs[Random.Range(0, bossEnemyPrefabs.Length)], new Vector2(Random.Range(transform.position.x - (spriteRenderer.bounds.size.x / 2), transform.position.x + (spriteRenderer.bounds.size.x / 2)), transform.position.y), Quaternion.Euler(0, 0, 0));
               
            }
            else
            {
                Instantiate(normalEnemyPrefabs[Random.Range(0, normalEnemyPrefabs.Length)], new Vector2(Random.Range(transform.position.x - (spriteRenderer.bounds.size.x / 2), transform.position.x + (spriteRenderer.bounds.size.x / 2)), transform.position.y), Quaternion.Euler(0, 0, 0));
            }
            timeStamp = 0.0f;
            nbSpawnMob++;
        }

        
    }
}
