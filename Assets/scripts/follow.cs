using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    [SerializeField] private GameObject Player2;        //Drag your player game object here for its position
    [SerializeField] private float radius = 3;              //Set radius here

    public float mposx;
    public float mposy;

    public GameObject sword;
    public Animator sword_anim;
    public GameObject pick;
    public Animator pick_anim;
    
    public int tool;
    public int swords;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        swords = GameObject.FindGameObjectsWithTag("swords").Length;
        tool = GameObject.FindGameObjectsWithTag("tool").Length;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(swords == 0)
            {
                Instantiate(sword, new Vector3(mposx, mposy, -3), Quaternion.identity);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (tool == 0)
            {
                Instantiate(pick, new Vector3(mposx, mposy, -3), Quaternion.identity);
            }
        }


        mposx = Mathf.RoundToInt(transform.position.x);
        mposy = Mathf.RoundToInt(transform.position.y);

        
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        Vector3 playerPos = Player2.transform.position;

        Vector3 playerToCursor = cursorPos - playerPos;
        Vector3 dir = playerToCursor.normalized;
        Vector3 cursorVector = dir * radius;

        if (playerToCursor.magnitude < cursorVector.magnitude) // detect if mouse is in inner radius
            cursorVector = playerToCursor;

        transform.position = playerPos + cursorVector;
    }
}