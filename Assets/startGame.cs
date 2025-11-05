using UnityEngine;

public class startGame : MonoBehaviour
{
    [SerializeField] GameObject s1;
    [SerializeField] GameObject s2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickMe()
    {
        s1.SetActive(false);
        s2.SetActive(false);
    }
}
