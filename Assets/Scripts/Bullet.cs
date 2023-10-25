using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public float power;

    public Transform limitUP;

    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up*speed;
    }

    void Update()
    {
        if (transform.position.y > limitUP.position.y)
        {
            Destroy(gameObject);
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemi")
        {
            collision.gameObject.GetComponent<Ennemi>().life -= power;
            Destroy(gameObject);
        }
    }

}
