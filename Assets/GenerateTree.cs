using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTree : MonoBehaviour
{
    public int percent;
    public int maxrange = 10;
    public int mintreeHeight;
    public int maxtreeHeight;
    public GameObject parent;
    public GameObject log;
    public GameObject leave;
    public float posx;
    public float posy;

    void Start()
    {
        parent = GameObject.FindWithTag("ParentBlock");
        posx = Mathf.RoundToInt(transform.position.x);
        posy = Mathf.RoundToInt(transform.position.y);

        percent = Random.Range(1, maxrange);
        
        if( percent == 1 )
        {
            GenerateTrees();
        }
    }

    // Update is called once per frame
    public void GenerateTrees()
    {
        int treeHeight = Random.Range(mintreeHeight, maxtreeHeight);
        for (int i = 0; i < treeHeight; i++)
        {
            GameObject replace = Instantiate(log, new Vector3(posx , posy + i, 0), Quaternion.identity);
            replace.name = string.Format("tile_x{0}_y{1}", posx, posy, 0);
            replace.transform.SetParent(parent.transform);
        }
        GameObject leaves = Instantiate(leave, new Vector3(posx , posy + treeHeight, 0), Quaternion.identity); //top
        GameObject leaves2 = Instantiate(leave, new Vector3(posx , posy + treeHeight + 1, 0), Quaternion.identity); //top
        GameObject leaves3 = Instantiate(leave, new Vector3(posx , posy + treeHeight + 2, 0), Quaternion.identity); //top
        GameObject leaves4 = Instantiate(leave, new Vector3(posx - 1, posy + treeHeight, 0), Quaternion.identity); //right
        GameObject leaves5 = Instantiate(leave, new Vector3(posx - 1, posy + treeHeight + 1, 0), Quaternion.identity); //right
        GameObject leaves6 = Instantiate(leave, new Vector3(posx + 1, posy + treeHeight, 0), Quaternion.identity); //left
        GameObject leaves7 = Instantiate(leave, new Vector3(posx + 1, posy + treeHeight + 1, 0), Quaternion.identity); //left
        leaves.name = string.Format("tile_x{0}_y{1}", posx, posy, 0);
        leaves.transform.SetParent(parent.transform);
        leaves2.name = string.Format("tile_x{0}_y{1}", posx, posy, 0);
        leaves2.transform.SetParent(parent.transform);
        leaves3.name = string.Format("tile_x{0}_y{1}", posx, posy, 0);
        leaves3.transform.SetParent(parent.transform);
        leaves4.name = string.Format("tile_x{0}_y{1}", posx, posy, 0);
        leaves4.transform.SetParent(parent.transform);
        leaves5.name = string.Format("tile_x{0}_y{1}", posx, posy, 0);
        leaves5.transform.SetParent(parent.transform);
        leaves6.name = string.Format("tile_x{0}_y{1}", posx, posy, 0);
        leaves6.transform.SetParent(parent.transform);
        leaves7.name = string.Format("tile_x{0}_y{1}", posx, posy, 0);
        leaves7.transform.SetParent(parent.transform);
    }
}
