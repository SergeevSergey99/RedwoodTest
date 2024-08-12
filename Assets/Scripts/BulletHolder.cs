using UnityEngine;

public class BulletHolder : MonoBehaviour
{
    [field: SerializeField] public int BulletCount { get; private set; } = 5;

    public void Init(int bulletCount)
    {
        BulletCount = bulletCount;
    }
}