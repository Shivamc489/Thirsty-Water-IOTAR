using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;


public class GameManager : MonoBehaviour
{
    public GameObject Cube;
    public string ipAddress;
    public int port;
    public float read;
    TcpClient client = new TcpClient();

    public void Start()
    {
        Cube.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        client.Connect(ipAddress, port);
        

    }
    public void Update()
    {
        
            var stream = new StreamReader(client.GetStream());

            while(client.Connected)
            {
                read = float.Parse(stream.ReadLine());
                Debug.Log(read);
                Cube.transform.localScale=new Vector3(read, 1.0f, 1.0f);
            }
    }
}

