using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObjects/EnemySO", order = 0)]
public class EnemySO : ScriptableObject
{
    [field: SerializeField]
    public int Health { get; private set; } = 3;
    [field: SerializeField] 
    public float Speed { get; private set; } = 1;
    
    [field: SerializeField]
    public RuntimeAnimatorController AnimatorController { get; private set; }
}
