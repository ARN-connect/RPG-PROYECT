using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableifaway : MonoBehaviour
{
    public GameObject Self;
    public static bool disabled = false;
    public Collider rad;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled)
            Self.SetActive (false);
        else
            Self.SetActive (true);
    }
// on collision enter name rad
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals ("Radius"))
        {
            disabled = true;
        }
    }
}
