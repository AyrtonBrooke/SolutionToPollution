using System.Collections;
using UnityEngine;

public class NoAnimGeneralInteraction : Interactable
{
	private AudioSource audioSource;

	public bool completedState;

	public Light exitLight;

	public GameObject Player;

	public PlayerInteraction PlayerIntRef;

	public GameObject TriggerNextScene;

	private NextSceneTrigger NextSceneRef;

	private IEnumerator CheckForAudio()
	{
		yield return new WaitForSeconds(audioSource.clip.length);
		PlayerIntRef.audioPlaying = false;
		Debug.Log("coroutine running");
	}

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		NextSceneRef = TriggerNextScene.GetComponent<NextSceneTrigger>();
		PlayerIntRef = Player.GetComponent<PlayerInteraction>();
		completedState = false;
		exitLight.enabled = false;
	}

	public override string GetDescription()
	{
		if (!completedState)
		{
			return "Press [E] to Interact with this object.";
		}
		return "This object has already been interacted with.";
	}

	public override void Interact()
	{
		if (!completedState && !PlayerIntRef.audioPlaying)
		{
			audioSource.Play(0uL);
			completedState = true;
			NextSceneRef.completedPuzzles++;
			PlayerIntRef.audioPlaying = true;
			StartCoroutine("CheckForAudio");
			if (NextSceneRef.completedPuzzles == NextSceneRef.numberOfPuzzles)
			{
				TriggerNextScene.SetActive(value: true);
				exitLight.enabled = true;
				Debug.Log("light should be on");
			}
		}
		else
		{
			Debug.Log("one or the other sate is not met");
		}
	}
}
