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

    private float timeStamp = -1;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShot = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {

        timeStamp += Time.deltaTime;

        if(life <= 0) 
        {
            Instantiate(explosionParticles, transform.position, Quaternion.Euler(0, 0, 0));
            //transform.parent.GetComponent<groupEnnemi>().nombreEnnemi--;
            Destroy(gameObject);
            for (int i = 0; i <= Random.Range(1, 3); i++)
            {
                Instantiate(money, transform.position, Quaternion.Euler(0, 0, 0));
            }
            FindObjectOfType<MovementEtTir>().score++;
            FindObjectOfType<MovementEtTir>().scoreText.text = "Score :" + FindObjectOfType<MovementEtTir>().score;
        }

        if(timeStamp >= timeBetweenShot)
        {
            timeStamp = 0;
            timeBetweenShot = Random.Range(1.0f, 10.0f);
            Instantiate(bullet, transform.position, transform.rotation);
        }
        

    }
}
