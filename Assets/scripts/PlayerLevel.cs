using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour {
    public int Level;
    public float CurrentExperience = 10;
    public int RequiredExperience = 25;
    public float Percent;
    public Fill fill;
    public Text level_text;

    void Start () {
        //CombatEvents.OnEnemyDeath += EnemyToExperience;
        Level = 1;
	}

    void Update()
    {
        RequiredExperience = (Level * 25) * (10 * Level);

        if(CurrentExperience >= RequiredExperience)
        {
            Level = Level + 1;
        }

        Percent = CurrentExperience / RequiredExperience ;

        fill.Refill(Percent);
        fill.LevelFill(Level);
        level_text.text = "Nivel" + Level;
    }

    public void GrantExperience(int amount)
    {
        CurrentExperience += amount;
    }
}