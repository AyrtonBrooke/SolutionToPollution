using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsWaiting : MonoBehaviour
{
	private IEnumerator Credit()
	{
		yield return new WaitForSeconds(40f);
		SceneManager.LoadScene(0);
	}

	private void Start()
	{
		StartCoroutine("Credit");
	}
}
