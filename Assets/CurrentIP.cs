
using UnityEngine;

using System;

using System.Net;

using System.Net.Sockets;

using UnityEngine.UI;



public class CurrentIP : MonoBehaviour

{

    public static string GetLocalIP()

    {

        try

        {

            string HostName = Dns.GetHostName(); //得到主机名

            IPHostEntry IpEntry = Dns.GetHostEntry(HostName);

            for (int i = 0; i < IpEntry.AddressList.Length; i++)

            {

                //从IP地址列表中筛选出IPv4类型的IP地址

                //AddressFamily.InterNetwork表示此IP为IPv4,

                //AddressFamily.InterNetworkV6表示此地址为IPv6类型

                if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)

                {

                    return IpEntry.AddressList[i].ToString();

                }

            }

            return "";

        }

        catch (Exception ex)

        {

            return "";

        }

    }



    void Start()

    {

        //将IP在UI上显示出来，我是挂在了Text组件本身上

        GetComponent<Text>().text = string.Format("<color=black>{0}</color>", GetLocalIP());

    }

}
