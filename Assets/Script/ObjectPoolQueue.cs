using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : ObjectPool {

    /// <summary>
    /// Sample for Object pooling
    /// </summary>

    Queue<GameObject> poolList;

    public override int pooledAmount {
        get {
            return poolList.Count;
        }
    }
    public override void Init(GameObject paramPrefabObject, int initialPooledAmount)
    {
        this.prefabObject = paramPrefabObject;
        poolList = new Queue<GameObject>();
        for (int i = 0; i < initialPooledAmount; i++) {
            GameObject tempObject = GameObject.Instantiate<GameObject>(this.prefabObject);
            tempObject.SetActive(false);
            tempObject.GetComponent<PoolableObject>().Init();
        }

    }

    GameObject tempObject;
    public override GameObject Place(Vector3 position)
    {
        if (poolList.Count > 0) {
            GameObject tempObject = poolList.Dequeue();
        }
        else {
            tempObject = GameObject.Instantiate<GameObject>(prefabObject);
        }
        tempObject.SetActive(true);
        tempObject.transform.position = position;
        return tempObject;

    }
    public override void ReturnToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        poolList.Enqueue(gameObject);
    }


}
