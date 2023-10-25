using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class groupEnnemi : MonoBehaviour
{

    public int nombreEnnemi;
    public float speed;
    public GameObject groupSuivant;
    public Rigidbody2D monRb;
    public float distance;

    private Vector2 initPosition;

    // Start is called before the first frame update
    void Start()
    {
        nombreEnnemi = transform.childCount;
        monRb = GetComponent<Rigidbody2D>();
        monRb.velocity = Vector3.right * speed;
        initPosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(nombreEnnemi <= 0)
        {
            Instantiate(groupSuivant,new Vector3(groupSuivant.transform.position.x, groupSuivant.transform.position.y, 0), Quaternion.Euler(0,0,0));
            Destroy(gameObject);
        }

        if(transform.position.x > distance + initPosition.x)
        {
            monRb.velocity = Vector3.left * speed;
        }
        if (transform.position.x < -distance + initPosition.x) 
        {
            monRb.velocity = Vector3.right * speed;
        }
          
    }
}
