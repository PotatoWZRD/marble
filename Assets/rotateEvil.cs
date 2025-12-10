using Unity.Mathematics;
using UnityEngine;
using System.Collections;

public class rotateEvil : MonoBehaviour
{
    public bool move = false;
    public bool moving = false;

    public Vector3 goal1;
    public Vector3 goal2;

    public float reached;
    public float reached2;
    public float wait;

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
                gameObject.transform.Rotate(goal1, speed * Time.deltaTime);
            }
            else if (!move)
            {
                gameObject.transform.Rotate(goal2, speed * Time.deltaTime);
            }
        }

        if (gameObject.transform.rotation.z <= reached)
        {
            //StartCoroutine(MovePl());
            move = false;
        }
        else if (gameObject.transform.rotation.z >= reached2)
        {
            //StartCoroutine(MovePl());
            move = true;
        }
    }
    IEnumerator MovePl()
    {
        moving = true;
        yield return new WaitForSeconds(wait);
        moving = false;
    }
}
