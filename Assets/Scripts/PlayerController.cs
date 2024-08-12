using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseCharacterController
{
    [Header("Shoot Settings")]
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDistance = 10f;
    [SerializeField] private LayerMask _shootLayer;
    
    private static readonly int SpeedKey = Animator.StringToHash("Speed");
    private static readonly int ShootKey = Animator.StringToHash("Shoot");

    bool _isShooting = false;
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        
        if (horizontal > 0 && _currentDirection != Vector2.right || horizontal < 0 && _currentDirection != Vector2.left)
            Flip();
        
        if (_isShooting) return;

        if (Input.GetMouseButton(0) && PlayerData.Instance.BulletCount > 0)
        {
            _isShooting = true;
            _animator.SetTrigger(ShootKey);
            horizontal = 0;
        }
        
        _animator.SetFloat(SpeedKey, Mathf.Abs(horizontal));
        Move(Mathf.Abs(horizontal));
    }
    public void Shoot()
    {
        if (!_isShooting) return;
        PlayerData.Instance.BulletCount--;
        _isShooting = false;
        var hit = Physics2D.Raycast(_shootPoint.position, _currentDirection, _shootDistance, _shootLayer);
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<EnemyController>(out var enemy))
            {
                enemy.Damage();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyController>(out var enemy))
        {
            PlayerData.OnPlayerDie?.Invoke();
        }
        else if (other.TryGetComponent<BulletHolder>(out var bullet))
        {
            PlayerData.Instance.BulletCount += bullet.BulletCount;
            Destroy(bullet.gameObject);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_shootPoint.position, 0.1f);
        Gizmos.DrawLine(_shootPoint.position, _shootPoint.position + (Vector3)_currentDirection * _shootDistance);
    }

    public void ResetPlayer(Vector3 playerStartPosition)
    {
        transform.position = playerStartPosition;
        if (_currentDirection != Vector2.right)
            Flip();
        _isShooting = false;
    }
}
