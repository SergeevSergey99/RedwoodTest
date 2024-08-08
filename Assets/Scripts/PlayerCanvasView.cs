using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCanvasView : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _bulletsText;
    
    void Start()
    {
        PlayerData.OnHealthChanged += SetHealthText;
        PlayerData.OnBulletsChanged += SetBulletsText;
        
        SetHealthText(PlayerData.Instance.Health);
        SetBulletsText(PlayerData.Instance.Bullets);
    }
    
    void SetHealthText(int health)
    {
        _healthText.text = $"{health} / {PlayerData.Instance.MaxHealth}";
    }
    
    void SetBulletsText(int bullets)
    {
        _bulletsText.text = $"{bullets}";
    }

    private void OnDestroy()
    {
        PlayerData.OnHealthChanged -= SetHealthText;
        PlayerData.OnBulletsChanged -= SetBulletsText;
    }
}
