using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
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
    private SpriteRenderer playerRenderer;

    public float money;
    public int score;

    public float speed;
    public float speedShoot;
    public float life = 100;

    private float timeStamp = -1;
    private float timeStampToHeal = -1;



    // ========== VARIABLES SHOP ==============

    // --- UI ---
    public TextMeshProUGUI textSpeedUpgrade;
    public TextMeshProUGUI textShootSpeed;
    public TextMeshProUGUI textPowerBullet;
    public TextMeshProUGUI textNbBullet;

    // --- Var(s) ---
    private int prixSpeedUpgrade = 10;
    private int prixShootSpeed = 10;
    private int prixPowerBullet = 100;
    private int prixNbBullet = 100;

    private int niveauSpeedUpgrade = 1;
    private int niveauShootSpeed = 1;
    private int niveauPowerBullet = 1;
    private int niveauNbBullet = 1;

    private float multiplierSpeedUpgrade = 1.2f;
    private float multiplierShootSpeed = 0.8f;
    private float multiplierPowerBullet = 2.0f;
    private int additionneurNbBullet = 1;

    private int niveauMaxSpeedUpgrade = 10;
    private int niveauMaxShootSpeed = 10;
    private int niveauMaxPowerBullet = 5;
    private int niveauMaxNbBullet = 5;

    // =====================================


    // Start is called before the first frame update
    void Start()
    {
        monRb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();

        bullet.GetComponent<Bullet>().power = 1;
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
        if (Input.GetKeyDown(KeyCode.X) && money >= prixSpeedUpgrade && niveauSpeedUpgrade < niveauMaxSpeedUpgrade)
        {
            speed *= multiplierSpeedUpgrade;
            money -= prixSpeedUpgrade;
            UpdateMoneyUI();
            prixSpeedUpgrade *= 2;
            niveauSpeedUpgrade++;
            if(niveauSpeedUpgrade >= niveauMaxSpeedUpgrade)
            {
                textSpeedUpgrade.text = "MAX";
            }
            else
            {
                textSpeedUpgrade.text = prixSpeedUpgrade + " $";
            }
            
        }

        // Shot Speed
        if (Input.GetKeyDown(KeyCode.Z) && money >= prixShootSpeed && niveauShootSpeed < niveauMaxShootSpeed)
        {
            speedShoot *= multiplierShootSpeed;
            money -= prixShootSpeed;
            UpdateMoneyUI();
            prixShootSpeed *= 2;
            niveauShootSpeed++;
            if (niveauShootSpeed >= niveauMaxShootSpeed)
            {
                textShootSpeed.text = "MAX";
            }
            else
            {
                textShootSpeed.text = prixShootSpeed + " $";
            }
        }

        // Bullet Power
        if (Input.GetKeyDown(KeyCode.C) && money >= prixPowerBullet && niveauPowerBullet < niveauMaxPowerBullet)
        {
            bullet.GetComponent<Bullet>().power *= multiplierPowerBullet;
            money -= prixPowerBullet;
            UpdateMoneyUI();
            prixPowerBullet += 100;
            niveauPowerBullet++;
            if (niveauPowerBullet >= niveauMaxPowerBullet)
            {
                textPowerBullet.text = "MAX";
            }
            else
            {
                textPowerBullet.text = prixPowerBullet + " $";
            }
        }

        // Bullet Number
        if (Input.GetKeyDown(KeyCode.V) && money >= prixNbBullet && niveauNbBullet < niveauMaxNbBullet)
        {
            money -= prixNbBullet;
            UpdateMoneyUI();
            prixNbBullet += 1;
            niveauNbBullet += additionneurNbBullet;
            if (niveauNbBullet >= niveauMaxNbBullet)
            {
                textNbBullet.text = "MAX";
            }
            else
            {
                textNbBullet.text = prixNbBullet + " $";
            }
        }

        // =========== LIFE ===============

        playerRenderer.material.SetFloat("_Life", life/100);
        timeStampToHeal += Time.deltaTime;
        if(timeStampToHeal >= 0.5)
        {
            timeStampToHeal = 0;
            if(life < 100)
            {
                life += 1;
            }
        }

        if(life <= 0)
        {
            bullet.GetComponent<Bullet>().power = 1;
            SceneManager.LoadScene("GameOver");
        }

    }

    private void UpdateMoneyUI()
    {
        moneyText.text = money + " $";
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
