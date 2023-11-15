using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeDestroy : MonoBehaviour
{

    private float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeStamp += Time.deltaTime;
        if (timeStamp > 1)
        {
            Destroy(gameObject);
        }
    }
}
