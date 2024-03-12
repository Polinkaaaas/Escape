using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Thirst : MonoBehaviour
{
    public float maxThirst = 100f; // Максимальное количество жажды
    public float thirstDecreaseRate = 1f; // Скорость снижения жажды в единицы в секунду
    public float healthDecreaseRate = 2f; // Скорость снижения здоровья в единицы в секунду при нулевой жажде
    public float damageInterval = 1f; // Интервал времени между нанесением урона при нулевой жажде
    public float delayBeforeStartDecrease = 5f; // Задержка перед началом снижения уровня жажды

    public Image thirstBar; // Прогресс бар для отображения жажды

    private float currentThirst; // Текущее количество жажды
    private float nextDamageTime; // Время следующего нанесения урона при нулевой жажде
    private float startTime; // Время запуска игры
    
    public delegate void ThirstUpdateEventHandler();
    public static event ThirstUpdateEventHandler OnThirstUpdate;
    

    private void Start()
    {
        currentThirst = maxThirst;
        UpdateThirstBar();
        startTime = Time.time;
        nextDamageTime = Time.time + damageInterval;
        StartCoroutine(ThirstDecrease());
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "DesertScene")
        {
            InitializeThirstLogic();
        }
    }
    public void InitializeThirstLogic()
    {
        currentThirst = maxThirst;
        UpdateThirstBar();
        startTime = Time.time;
        nextDamageTime = Time.time + damageInterval;
        StartCoroutine(ThirstDecrease());
    }
    private void Update()
    {
        if (currentThirst <= 0)
        {
            if (Time.time >= nextDamageTime)
            {
                FindObjectOfType<HealthManager>().HurtPlayer(100); // Нанесение урона главному герою
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }

    IEnumerator ThirstDecrease()
    {
        yield return new WaitForSeconds(delayBeforeStartDecrease); // Ожидание перед началом снижения уровня жажды

        while (true)
        {
            yield return new WaitForSeconds(1f);
            currentThirst -= thirstDecreaseRate;
            UpdateThirstBar();

            if (currentThirst <= 0)
            {
                FindObjectOfType<HealthManager>().HurtPlayer(100); // Нанесение урона главному герою
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }
    
    void UpdateThirstBar()
    {
        thirstBar.fillAmount = (float) currentThirst / maxThirst;
        if (OnThirstUpdate != null)
            OnThirstUpdate();
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}


