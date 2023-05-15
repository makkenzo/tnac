using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Text TimeText;
    public int number = 0;
    private float timer = 0f;
    private int count = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 60f)
        {
            number++;
            timer = 0f;
            count++;
            TimeText.text = number.ToString() + " AM";
            if (count == 6)
            {
                SceneManager.LoadScene("Victory");
                if (timer == 10f)
                {
                    SceneManager.LoadScene("Menu");
                }
            }
        }
    }
}
