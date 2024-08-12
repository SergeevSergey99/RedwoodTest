using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDataView : MonoBehaviour
{
    [SerializeField] private TMP_Text _bulletCountText;
    
    private void OnEnable()
    {
        PlayerData.OnBulletCountChanged += OnBulletCountChanged;
        OnBulletCountChanged(PlayerData.Instance.BulletCount);
    }
    
    private void OnBulletCountChanged(int bulletCount)
    {
        _bulletCountText.text = bulletCount.ToString();
    }
    
    private void OnDisable()
    {
        PlayerData.OnBulletCountChanged -= OnBulletCountChanged;
    }
}
