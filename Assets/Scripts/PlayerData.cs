using System;
using System.Collections;
using System.Collections.Generic;
using CodeUtils;
using UnityEngine;

public class PlayerData : MonoSingleton<PlayerData>
{
    [SerializeField]
    private int _bulletCount = 10;

    private int _startBulletCount;
    public int BulletCount
    {
        get => _bulletCount; 
        set
        {
            _bulletCount = value;
            OnBulletCountChanged?.Invoke(_bulletCount);
            
            if (_bulletCount <= 0)
                OnPlayerDie?.Invoke();
        }
    }

    protected override void Init()
    {
        base.Init();
        _startBulletCount = _bulletCount;
    }
    
    public void Reset()
    {
        BulletCount = _startBulletCount;
    }

    #region events
    
    public static Action<int> OnBulletCountChanged;
    public static Action OnPlayerDie;

    #endregion
}
