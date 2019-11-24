using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class t : NetworkBehaviour
{
    [SyncVar]
    public int id;
    [SyncVar]
    public float ti;

    private float timer;
    // Use this for initialization
    void Start () {
        timer = 0;
        if (id % 9 == 0) GetComponent<MeshRenderer>().material.color = Color.black;
        if (id % 9 == 1) GetComponent<MeshRenderer>().material.color = Color.blue;
        if (id % 9 == 2) GetComponent<MeshRenderer>().material.color = Color.cyan;
        if (id % 9 == 3) GetComponent<MeshRenderer>().material.color = Color.gray;
        if (id % 9 == 4) GetComponent<MeshRenderer>().material.color = Color.green;
        if (id % 9 == 5) GetComponent<MeshRenderer>().material.color = Color.red;
        if (id % 9 == 6) GetComponent<MeshRenderer>().material.color = Color.yellow;
        if (id % 9 == 7) GetComponent<MeshRenderer>().material.color = Color.magenta;
        if (id % 9 == 8) GetComponent<MeshRenderer>().material.color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > ti)
        {
            NetworkServer.Destroy(gameObject);
        }
	}
}
