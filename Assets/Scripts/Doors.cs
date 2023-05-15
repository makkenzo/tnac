using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private bool _isOpened;
	[SerializeField] private Animator _animator;

    private void Update()
    {
		Interact();
    }

    public void Open()
	{
        _animator.SetBool("isOpened", _isOpened);
		_isOpened = !_isOpened;
	}

	public void Interact()
	{
		if (transform != null && transform.GetComponent<Doors>())
		{
			if (Input.GetKeyDown(KeyCode.E))
			{ 
				transform.GetComponent<Doors>().Open();
			}
        }
	}
}
