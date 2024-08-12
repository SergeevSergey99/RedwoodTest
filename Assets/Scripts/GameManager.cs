using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private EnemySpawner _enemySpawner;
    
    private Vector3 _playerStartPosition;
    private void OnEnable()
    {
        _playerStartPosition = _playerController.transform.position;
        PlayerData.OnPlayerDie += GameOver;
    }
    
    private void OnDisable()
    {
        PlayerData.OnPlayerDie -= GameOver;
    }
    
    void GameOver()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void RestartGame()
    {
        EnemiesPool.ReturnAllObjects();
        _gameOverPanel.SetActive(false);
        _playerController.ResetPlayer(_playerStartPosition);
        _enemySpawner.ReStart();
        PlayerData.Instance.Reset();
        Time.timeScale = 1;
    }
    
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void OnValidate()
    {
        if (_playerController == null)
            _playerController = FindFirstObjectByType<PlayerController>();
        
        if (_enemySpawner == null)
            _enemySpawner = FindFirstObjectByType<EnemySpawner>();
            
    }
}