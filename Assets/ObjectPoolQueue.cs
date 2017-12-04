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
    public override void Init(GameObject prefabObject, int initialPooledAmount)
    {
        this.prefabObject = prefabObject;
        poolList = new Queue<GameObject>();
        for (int i = 0; i < initialPooledAmount; i++) {
            GameObject tempObject = GameObject.Instantiate<GameObject>(prefabObject);
            tempObject.SetActive(false);
        }

    }

    GameObject tempObject;
    public override void Place(Vector3 position)
    {
        if (poolList.Count > 0) {
            GameObject tempObject = poolList.Dequeue();
        }
        else {
            tempObject = GameObject.Instantiate<GameObject>(prefabObject);
        }
        tempObject.SetActive(true);
        tempObject.transform.position = position;

    }
    public override void ReturnToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        poolList.Enqueue(gameObject);
    }


}
