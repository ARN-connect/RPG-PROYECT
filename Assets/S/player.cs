using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [Header("Player Attributes")]

    public float speed = 4f;
    public float speed_add = 1.0f;
	public int maxHealth;
	public int currentHealth;
	public int maxMana = 140;
	public int currentMana = 140;
    public bool corriendo = false;
    
	public HealthBarScript healthBar;
	public manabar manabar;

    [Header("Anim Manage")]

    public Rigidbody2D rb;
    public Animator animator;
    public Slider slider;
    public GameObject dead_particle;

    [Header("Text Stats")]

    public Text mana_text;
    public Text health_text;

    [Header("Canvas")]

    public Canvas MyCanvas;
    public SaveData activeSave;

    [Header("Player Stats")]

    public float posx;
    public float posy;

    public float mouseposx;
    public float mouseposy;

    public int armor;
    public int luck;
    public int defense;
    public int mage;
    public int strengh;


    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    Vector2 movement;
    void Update()
    {   
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            save();
        }
        Vector3 mousePos = Input.mousePosition;
        {
            mouseposx = mousePos.x;
            mouseposy = mousePos.y;
        }

        posx = transform.position.x;
        posy = transform.position.y;


        statsText();
        if ( currentMana > maxMana)
        {
            currentMana = maxMana;
        }

        if ( currentMana <2 )
        {
            speed_add = 1.0f;
            corriendo = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if ( currentMana > 2)
            {
                corriendo = true;
                speed_add = 1.4f;
            }
        }
        
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            corriendo = false;
            speed_add = 1.0f;
        }

		healthBar.maxLive(maxHealth);
		healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
		manabar.maxManama(maxMana);
		manabar.SetMaxMana(maxMana);
        manabar.SetMana(currentMana);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (animator.GetFloat("Speed")  < 1)
        {
            corriendo = false;
            speed_add = 1.0f;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(dead_particle, transform.position, Quaternion.Euler(new Vector3(-45, 0, 0)));
        }
        if (Input.GetKeyDown(KeyCode.F1))
		{
            if (currentHealth < maxHealth)
			{
                heal(10);
            }
		}

        if (currentMana < maxMana / 2)
        {
            StartCoroutine(RegenMana());
        }

    }

    private IEnumerator RegenMana()
    {
        yield return new WaitForSecondsRealtime(5);

        while(currentMana < maxMana)
        {
            currentMana += maxMana / 100;
            yield return new WaitForSecondsRealtime(5);
        }
    }

    void statsText()
    {
        mana_text.text = maxMana + " / " + currentMana;
        health_text.text = maxHealth + " / " + currentHealth;
    }
	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}

	void heal(int damage)
	{
		currentHealth += damage;

		healthBar.SetHealth(currentHealth);
	}

	void ConsumeMana(int consume)
	{
		currentMana -= consume;

		manabar.SetMana(currentMana);
	}


	void mana(int consume)
	{
		currentMana += consume;

		manabar.SetMana(currentMana);
	}

    void FixedUpdate()
    {

        if ( corriendo == true)
        {
            currentMana -= 1;
        }
        rb.MovePosition(rb.position + movement * speed * UnityEngine.Time.deltaTime * speed_add);
    }
    
    public void save()
    {
        string dataPath = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + activeSave.SaveName + ".save", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();

        Debug.Log("Saved!");
    }
}
  [System.Serializable]
public class SaveData
{
    public string SaveName;
    public Vector3 postion;
}
