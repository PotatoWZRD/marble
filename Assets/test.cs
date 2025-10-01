using WebSocketSharp;
using UnityEngine;
using System.Collections.Generic;


public class test : MonoBehaviour
{
    WebSocket ws;

    void Start()
    {
        ws = new WebSocket("wss://strainlessly-transfusive-ahmed.ngrok-free.dev");
        ws.Connect();
        ws.Send("{\"type\":\"connect\",\"client\":\"unity\"}");
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
        };
    }

    void Update()
    {
        if (ws == null)
        {
            return;
        }
    }/*
    void handleMessage(string suff)
    {
        var data = JsonUtility.FromJson<mes>(suff);
        if (data.typr == "")
        {
            
        }
    }

    public class mes
    {
        public string typr;
    }*/
}