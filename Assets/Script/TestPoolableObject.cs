using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPoolableObject : PoolableObject {

	// Use this for initialization
	void Start () {
		
	}
    public override void Init()
    {
        Start();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Return();        
    }
}
