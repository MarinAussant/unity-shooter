using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ennemi : MonoBehaviour
{

    public GameObject money;
    public GameObject bullet;

    public float timeBetweenShot;
    public int life;

    private float timeStamp = -1;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShot = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0) 
        {
            transform.parent.GetComponent<groupEnnemi>().nombreEnnemi--;
            Destroy(gameObject);
            for (int i = 0; i <= Random.Range(1, 3); i++)
            {
                Instantiate(money, transform.position, Quaternion.Euler(0, 0, 0));
            }
            FindObjectOfType<MovementEtTir>().score++;
            FindObjectOfType<MovementEtTir>().scoreText.text = "Score :" + FindObjectOfType<MovementEtTir>().score;
        }

        if(timeStamp <= Time.time)
        {
            timeStamp = Time.time + timeBetweenShot;
            Instantiate(bullet, transform.position, transform.rotation);
        }
        

    }
}
