using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : ObjectPool {

    /// <summary>
    /// Sample for Object pooling
    /// </summary>

    Queue<PoolableObject> poolList;

    public override int pooledAmount {
        get {
            return poolList.Count;
        }
    }
    PoolableObject tempObject;
    public override void Init(PoolableObject paramPoolableObject, int initialPooledAmount)
    {
        this.poolableObject = paramPoolableObject;
        poolList = new Queue<PoolableObject>();
        for (int i = 0; i < initialPooledAmount; i++) {
            tempObject = Instantiate(poolableObject);
            tempObject.objectPool = this;
            tempObject.gameObject.SetActive(false);
            poolList.Enqueue(tempObject);
        }
    }
    public override GameObject Place(Vector3 position)
    {
        if (poolList.Count > 0) {
            tempObject = poolList.Dequeue();
        }
        else {
            tempObject = Instantiate(poolableObject);
        }
        tempObject.gameObject.SetActive(true);
        tempObject.transform.position = position;
        return tempObject.gameObject;

    }
    public override void ReturnToPool(PoolableObject poolableObject)
    {
        poolableObject.gameObject.SetActive(false);
        poolList.Enqueue(poolableObject);
    }


}
