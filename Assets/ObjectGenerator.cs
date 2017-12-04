using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class ObjectGenerator : MonoBehaviour {

    /// <summary>
    /// Sample for Object pooling
    /// </summary>

    [SerializeField]
    GameObject prefab;

    [SerializeField]
    int initialAmount = 1000;

    ObjectPool objectPool;

    // Use this for initialization
    void Start()
    {
        objectPool = GetComponent<ObjectPool>();
        objectPool.Init(prefab, initialAmount);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
