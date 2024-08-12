using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemySO> _enemies = new List<EnemySO>();
    [SerializeField] private float _minSpawnTime = 1;
    [SerializeField] private float _maxSpawnTime = 3;
    
    [SerializeField] private Transform _leftSpawnPoint;
    [SerializeField] private Transform _rightSpawnPoint;
    
    Coroutine _spawnCoroutine;
    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnEnemy());
    }
    public void ReStart()
    {
        StopCoroutine(_spawnCoroutine);
        Start();
    }
    
    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            var enemy = _enemies[Random.Range(0, _enemies.Count)];
            var newEnemy = EnemiesPool.GetObject();
            
            bool isLeft = Random.Range(0, 2) == 0;

            newEnemy.transform.position = isLeft ? _leftSpawnPoint.position : _rightSpawnPoint.position;
            newEnemy.Init(enemy);
            
            if (newEnemy.CurrentDirection == Vector2.left && isLeft || newEnemy.CurrentDirection == Vector2.right && !isLeft)
                newEnemy.Flip();
            
            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_leftSpawnPoint.position, 0.3f);
        Gizmos.DrawWireSphere(_rightSpawnPoint.position, 0.3f);
    }
}
