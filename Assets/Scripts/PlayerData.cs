using System;
using System.Collections;
using System.Collections.Generic;
using CodeUtils;
using UnityEngine;

public class PlayerData : MonoSingleton<PlayerData>
{
    [field: SerializeField] public int MaxHealth { get; private set; } = 100;
    [field: SerializeField] public int StartBullets { get; private set; } = 5;
    
    private int _health;
    private int _bullets;
    
    #region events
    public static event Action<int> OnHealthChanged;
    public static event Action<int> OnBulletsChanged;
    #endregion

    public int Health
    {
        get => _health;
        set
        {
            _health = value; 
            OnHealthChanged?.Invoke(_health);
        }
    }
    public int Bullets
    {
        get => _bullets;
        set
        {
            _bullets = value; 
            OnBulletsChanged?.Invoke(_bullets);
        }
    }

    protected override void Init()
    {
        base.Init();
        Health = MaxHealth;
        Bullets = StartBullets;
    }
}
