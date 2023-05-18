using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    public float sensitivity = 150f;

    [Header("Binds")]
    public Transform player;
    public GameObject tablet;
    public CamSwitcher camSwitcher;
    public Energy energy;

    [Header("Doors")]
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject middleDoor;

    [Header("UI")]
    public GameObject tabletUI;
    public GameObject playerUI;
    public GameObject pauseUI;

    private float xRotation = 0f;

    public bool isTabletOpen = false;
    private bool isMenuOpen = false;

    private bool leftDoorIsOpen = false;
    private bool rightDoorIsOpen = false;
    private bool middleDoorIsOpen = false;

    private void Start()
    {
        player.rotation = transform.rotation;
        OffTabletMenu();
    }

    private void Update()
    {
        if (isMenuOpen)
        {
            TogglePauseMenu(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePauseMenu(false);
                isMenuOpen = false;
            }
            return;
        }

        if (isTabletOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OffTabletAndCameras();
            }
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOpen = true;
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (energy.canInteract)
            {
                TabletRayHit();
                LeftDoorButtonRayHit();
                RightDoorButtonRayHit();
                MiddleDoorButtonRayHit();
            }
        }
    }

    private void LeftDoorButtonRayHit()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20f))
        {
            if (hit.collider.CompareTag("LeftDoorButton"))
            {
                leftDoorIsOpen = !leftDoorIsOpen;
                leftDoor.GetComponent<Animator>().SetBool("isOpened", leftDoorIsOpen);
            }
        }
    }

    private void RightDoorButtonRayHit()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20f))
        {
            if (hit.collider.CompareTag("RightDoorButton"))
            {
                rightDoorIsOpen = !rightDoorIsOpen;
                rightDoor.GetComponent<Animator>().SetBool("isOpened", rightDoorIsOpen);
            }
        }
    }

    private void MiddleDoorButtonRayHit()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20f))
        {
            if (hit.collider.CompareTag("MiddleDoorButton"))
            {
                middleDoorIsOpen = !middleDoorIsOpen;
                middleDoor.GetComponent<Animator>().SetBool("isOpened", middleDoorIsOpen);
            }
        }
    }

    private void TabletRayHit()
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

                camSwitcher.cameras[0].gameObject.SetActive(true);
            }
        }
    }

    public void TogglePauseMenu(bool state)
    {
        pauseUI.SetActive(state);
        isMenuOpen = state;

        Cursor.lockState = state == false ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public void OffTabletAndCameras()
    {
        isTabletOpen = false;

        OffTabletMenu();

        camSwitcher.TurnOffAllCameras();
    }

    private void OffTabletMenu()
    {
        tabletUI.SetActive(false);
        playerUI.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
