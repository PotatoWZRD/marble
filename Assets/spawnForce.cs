using UnityEngine;

public class spawnForce : MonoBehaviour
{
    public int power;
    public int minPower = 5;
    public int maxPower = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        power = Random.Range(minPower, maxPower);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3,3)* power, Random.Range(1, 5) * power));
    }
}
