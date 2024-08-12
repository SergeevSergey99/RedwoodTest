using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyController : BaseCharacterController
{
    [SerializeField] private Image _healthBar;
    [Header("Bullet")]
    [SerializeField] private int _minBulletCount = 3;
    [SerializeField] private int _maxBulletCount = 7;
    private EnemySO _enemy;
    private int _health = 3;
    private float _autoDieTime = 15;
    Coroutine _autoDieCoroutine;
    private void Update()
    {
        Move();
    }

    public void Damage()
    {
        _health--;
        _healthBar.fillAmount = (float)_health / _enemy.Health;
        if (_health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        StopCoroutine(_autoDieCoroutine);
        var bulletsItem = BulletPool.GetObject();
        bulletsItem.Init(Random.Range(_minBulletCount, _maxBulletCount));
        bulletsItem.transform.position = transform.position;
        EnemiesPool.ReturnObject(this);
    }

    public void Init(EnemySO enemy)
    {
        _enemy = enemy;
        _health = enemy.Health;
        _healthBar.fillAmount = 1;
        _speed = enemy.Speed;
        _animator.runtimeAnimatorController = enemy.AnimatorController;
        
        if (_autoDieCoroutine != null) StopCoroutine(_autoDieCoroutine);
        _autoDieCoroutine = StartCoroutine(AutoDie());
    }
    
    IEnumerator AutoDie()
    {
        yield return new WaitForSeconds(_autoDieTime);
        Die();
    }

    private void OnDisable()
    {
        if (_autoDieCoroutine != null)
            StopCoroutine(_autoDieCoroutine);
    }
}