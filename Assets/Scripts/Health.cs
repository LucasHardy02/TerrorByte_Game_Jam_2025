using UnityEngine;
using TMPro;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject player;

    public int maxHealth = 3;
    public int curHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    void Start()
    {
        curHealth = maxHealth;
        gameOver.SetActive(false);
        UpdateHearts();
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth == 0)
        {
            gameOver.SetActive(true);
            player.SetActive(false);
        }

        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < curHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            curHealth = curHealth - 1;
        }
        if (other.CompareTag("Checkpoint"))
        {
            curHealth = curHealth + 3;
        }
    }

    public void TakeDamage(int amount)
    {
        curHealth -= amount;
        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
        UpdateHearts();
    }

    public void Heal(int amount)
    {
        curHealth += amount;
        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
        UpdateHearts();
    }
}



