 using UnityEngine;
 using System.Collections;
 
 public class autodestroy : MonoBehaviour {
     public float delay = 0f;
     public float rotation;
     public int angleint;
 
    public float posx;
    public float posy;
    public float mouseposx;
    public float mouseposy;

    void Update () 
    {
        posx = transform.position.x;
        posy = transform.position.y;
         
        Vector3 mousePos = Input.mousePosition;
        {
            mouseposx = mousePos.x;
            mouseposy = mousePos.y;
        }

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
         
        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
         
        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(mouseOnScreen, positionOnScreen);
        rotation = angle;
        angleint = (int)Mathf.Round(rotation);
        //Ta Daaa
        Vector3 p = transform.position;
        transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
        p.y = mouseposy;
        p.x = mouseposx;
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
        
    void Start () {
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - delay); 
    }
}