using UnityEngine;

public class Enemy
{
    public string prefabPath;

    public PoolBase<GameObject> pool;

    public Enemy(string prefabPath, PoolBase<GameObject> pool)
    {
        this.prefabPath = prefabPath;
        this.pool = pool;
    }
}