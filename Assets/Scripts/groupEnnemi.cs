using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class groupEnnemi : MonoBehaviour
{

    public int nombreEnnemi;
    public float speed;
    private Rigidbody2D monRb;
    public Transform limitDown;

    // Start is called before the first frame update
    void Start()
    {
        nombreEnnemi = transform.childCount;
        monRb = GetComponent<Rigidbody2D>();
        monRb.velocity = Vector3.down * speed;

    }

    // Update is called once per frame
    void Update()
    {
        if(nombreEnnemi <= 0)
        {
            Destroy(gameObject);
        }

        if(transform.position.y < limitDown.position.y - 4)
        {
            Destroy(gameObject);
        }
          
    }
}
