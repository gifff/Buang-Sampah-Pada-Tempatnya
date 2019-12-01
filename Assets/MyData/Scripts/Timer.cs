using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float oneSec = 1;
    public int totalTime = 30;
    public Text textTime;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.oneSec -= Time.deltaTime;
        if (oneSec < 0) {
            this.oneSec = 1;
            this.totalTime--;
            textTime.text = "Time: " + totalTime;
            // Debug.Log("totalTime: " + totalTime);

            if (totalTime <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
