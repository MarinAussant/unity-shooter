using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class groupEnnemi : MonoBehaviour
{

    public int nombreEnnemi;
    public float speed;
    public Rigidbody2D monRb;
    public float distance;

    private Vector2 initPosition;

    // Start is called before the first frame update
    void Start()
    {
        nombreEnnemi = transform.childCount;
        monRb = GetComponent<Rigidbody2D>();
        monRb.velocity = Vector3.down/2 ;

    }

    // Update is called once per frame
    void Update()
    {
        if(nombreEnnemi <= 0)
        {
            Destroy(gameObject);
        }

          
    }
}
