using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Renderer buttonRenderer;
    public GameObject door;
    public bool doorIsOpen;

    [SerializeField] private Energy energy;

    private void Start()
    {
        doorIsOpen = door.GetComponent<Animator>().GetBool("isOpened");
    }

    private void Update()
    {
        if (energy.canInteract)
        {
            doorIsOpen = door.GetComponent<Animator>().GetBool("isOpened");

            if (doorIsOpen)
            {
                buttonRenderer.material.color = new Color(0f, 1f, 0.02951145f);
            }
            else
            {
                buttonRenderer.material.color = new Color(1f, 0f, 0.1419296f);
            }
        }
        else
        {
            buttonRenderer.material.color = new Color(1f, 0f, 0.1419296f);
        }
    }
}
