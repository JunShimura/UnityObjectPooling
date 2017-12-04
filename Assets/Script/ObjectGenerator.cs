using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class ObjectGenerator : MonoBehaviour {

    /// <summary>
    /// Sample for Object pooling
    /// </summary>

    [SerializeField]
    PoolableObject prefab;

    [SerializeField]
    int initialAmount;

    [SerializeField]
    int width;

    ObjectPoolQueue objectPool;

    int activeCount = 0;
    int generateRate = 10;

    // Use this for initialization
    void Start()
    {
        objectPool = GetComponent<ObjectPoolQueue>();
        objectPool.Init(prefab, initialAmount);
    }

    // Update is called once per frame
    GameObject tempObject;
    int count = 0;

    void Update()
    {
        count++;
        tempObject = objectPool.Place(
            this.transform.position
            + Vector3.right * (count % width));
    }
}
