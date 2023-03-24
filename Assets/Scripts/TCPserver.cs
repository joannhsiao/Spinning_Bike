using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

// Add json key from client data
public class Data{
    // public byte[] image;
    public int[,] testdata;
}

public class TCPserver : MonoBehaviour
{
    private VideoSpeedController videospeedcontroller;
    private TcpListener server;
    private bool isRunning;

    // byte[] imageDatas = new byte[0];

    // Texture2D tex;
    public int Port = 5000;
    // public RawImage img;
    private void Start()
    {
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

        server = new TcpListener(ipAddress, Port);
        server.Start();

        isRunning = true;

        videospeedcontroller = GameObject.Find("Screen").GetComponent<VideoSpeedController>();
        // tex = new Texture2D(1280,720);
        StartListening();
    }

    private void Update(){
        StartListening();
    }

    private void StartListening()
    {
        server.BeginAcceptTcpClient(HandleClientAccepted, server);
    }

    private void HandleClientAccepted(IAsyncResult result)
    {
        TcpClient client = server.EndAcceptTcpClient(result);

        Debug.Log("Client connected");

        NetworkStream stream = client.GetStream();

        while (isRunning)
        {
            print("Running");
            byte[] buffer = new byte[300000];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            Debug.Log("Received message: " + message);
            if (message == "Connect Check"){
                byte[] check = Encoding.ASCII.GetBytes("Server check");
                stream.Write(check, 0, check.Length);
                Debug.Log("Sent check: Server check");
                continue;
            }
            // for(int i=0;i<100;i++){
            //     Debug.Log("i: "+i); 
            // }
            // byte[] response = Encoding.ASCII.GetBytes("ACK");
            Data res = JsonUtility.FromJson<Data>(message);
            Debug.Log("testdata: " + res.testdata);
            
            byte[] response = BitConverter.GetBytes(videospeedcontroller.nowframe);
            stream.Write(response, 0, response.Length);
            
            // Debug.Log("Frame on server:"+videospeedcontroller.nowframe);
            
            // imageDatas = _imgData.image;

            
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log("isRunning: false");
        isRunning = false;

        if (server != null)
        {
            print("stop");
            server.Stop();
        }
    }
    /*
    private void FixedUpdate(){
        tex.LoadImage(imageDatas);
        img.texture = tex;
    }*/
}