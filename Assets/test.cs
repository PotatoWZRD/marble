using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;


public class test : MonoBehaviour
{
    WebSocket ws;
    List<Player> ts = new List<Player>();
    List<Player> Loader = new List<Player>();
    [SerializeField] GameObject marbleTest;
    public int speed;

    void Start()
    {
        ws = new WebSocket("wss://strainlessly-transfusive-ahmed.ngrok-free.dev");
        ws.Connect();
        ws.Send("{\"type\":\"connect\",\"client\":\"unity\"}");
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log(e.Data);
            handleMessage(e.Data);
        };
    }

    void Update()
    {
        if (ws == null)
        {
            return;
        }

        if (Loader.Count > 0)
        {
            foreach (Player go in Loader)
            {
                if (go.commando == 'c')
                {
                    GameObject test = Instantiate(marbleTest);
                    test.transform.position = Vector2.zero;
                    go.player = test;
                    if (int.TryParse(go.name.Substring(0, 3), out int id))
                    {
                        go.player.name = id.ToString();
                        go.id = id;
                    }
                }
                else if(go.commando == 'j')
                {
                    Debug.Log("Jill");  
                    go.player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed, ForceMode2D.Impulse);
                    string paddedID = go.id.ToString("D3");
                    ws.Send("{\"type\":\"jumped\",\"client\":\"unity\",\"id\":\""+paddedID+"\"}");
                }
            }
            Loader.Clear();
        }
    }

    public void handleMessage(string data)
    {
        /*
         * data will give id of obj-
         * data will also give instructions
         * code will look at if joined
         * make marble on join-
         * make marble jump if not join
         */

        string data_id = "seth";
        char command = data[3];
        Debug.Log(command);

        switch (command)
        {
            case 'c':

                Debug.Log("james");
                Player player = new Player();
                player.name = data;
                player.commando = command;
                Loader.Add(player);
                ts.Add(player);
                break;
            case 'j':
                Debug.Log("jame2s");
                data_id = data.Substring(0, 3);
                Debug.Log(data_id);
                if (int.TryParse(data_id, out int id))
                {
                    Debug.Log(id.ToString());
                    foreach (Player p in ts)
                    {
                        if (p.id == id)
                        {
                            p.commando = command;
                            Loader.Add(p);
                        }
                    }
                }
                break;
        }
       
    }

    public class Player
    {
        public GameObject player;
        public int id;
        public string name;
        public char commando;
    }
}