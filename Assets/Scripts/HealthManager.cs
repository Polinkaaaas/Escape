using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealthl;
    private int currentHealth;

    public PlayerController thePlayer;
    public Image healthBar;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public TextMeshProUGUI deathText;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealthl;
        UpdateHealthBar();
       // thePlayer = FindObjectOfType<PlayerController>();

        respawnPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public async void HurtPlayer(int damage, Vector3? direction = null)
    {
        currentHealth -= damage;
        UpdateHealthBar();
            if (currentHealth <= 0)
            {
                deathText.text = "DEATH!";
                await Task.Delay(3000);
                SceneManager.LoadScene(0);
            }
            else
            {
                if (direction != null)
                {
                    thePlayer.KnockBack(direction.Value);
                }
            }
        
    }


    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealthl;
    }

    /*public void Respawn()
    {
        thePlayer.transform.position = respawnPoint;
        currentHealth = maxHealthl;
    }
    */
    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealthl)
        {
            currentHealth = maxHealthl;
        }
    }
}
