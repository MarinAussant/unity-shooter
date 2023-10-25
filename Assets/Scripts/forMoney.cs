using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forMoney : MonoBehaviour
{

    public Rigidbody2D myRb;

    // Start is called before the first frame update
    void Start()
    {
        myRb.AddForce(new Vector2(Random.Range(-100,100), Random.Range(20, 70)));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < FindObjectOfType<MovementEtTir>().gameObject.transform.position.y - 3)
        {
            Destroy(gameObject);
        }
    }
}
