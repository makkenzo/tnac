using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 150f;
    public Transform player;
    public GameObject tablet;

    [Header("UI")]
    public GameObject tabletUI;
    public GameObject playerUI;

    private float xRotation = 0f;
    private bool isTabletOpen = false;

    private void Start()
    {
        OffTabletMenu();
    }

    void OffTabletMenu()
    {
        tabletUI.SetActive(false);
        playerUI.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        transform.localRotation = Quaternion.identity;
        player.rotation = transform.rotation;
    }

    private void Update()
    {
        if (isTabletOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isTabletOpen = false;

                OffTabletMenu();
            }
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10f)) 
            {
                if (hit.collider.CompareTag("Tablet"))
                {
                    isTabletOpen = true;
                    Cursor.lockState = CursorLockMode.None;
                    playerUI.SetActive(false);
                    tabletUI.SetActive(true);
                }
            }
        }
    }
}
