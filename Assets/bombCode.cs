using UnityEngine;
using System.Collections;

public class bombCode : MonoBehaviour
{
    public bool timer;
    [SerializeField] GameObject forceLol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            StartCoroutine(boom());
        }
    }

    IEnumerator boom()
    {
        yield return new WaitForSeconds(3f);
        GameObject haha = Instantiate(forceLol);
        haha.transform.position = gameObject.transform.position;
        haha.transform.localScale *= 3;
        Destroy(haha, 1f);
        Destroy(gameObject);
    }
}
