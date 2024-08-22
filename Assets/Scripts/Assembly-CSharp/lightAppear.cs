using System.Collections;
using UnityEngine;

public class lightAppear : MonoBehaviour
{
	public GameObject TriggerNextScene;

	public Light exitLight;

	private IEnumerator DoorActive()
	{
		yield return new WaitForSeconds(5f);
		TriggerNextScene.SetActive(value: true);
		exitLight.enabled = true;
	}

	private void Start()
	{
		exitLight.enabled = false;
		StartCoroutine("DoorActive");
	}
}
