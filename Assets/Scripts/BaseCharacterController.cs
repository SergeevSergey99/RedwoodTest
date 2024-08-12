
using UnityEngine;

public class BaseCharacterController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected Animator _animator;
    [Header("Parameters")]
    [SerializeField] protected float _speed = 5f;
    
    [Header("Other Settings")]
    [SerializeField] protected Vector2 _currentDirection = Vector2.right;
    
    public Vector2 CurrentDirection => _currentDirection;

    protected void Move(float multiplier = 1)
    {
        transform.Translate(_currentDirection * (_speed * Time.deltaTime * multiplier), Space.World);
    }

    public void Flip()
    {
        _currentDirection *= -1;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnValidate()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();
    }
}