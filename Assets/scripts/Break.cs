using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject prefab_replace;
    public Collision2D col;

    public float posxmouse;
    public float posymouse;
    public float posx;
    public float posy;


    public GameObject parent;
    void Start()
    {
        parent = GameObject.FindWithTag("ParentBlock");
    }

    //public void creategroup()
    //{
    //    GameObject parent = new GameObject(parent);
    ////    parent.transform.parent = gameObject.transform;
    //    parent.transform.localPosition = new Vector3(0, 0, 0);
    //}

    void Update()
    {
        posxmouse = Mathf.RoundToInt(GameObject.FindWithTag("cursor").transform.position.x);
        posymouse = Mathf.RoundToInt(GameObject.FindWithTag("cursor").transform.position.y);
        
        posx = Mathf.RoundToInt(transform.position.x);
        posy = Mathf.RoundToInt(transform.position.y);

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (posx == posxmouse)
            {
                if (posy == posymouse)
                {
                    Destroy(gameObject);
                    GameObject replace = Instantiate(prefab_replace, new Vector3(posx, posy, 0), Quaternion.identity);
                    replace.name = string.Format("tile_x{0}_y{1}", posx, posy, 0);
                    replace.transform.SetParent(parent.transform);
                }
            }
        }
    }

}
