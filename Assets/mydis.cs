using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class mydis: NetworkDiscovery
{
    public Text tcc;
    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        tcc.text = fromAddress;
        Debug.Log(fromAddress);
    }
    public void recieve()
    {
        StartAsClient();
        
    }
    public void startcall()
    {
        StartAsServer();
    }
}