using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnnemi : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public int power;

    public Transform limitDOWN;

    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.down * speed;
    }

    void Update()
    {

        if (transform.position.y < limitDOWN.position.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<MovementEtTir>().life -= power;
            Destroy(gameObject);
        }
    }
}
