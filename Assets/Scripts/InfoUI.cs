using UnityEngine;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour
{
    [SerializeField] Text fps;
    string fpsString = "0";
    [SerializeField] int updateInterval = 10;
    int timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fpsString = (1/Time.deltaTime).ToString();
    }

    private void FixedUpdate()
    {
        timer--;
        if (timer <= 0)
        {
            fps.text = fpsString;
            timer = updateInterval;
        }
    }
}
