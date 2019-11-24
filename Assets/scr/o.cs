using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using UnityEngine.UI;

public class o : NetworkBehaviour
{
    public Text t,pt;
    public GameObject pr;
    public int i;
    public float v;
    public float timer,mti,ti;
    public int id;
    [SyncVar]
    public int point;
    public GameObject bo;
    public GameObject camer;
    // Use this for initialization
    [Command]
    void Cmdfood()
    {
        point++;
        float x = Random.Range(-55.0f, 55.0f);
        float y = Random.Range(-55.0f, 55.0f);
        GameObject food = Instantiate(pr, new Vector3(x, 1, y), transform.rotation) as GameObject;
        NetworkServer.Spawn(food);
    }
    public void ex()
    {
        ti += 0.5f;
        Cmdfood();
    }

	void Start () {
        point = 0;
        v = 5;
        timer = 0;
        ti = 0.5f;
        mti = 0;
        id = int.Parse(GetComponent<NetworkIdentity>().netId.ToString());
        i = 3;
        transform.eulerAngles = new Vector3(0, 0, 0);
        camer.transform.eulerAngles = new Vector3(90, 0, 0);
        name = "Player";
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
    private void OnTriggerEnter(Collider a)
    {
        if (!isLocalPlayer) return;
        if (a.tag == "brick")
        {
            transform.DetachChildren();
            Cmddie();
        }
        else
            if (a.tag == "body")
            if (a.GetComponent<t>().id != id)
            {
                transform.DetachChildren();
                Cmddie();
            }
            else if (a.tag == "head")
            {
                transform.DetachChildren();
                Cmddie();
            }
    }
    [Command]
    public void Cmddie()
    {
        NetworkServer.Destroy(gameObject);
    }
    private void move()
    {
        if (mti >= 0.1f)
        {
            if (Input.GetKey("a")&&i!=2)
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
                camer.transform.eulerAngles = new Vector3(90, 0, 0);
                i = 1;
                mti = 0;
            }
            else
            if (Input.GetKey("d") && i!=1)
            {
                i = 2;
                transform.eulerAngles = new Vector3(0, 90, 0);
                camer.transform.eulerAngles = new Vector3(90,  0, 0);
                mti = 0;
            }
            else
            if (Input.GetKey("w") && i!=4)
            {
                i = 3;
                transform.eulerAngles = new Vector3(0, 0, 0);
                camer.transform.eulerAngles = new Vector3(90, 0, 0);
                mti = 0;
            }
            else
            if (Input.GetKey("s") && i!=3)
            {
                i = 4;
                transform.eulerAngles = new Vector3(0, 180, 0);
                camer.transform.eulerAngles = new Vector3(90, 0, 0);
                mti = 0;
            }
        }
        else mti += Time.deltaTime;
    }
    // Update is called once per frame
    public override void OnStartLocalPlayer()
    {

        camer.SetActive(true);
        t.text = GetComponent<NetworkIdentity>().netId.ToString();
        pt.text = point.ToString();
    }

    [Command]
    void Cmdsp(float tti,int sid)
    {
        GameObject b = Instantiate(bo, transform.position, transform.rotation)as GameObject;
        b.GetComponent<t>().id = sid;
        b.GetComponent<t>().ti = tti;
        NetworkServer.Spawn(b);
    }

    void Update () {
        if (!isLocalPlayer) return;
        pt.text = point.ToString();
        move();
        transform.Translate(transform.forward*v*Time.deltaTime,Space.World);
        if (timer >= 0.1f)
        {
            Cmdsp(ti,id);
            timer = 0;
        }
        else timer += Time.deltaTime;
	}
}
