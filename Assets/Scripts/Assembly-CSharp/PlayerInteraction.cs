using System;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	public float interactionDistance;

	public TextMeshProUGUI interactionText;

	public Camera cam;

	public bool audioPlaying;

	private void Start()
	{
		if (interactionText == null)
		{
			Debug.LogError("interactionText is not assigned.");
		}

		if (cam == null)
		{
			cam = Camera.main; // Automatically assigns the main camera if not set
			if (cam == null)
			{
				Debug.LogError("Camera not assigned and no main camera found.");
			}
		}

		audioPlaying = false;
	}


	private void Update()
	{
		if (cam == null)
		{
			Debug.LogError("Camera is null.");
			return;
		}

		if (interactionText == null)
		{
			Debug.LogError("interactionText is null.");
			return;
		}


		Ray ray = cam.ScreenPointToRay(new Vector3((float)Screen.width / 2f, (float)Screen.height / 2f, 0f));
		bool flag = false;
		if (Physics.Raycast(ray, out var hitInfo, interactionDistance))
		{
			Interactable component = hitInfo.collider.GetComponent<Interactable>();
			if (component != null)
			{
				HandleInteraction(component);
				interactionText.text = component.GetDescription();
				flag = true;
			}
		}
		if (!flag)
		{
			interactionText.text = "";
		}
	}

	private void HandleInteraction(Interactable interactable)
	{
		KeyCode key = KeyCode.E;
		switch (interactable.interactionType)
		{
		case Interactable.InteractionType.Click:
			if (Input.GetKeyDown(key))
			{
				interactable.Interact();
			}
			break;
		case Interactable.InteractionType.Hold:
			if (Input.GetKeyDown(key))
			{
				interactable.Interact();
			}
			break;
		default:
			throw new Exception("Unsupported type of interactable.");
		}
	}
}
