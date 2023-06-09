using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private bool isFullScreen;

    private void Start()
    {
        isFullScreen = Screen.fullScreen;
    }

    public void FullScreenToggle()
    {
        isFullScreen = Screen.fullScreen;
        Screen.fullScreen = !isFullScreen;
        Debug.Log(isFullScreen);
    }
}
