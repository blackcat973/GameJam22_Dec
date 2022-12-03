using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    PlayerMove Player;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Player.PlayerHealth;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
