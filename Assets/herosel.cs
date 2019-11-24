

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class herosel : NetworkManager
{

    public Text textIP;

    private string ipAddress;//IP地址

    //子类发送网络消息
    public class NetworkMessage : MessageBase
    {
        public int chosenClass;
    }
    
    

    //创建游戏按钮事件
    public void StartMyHost()
    {
        SetMyPort();
        NetworkManager.singleton.StartHost();
    }

    //加入游戏按钮事件
    public void JoinGame()
    {
        SetMyPort();
        SetMyIpAddress();
        NetworkManager.singleton.StartClient();
    }

    //设置端口号
    private void SetMyPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }

    //设置IP地址
    void SetMyIpAddress()
    {
        ipAddress = textIP.text;
        NetworkManager.singleton.networkAddress = ipAddress;
    }
}
