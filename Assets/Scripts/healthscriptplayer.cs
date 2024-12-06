using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthscriptplayer : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (healthAmount <= 0)
        //{
        //    Application.Loadlevel(Application.loadedlevel);
        //}

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Takedamage(20);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(5);
        }
    }
    public void Takedamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }

}
