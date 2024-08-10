using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCanvasView : MonoBehaviour
{
    [SerializeField] private TMP_Text _bulletsText;
    
    void Start()
    {
        PlayerData.OnBulletsChanged += SetBulletsText;
        
        SetBulletsText(PlayerData.Instance.Bullets);
    }
    
    void SetBulletsText(int bullets)
    {
        _bulletsText.text = $"{bullets}";
    }

    private void OnDestroy()
    {
        PlayerData.OnBulletsChanged -= SetBulletsText;
    }
}
