using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{
	public Animator transition;

	public float transitionTime = 1f;

	public int numberOfPuzzles = 1;

	public int completedPuzzles;

	public GameObject Player;

	public PlayerInteraction PlayerIntRef;

	private void Start()
	{
		PlayerIntRef = Player.GetComponent<PlayerInteraction>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (completedPuzzles == numberOfPuzzles && !PlayerIntRef.audioPlaying)
		{
			LoadNextLevel();
			Debug.Log("collider hit");
		}
	}

	public void LoadNextLevel()
	{
		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
	}

	private IEnumerator LoadLevel(int levelIndex)
	{
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(transitionTime);
		SceneManager.LoadScene(levelIndex);
	}
}
