using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
	public Sprite ButtonNormal;

	public Sprite ButtonClicked;

	public Sprite ButtonHover;

	public bool Pressed;

	private void Start()
	{
		Pressed = !Pressed;
	}

	private void OnMouseEnter()
	{
		if (!Pressed)
		{
			GetComponent<SpriteRenderer>().sprite = ButtonHover;
		}
	}

	private void OnMouseDown()
	{
		if (!Pressed)
		{
			GetComponent<SpriteRenderer>().sprite = ButtonClicked;
		}
	}

	private void OnMouseUp()
	{
		if (!Pressed)
		{
			GetComponent<SpriteRenderer>().sprite = ButtonHover;
			Pressed = true;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	private void OnMouseExit()
	{
		if (!Pressed)
		{
			GetComponent<SpriteRenderer>().sprite = ButtonNormal;
		}
	}
}
