using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ennemi : MonoBehaviour
{

    public GameObject money;
    public GameObject bullet;
    public GameObject explosionParticles;

    public float timeBetweenShot;
    public float life;
    public enum EnemyType
    {
        Hexagone1,
        Ovale2,
        Losange3
    }
    public EnemyType enemyType;

    private float timeStamp = -1;
    private int nbMoneyDrop;

    // Start is called before the first frame update
    void Start()
    {
        switch (enemyType)
        {
            case EnemyType.Hexagone1:
                timeBetweenShot = Random.Range(5.0f, 10.0f);
                break;

            case EnemyType.Ovale2 :
                timeBetweenShot = Random.Range(3.0f, 5.0f);
                break;

            case EnemyType.Losange3 :
                timeBetweenShot = Random.Range(1.0f, 3.0f);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

        timeStamp += Time.deltaTime;

        if(life <= 0) 
        {

            Instantiate(explosionParticles, transform.position, Quaternion.Euler(0, 0, 0));
            transform.parent.GetComponent<groupEnnemi>().nombreEnnemi--;

            switch (enemyType)
            {
                case EnemyType.Hexagone1:
                    nbMoneyDrop = Random.Range(1, 3);
                    break;

                case EnemyType.Ovale2:
                    nbMoneyDrop = Random.Range(5, 7);
                    break;

                case EnemyType.Losange3:
                    nbMoneyDrop = Random.Range(15, 20);
                    break;
            }

            for (int i = 0; i <= nbMoneyDrop; i++)
            {
                Instantiate(money, transform.position, Quaternion.Euler(0, 0, 0));
            }

            FindObjectOfType<MovementEtTir>().score++;
            FindObjectOfType<MovementEtTir>().scoreText.text = "Score :" + FindObjectOfType<MovementEtTir>().score;

            Destroy(gameObject);
        }

        if(timeStamp >= timeBetweenShot)
        {

            timeStamp = 0;

            switch (enemyType)
            {
                case EnemyType.Hexagone1:
                    timeBetweenShot = Random.Range(5.0f, 10.0f);
                    break;

                case EnemyType.Ovale2:
                    timeBetweenShot = Random.Range(3.0f, 5.0f);
                    break;

                case EnemyType.Losange3:
                    timeBetweenShot = Random.Range(1.0f, 3.0f);
                    break;
            }

            Instantiate(bullet, transform.position, transform.rotation);

        }
        

    }
}
