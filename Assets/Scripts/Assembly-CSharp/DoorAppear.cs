using System.Collections;
using UnityEngine;

public class DoorAppear : MonoBehaviour
{
	public GameObject TriggerNextScene;

	private IEnumerator DoorActive()
	{
		yield return new WaitForSeconds(5f);
		TriggerNextScene.SetActive(value: true);
	}

	private void Start()
	{
		StartCoroutine("DoorActive");
	}
}
