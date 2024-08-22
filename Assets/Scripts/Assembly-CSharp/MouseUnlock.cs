using UnityEngine;

public class MouseUnlock : MonoBehaviour
{
	private void Start()
	{
		Cursor.lockState = CursorLockMode.None;
	}
}
