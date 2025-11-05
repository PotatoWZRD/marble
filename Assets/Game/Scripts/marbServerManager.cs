using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;
using WebSocketSharp;


public class marbServerManager : MonoBehaviour
{
    WebSocket ws;
    List<Player> playerList = new List<Player>();
    List<Player> Loader = new List<Player>();
    [SerializeField] GameObject Basic;
    [SerializeField] GameObject YinYang;
    [SerializeField] GameObject Swirl;
    [SerializeField] GameObject Happy;
    [SerializeField] GameObject Star;
    [SerializeField] GameObject Cross;
    [SerializeField] GameObject SunMoon;
    [SerializeField] GameObject Donut;
    [SerializeField] GameObject Cowprint;
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
                    marble.transform.position = GameObject.FindGameObjectWithTag("SPAWN").transform.position;
                    m.player = marble;
                    m.player.name = m.name;

                    //color here
                    switch (m.player.transform.childCount)
                    {
                        case 1:
                            if (ColorUtility.TryParseHtmlString(m.color1, out Color one))
                            {
                                m.player.transform.GetChild(0).GetComponent<SpriteRenderer>().color = one;
                            }
                            break;
                        case 2:
                            if (ColorUtility.TryParseHtmlString(m.color1, out Color one2))
                            {
                                m.player.transform.GetChild(0).GetComponent<SpriteRenderer>().color = one2;
                            }
                            if (ColorUtility.TryParseHtmlString(m.color2, out Color two))
                            {
                                m.player.transform.GetChild(1).GetComponent<SpriteRenderer>().color = two;
                            }
                            break;
                        case 3:
                            if (ColorUtility.TryParseHtmlString(m.color1, out Color one3))
                            {
                                m.player.transform.GetChild(0).GetComponent<SpriteRenderer>().color = one3;
                            }
                            if (ColorUtility.TryParseHtmlString(m.color2, out Color two2))
                            {
                                m.player.transform.GetChild(1).GetComponent<SpriteRenderer>().color = two2;
                            }
                            if (ColorUtility.TryParseHtmlString(m.color3, out Color three))
                            {
                                m.player.transform.GetChild(2).GetComponent<SpriteRenderer>().color = three;
                            }
                            break;
                    }

                }
                else if(m.command == 'j')
                {
                    m.player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed, ForceMode2D.Impulse);
                }
            }
            Loader.Clear();
        }
    }

    public void handleMessage(string data)
    {
        char command = data[0];
        string[] marbleData = data.Split(',');



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

                bool exists = playerList.Where(check => check.id == player.id).Any();

                if (!exists)
                {
                    Loader.Add(player);
                    playerList.Add(player);
                }

                break;

            case 'j':
                int.TryParse(marbleData[1], out int data_id);
                foreach (Player p in playerList)
                {
                    if (p.id == data_id)
                    {
                        p.command = command;
                        Loader.Add(p);
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
            case "Happy":
                return Instantiate(Happy);
            case "Star":
                return Instantiate(Star);
            case "Cross":
                return Instantiate(Cross);
            case "Sun & Moon":
                return Instantiate(SunMoon);
            case "Donut":
                return Instantiate(Donut);
            case "Cowprint":
                return Instantiate(Cowprint);
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