using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill : MonoBehaviour
{
    public Image perBar;
    public float percent;
    public int level;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        perBar.fillAmount = percent;
    }

    public void Refill(float v)
    {
        percent = v;
    }

    
    public void LevelFill(int i)
    {
        level = i;
    }
}
