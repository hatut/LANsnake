using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class food : NetworkBehaviour {
    public GameObject pr;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "head")
        {
            de();
        }
    }
    [ServerCallback]
    public void de()
    {
        NetworkServer.Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update () {
    }
}
