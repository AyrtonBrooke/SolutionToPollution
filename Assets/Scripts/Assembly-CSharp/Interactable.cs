using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
	public enum InteractionType
	{
		Click = 0,
		Hold = 1
	}

	public InteractionType interactionType;

	public abstract string GetDescription();

	public abstract void Interact();
}
