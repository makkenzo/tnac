using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Text TimeText;
    public int number = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 60f)
        {
            number++;
            timer = 0f;
            TimeText.text = number.ToString() + " AM";
        }
    }
}
