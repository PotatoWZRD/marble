using UnityEngine;
using System.Collections;

public class movingPlat : MonoBehaviour
{

    public bool move = false;
    public bool moving = false;
    public bool useX = false;
    public bool useY = false;

    public Vector2 goal1;
    public Vector2 goal2;

    public float panicy1;
    public float panicy2;
    public float panicx1;
    public float panicx2;

    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            if (move)
            {
                gameObject.transform.Translate(goal1 * speed * Time.deltaTime);
            }
            else if (!move)
            {
                gameObject.transform.Translate(goal2 * speed * Time.deltaTime);
            }
        }

        if (useY && gameObject.transform.position.y >= panicy1)
        {
            move = false;
        }
        else if (useY && gameObject.transform.position.y <= panicy2)
        {
            move = true;
        }
        if (useX && gameObject.transform.position.x >= panicx1)
        {
            move = false;
        }
        else if (useX && gameObject.transform.position.x <= panicx2)
        {
            move = true;
        }
    }

    IEnumerator MovePl()
    {
        yield return new WaitForSeconds(5f);
        moving = false;
    }
}
