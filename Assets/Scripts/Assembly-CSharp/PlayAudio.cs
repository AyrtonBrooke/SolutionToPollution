using UnityEngine;

public class PlayAudio : MonoBehaviour
{
	private AudioSource audioData;

	private void Start()
	{
		audioData = GetComponent<AudioSource>();
		audioData.Play(0uL);
		Debug.Log("Audio started");
	}

	private void Update()
	{
	}
}
