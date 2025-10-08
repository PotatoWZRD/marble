using System.Collections;
using UnityEngine;

public class marbScript : MonoBehaviour
{

    bool once = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (once)
        {
            StartCoroutine(Funny());
            once = false;
        }
    }
    IEnumerator Funny()
    {
        yield return new WaitForSeconds(Random.Range(0f, 5f));
        gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
