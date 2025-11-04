using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;
using WebSocketSharp;


public class test : MonoBehaviour
{
    WebSocket ws;
    List<Player> playerList = new List<Player>();
    List<Player> Loader = new List<Player>();
    [SerializeField] GameObject Basic;
    [SerializeField] GameObject YinYang;
    [SerializeField] GameObject Swirl;
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
            foreach (Player m in Loader)
            {
                if (m.command == 'c')
                {
                    GameObject marble = DesignChoice(m.design);
                    marble.transform.position = new Vector2(-5, 5);
                    m.player = marble;
                    m.player.name = m.name;

                    //color here
                    if (ColorUtility.TryParseHtmlString(m.color1, out Color one))
                    {
                        m.player.transform.GetChild(0).GetComponent<SpriteRenderer>().color = one;
                    }
                    if (ColorUtility.TryParseHtmlString(m.color2, out Color two))
                    {
                        m.player.transform.GetChild(1).GetComponent<SpriteRenderer>().color = two;
                    }
                    if (ColorUtility.TryParseHtmlString(m.color3, out Color three))
                    {
                        m.player.transform.GetChild(2).GetComponent<SpriteRenderer>().color = three;
                    }//fix this, it bugs when there are no child detected
                }
                else if(m.command == 'j')
                {
                    Debug.Log("Jill");  
                    m.player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed, ForceMode2D.Impulse);
                    string paddedID = m.id.ToString("D3");
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
        char command = data[0];
        string[] marbleData = data.Split(',');

        /*
        for (int i = 0; i < marbleData.Length; i++)
        {
            Debug.Log(marbleData[i]);
        }
        */


        switch (command)
        {
            case 'c':
                Player player = new Player();
                player.command = command;
                int.TryParse(marbleData[1], out player.id);
                player.name = marbleData[2];
                player.design = marbleData[3];
                player.color1 = marbleData[4];
                player.color2 = marbleData[5];
                player.color3 = marbleData[6];
                Loader.Add(player);
                Debug.Log("jame2s");
                playerList.Add(player);
                break;
            case 'j':
                data_id = data.Substring(0, 3);
                Debug.Log(data_id);
                if (int.TryParse(data_id, out int id))
                {
                    Debug.Log(id.ToString());
                    foreach (Player p in playerList)
                    {
                        if (p.id == id)
                        {
                            p.command = command;
                            Loader.Add(p);
                        }
                    }
                }
                break;
        }
       
    }

    public GameObject DesignChoice(string design)
    {
        switch (design)
        {
            case "Basic":
                return Instantiate(Basic);
            case "Yin Yang":
                return Instantiate(YinYang);
            case "Swirl":
                return Instantiate(Swirl);
        }
        return Instantiate(Basic);
    }

    public class Player
    {
        public GameObject player;
        public char command;
        public int id;
        public string name;
        public string design;
        public string color1;
        public string color2;
        public string color3;
    }
}