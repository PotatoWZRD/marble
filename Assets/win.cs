using TMPro;
using UnityEngine;

public class win : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] TMP_Text winner;
    public bool ha = false;
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
        if (!ha)
        {
            canvas.gameObject.SetActive(true);
            winner.text = collision.name + " is the winner!";
            ha = true;
        }
    }
}
