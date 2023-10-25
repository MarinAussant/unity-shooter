using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class MovementEtTir : MonoBehaviour
{
    public GameObject bullet;

    public Transform parent;
    public Transform limitL;
    public Transform limitR;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI scoreText;

    public Rigidbody2D monRb;

    public float money;
    public int score;

    public float speed;
    public float speedShoot;
    public float life = 100;

    private float timeStamp = -1;



    // ========== VARIABLES SHOP ==============

    private int prixSpeedUpgrade = 10;
    private int prixShootSpeed = 10;
    private float prixPowerBullet = 100;
    public float prixNbBullet = 5;

    private int niveauSpeedUpgrade = 1;
    private int niveauShootSpeed = 1;
    private int niveauPowerBullet = 1;
    public int niveauNbBullet = 1;

    private float multiplierSpeedUpgrade = 1.15f;
    private float multiplierShootSpeed = 0.8f;
    private float multiplierPowerBullet = 2.0f;
    private int additionneurNbBullet = 1;

    private int niveauMaxSpeedUpgrade = 10;
    private int niveauMaxShootSpeed = 10;
    private int niveauMaxPowerBullet = 5;
    private int niveauMaxNbBullet = 5;

    // ==========  ==============


    // Start is called before the first frame update
    void Start()
    {
        monRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // =========== DEPLACEMENT ===============

        if (Input.GetKey(KeyCode.LeftArrow))
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

        // =========== TIR ===============

        timeStamp += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            if (timeStamp >= speedShoot)
            {
                timeStamp = 0;

                switch (niveauNbBullet)
                {
                    case 1:
                        Instantiate(bullet, parent.position, parent.rotation);
                        break;
                    case 2:
                        Instantiate(bullet, parent.position - (new Vector3(1, 0, 0) * 0.25f), parent.rotation);
                        Instantiate(bullet, parent.position + (new Vector3(1, 0, 0) * 0.25f), parent.rotation);
                        break;
                    case 3:
                        Instantiate(bullet, parent.position - (new Vector3(1, 0, 0) * 0.5f), parent.rotation);
                        Instantiate(bullet, parent.position, parent.rotation);
                        Instantiate(bullet, parent.position + (new Vector3(1, 0, 0) * 0.5f), parent.rotation);
                        break;
                    case 4:
                        Instantiate(bullet, parent.position - (new Vector3(1, 0, 0) * 0.75f), parent.rotation);
                        Instantiate(bullet, parent.position - (new Vector3(1, 0, 0) * 0.25f), parent.rotation); 
                        Instantiate(bullet, parent.position + (new Vector3(1, 0, 0) * 0.25f), parent.rotation);
                        Instantiate(bullet, parent.position + (new Vector3(1, 0, 0) * 0.75f), parent.rotation);
                        break;
                    case 5:
                        Instantiate(bullet, parent.position - (new Vector3(1, 0, 0) * 1), parent.rotation);
                        Instantiate(bullet, parent.position - (new Vector3(1, 0, 0) * 0.5f), parent.rotation);
                        Instantiate(bullet, parent.position, parent.rotation);
                        Instantiate(bullet, parent.position + (new Vector3(1, 0, 0) * 0.5f), parent.rotation);
                        Instantiate(bullet, parent.position + (new Vector3(1, 0, 0) * 1), parent.rotation);
                        break;
                }
                    

                

            }
        }

        // =========== TP BORD DE MAP ===============

        if (transform.position.x < limitL.position.x)
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }

        // =========== SHOP ===============

        // Ship Speed
        if (Input.GetKeyDown(KeyCode.J) && money >= prixSpeedUpgrade && niveauSpeedUpgrade < niveauMaxSpeedUpgrade)
        {
            speed *= multiplierSpeedUpgrade;
            money -= prixSpeedUpgrade;
            UpdateMoneyUI();
            prixSpeedUpgrade *= 2;
            niveauSpeedUpgrade++;
        }

        // Shot Speed
        if (Input.GetKeyDown(KeyCode.K) && money >= prixShootSpeed && niveauShootSpeed < niveauMaxShootSpeed)
        {
            speedShoot *= multiplierShootSpeed;
            money -= prixShootSpeed;
            UpdateMoneyUI();
            prixShootSpeed *= 2;
            niveauShootSpeed++;
        }

        // Bullet Power
        if (Input.GetKeyDown(KeyCode.L) && money >= prixPowerBullet && niveauPowerBullet < niveauMaxPowerBullet)
        {
            bullet.GetComponent<Bullet>().power *= multiplierPowerBullet;
            money -= prixPowerBullet;
            UpdateMoneyUI();
            prixPowerBullet *= 1.3f;
            niveauPowerBullet++;
        }

        // Bullet Number
        if (Input.GetKeyDown(KeyCode.H) && money >= prixNbBullet && niveauNbBullet < niveauMaxNbBullet)
        {
            money -= prixNbBullet;
            UpdateMoneyUI();
            prixNbBullet *= 1.3f;
            niveauNbBullet += additionneurNbBullet;
        }

    }

    private void UpdateMoneyUI()
    {
        moneyText.text = "Money :" + money;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Money")
        {

            Destroy(collision.gameObject);
            money++;
            UpdateMoneyUI();

        }
    }

}
