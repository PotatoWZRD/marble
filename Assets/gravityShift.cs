using UnityEngine;

public class gravityShift : MonoBehaviour
{
    public float gravity;
    public float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float grav = collision.gameObject.GetComponent<Rigidbody2D>().gravityScale;

        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = Mathf.Lerp(grav, gravity, time);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        float grav = collision.gameObject.GetComponent<Rigidbody2D>().gravityScale;

        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = Mathf.Lerp(grav, 1, time);
    }
}
