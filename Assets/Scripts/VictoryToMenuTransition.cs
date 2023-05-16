using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryToMenuTransition : MonoBehaviour
{
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
