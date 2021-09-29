using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildwater : MonoBehaviour
{
    public float posx;
    public float posy;

    void Start()
    {
        posx = transform.position.x;
        posy = transform.position.y;

        Instantiate(gameObject, new Vector3(posx, posy, -2), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
