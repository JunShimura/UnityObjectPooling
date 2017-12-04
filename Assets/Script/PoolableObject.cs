using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolableObject : MonoBehaviour {

    public ObjectPool objectPool;

    public abstract void Init();
    public void Destroy()
    {
        Return();
    }
    public void Return()
    {
        objectPool.ReturnToPool(this.gameObject);
    }
}
