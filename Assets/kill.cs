using UnityEngine;
using System.Collections.Generic;

public class kill : MonoBehaviour
{
    public List<Vector2> checkPoints = new List<Vector2>();

    public int setCheck = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().totalForce = Vector2.zero;
        collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        collision.gameObject.transform.position = checkPoints[setCheck];
    }
}
