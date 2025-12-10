using UnityEngine;
using System.Collections;

public class fireBallCode : MonoBehaviour
{
    public bool timer;
    public bool timer2;
    public bool timer3;
    public float cooldown = 5f;
    public float cooldownLimit = 5f;
    [SerializeField] GameObject forceLol;
    [SerializeField] GameObject bomb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown > cooldownLimit)
        {
            if (timer)
            {
                StartCoroutine(boom());
                timer = false;
                cooldown = 0f;
            }
            else if (timer2)
            {
                StartCoroutine(slash());
                timer2 = false;
                cooldown = 0f;
            }
            else if (timer3)
            {
                StartCoroutine(facotyr());
                timer3 = false;
                cooldown = 0f;
            }
        }
    }

    IEnumerator boom()
    {
        GameObject haha = Instantiate(forceLol);
        haha.transform.position = gameObject.transform.position + Vector3.up * 0.5f;
        haha.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100f);
        Destroy(haha, 2f);
        yield return null;
    }
    IEnumerator slash()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }
    IEnumerator facotyr()
    {
        GameObject zax = Instantiate(bomb);
        zax.transform.position = gameObject.transform.position + Vector3.up * 0.5f;
        yield return new WaitForSeconds(1f);
        zax.gameObject.GetComponent<bombCode>().timer = true;
        yield return null;
    }
}
