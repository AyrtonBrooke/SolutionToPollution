using System.Collections;
using UnityEngine;

public class BikeInteraction : Interactable
{
	private AudioSource audioSource;

	public bool completedState;

	public GameObject TriggerNextScene;

	private NextSceneTrigger NextSceneRef;

	public Light exitLight;

	public Animator AnimController;

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
		audioSource = GetComponent<AudioSource>();
		completedState = false;
		NextSceneRef = TriggerNextScene.GetComponent<NextSceneTrigger>();
		exitLight.enabled = false;
		AnimController = GetComponent<Animator>();
		PlayerIntRef = Player.GetComponent<PlayerInteraction>();
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
			AnimController.Play("Bike");
			PlayerIntRef.audioPlaying = true;
			StartCoroutine("CheckForAudio");
			if (NextSceneRef.completedPuzzles == NextSceneRef.numberOfPuzzles)
			{
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
