using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementEtTir : MonoBehaviour
{
    public GameObject bullet;

    public Transform parent;
    public Transform limitL;
    public Transform limitR;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI scoreText;

    public Rigidbody2D monRb;

    public int money;
    public int score;

    public float speed;
    public float speedShoot;
    public float life = 100;

    private float timeStamp = -1;

    // Start is called before the first frame update
    void Start()
    {
        monRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            monRb.velocity = Vector3.left * speed;
            //transform.position += Vector3.left*speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            monRb.velocity = Vector3.right * speed;
            //transform.position += Vector3.right*speed;
        }
        else
        {
            monRb.velocity = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (timeStamp <= Time.time)
            {
                timeStamp = Time.time + speedShoot;
                Instantiate(bullet, parent.position, parent.rotation);

            }
        }

        if(transform.position.x < limitL.position.x)
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Money")
        {

            Destroy(collision.gameObject);
            money++;
            moneyText.text = "Money :" + money;

        }
    }

}
