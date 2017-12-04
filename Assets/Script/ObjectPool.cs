using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool :MonoBehaviour{

    /// <summary>
    /// Pooling base
    /// </summary>
    protected PoolableObject poolableObject;
    public abstract int pooledAmount { get; }
    public abstract void Init(PoolableObject prefab, int initialAmount);
    public abstract GameObject Place(Vector3 position);
    public abstract void ReturnToPool(PoolableObject gameObject);

}