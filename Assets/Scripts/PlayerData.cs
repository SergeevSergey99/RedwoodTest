using System;
using System.Collections;
using System.Collections.Generic;
using CodeUtils;
using UnityEngine;

public class PlayerData : MonoSingleton<PlayerData>
{
    [field: SerializeField] public int StartBullets { get; private set; } = 5;
    
    private int _bullets;
    
    #region events
    public static event Action<int> OnBulletsChanged;
    public static event Action OnGameOver;
    #endregion
    public int Bullets
    {
        get => _bullets;
        set
        {
            _bullets = value; 
            OnBulletsChanged?.Invoke(_bullets);
            
            if (_bullets == 0)
                OnGameOver?.Invoke();
        }
    }

    protected override void Init()
    {
        base.Init();
        Bullets = StartBullets;
    }
}
