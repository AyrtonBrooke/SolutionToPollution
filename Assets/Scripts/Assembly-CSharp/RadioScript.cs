using System.Collections;
using UnityEngine;

public class RadioScript : Interactable
{
	private AudioSource audioSource;

	public bool completedState;

	public GameObject TriggerNextScene;

	private NextSceneTrigger NextSceneRef;

	public GameObject Player;

	public PlayerInteraction PlayerIntRef;

	private IEnumerator CheckForAudio()
	{
		yield return new WaitForSeconds(audioSource.clip.length);
		PlayerIntRef.audioPlaying = false;
		Debug.Log("coroutine running");
	}

	private void Start()
	{
		Player = GameObject.Find("Player");
		audioSource = GetComponent<AudioSource>();
		completedState = false;
		NextSceneRef = TriggerNextScene.GetComponent<NextSceneTrigger>();
		PlayerIntRef = Player.GetComponent<PlayerInteraction>();
	}

	public override string GetDescription()
	{
		if (!completedState)
		{
			return "Press [E] to turn on the Radio.";
		}
		return "Radio is currently on";
	}

	public override void Interact()
	{
		if (!completedState)
		{
			audioSource.Play(0uL);
			completedState = true;
			NextSceneRef.completedPuzzles++;
			PlayerIntRef.audioPlaying = true;
			StartCoroutine("CheckForAudio");
		}
	}
}
