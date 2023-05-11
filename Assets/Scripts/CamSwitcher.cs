using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    public Button[] buttons;

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int cameraIndex = i;
            buttons[i].onClick.AddListener(() => SwitchToCamera(cameraIndex));
        }
    }

    private void SwitchToCamera(int cameraIndex)
    {
        foreach(Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }

        cameras[cameraIndex].gameObject.SetActive(true);
    }

    public void TurnOffAllCameras()
    {
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }
    }
}
