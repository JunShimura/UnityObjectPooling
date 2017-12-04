using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool :MonoBehaviour{

    /// <summary>
    /// Pooling base
    /// </summary>
    protected GameObject prefabObject;
    public abstract int pooledAmount { get; }
    public abstract void Init(GameObject prefab, int initialAmount);
    public abstract GameObject Place(Vector3 position);
    public abstract void ReturnToPool(GameObject gameObject);

}