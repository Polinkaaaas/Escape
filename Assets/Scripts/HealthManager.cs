using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealthlPlayer;
    public int maxHealthPet;
    private int currentHealthPlayer;
    private int currentHealthPet;

    public PlayerController thePlayer;
    public PetController thePet;
    public Image healthBarPlayer;
    public Image healthBarPet;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public TextMeshProUGUI deathText;
    //public TextMeshProUGUI deathPetText;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealthPlayer = maxHealthlPlayer;
        currentHealthPet = maxHealthPet;
        UpdateHealthBarPlayer();
       // thePlayer = FindObjectOfType<PlayerController>();

       respawnPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public async void HurtPlayer(int damage, Vector3? direction = null)
    {
        
        currentHealthPet -= damage;
        UpdateHealthBarPet();
        if (currentHealthPet <= 0)
        {
            Destroy(thePet);
            currentHealthPlayer -= damage;
            thePlayer.KnockBack(direction.Value);
            UpdateHealthBarPlayer();
            if (currentHealthPlayer <= 0)
            {
                deathText.text = "DEATH!";
                await Task.Delay(1000);
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
        
    }

   /* public async void HurtPlayer(int damage, Vector3? direction = null)
    {
        currentHealthPlayer -= damage;
        UpdateHealthBarPlayer();
            if (currentHealthPlayer <= 0)
            {
                deathText.text = "DEATH!";
                await Task.Delay(1000);
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

*/
    private void UpdateHealthBarPlayer()
    {
        healthBarPlayer.fillAmount = (float)currentHealthPlayer / maxHealthlPlayer;
    }
    private void UpdateHealthBarPet()
    {
        healthBarPet.fillAmount = (float)currentHealthPet / maxHealthPet;
    }

    //птица не может хилиться, только гг
    public void HealPlayer(int healAmount)
    {
            currentHealthPlayer += healAmount;
            UpdateHealthBarPlayer();
            if (currentHealthPlayer > maxHealthlPlayer)
            {
                currentHealthPlayer = maxHealthlPlayer;
            }
    }
}
