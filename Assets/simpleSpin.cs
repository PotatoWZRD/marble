using UnityEngine;

public class simpleSpin : MonoBehaviour
{
    [SerializeField] float speed =1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localEulerAngles += new Vector3(0,0,speed * Time.deltaTime);
    }
}
