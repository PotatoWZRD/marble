using UnityEngine;

public class deathCode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SWORD")
        {
            transform.position = new Vector2(-7, 4);
        }
        else if (other.gameObject.tag == "FIREBALL")
        {
            transform.position = new Vector2(-7, 4);
        }
    }
}
