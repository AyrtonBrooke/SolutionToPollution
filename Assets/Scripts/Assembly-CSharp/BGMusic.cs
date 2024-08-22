using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusic : MonoBehaviour
{
    private AudioSource backgroundMusic;
    private GameObject Player;
    public PlayerInteraction PlayerIntRef;

    private Scene currentScene;

    private void Awake()
    {
        // Set up the persistent object
        Object.DontDestroyOnLoad(transform.gameObject);

        // Initialize `currentScene`
        currentScene = SceneManager.GetActiveScene();

        Debug.Log("awake");
    }

    private void Start()
    {
        // Call `reference` method to initialize references
        reference();
    }

    private void reference()
    {
        // Find and reference the Player object and its components
        Player = GameObject.Find("Player");
        if (Player != null)
        {
            backgroundMusic = GetComponent<AudioSource>();
            PlayerIntRef = Player.GetComponent<PlayerInteraction>();
            Debug.Log("this runs now");
        }
        else
        {
            Debug.LogWarning("Player GameObject not found.");
        }
    }

    private void Update()
    {
        if (Player == null && currentScene.name != "StartMenu")
        {
            // Ensure `reference` is called only when needed
            reference();
        }
        if (PlayerIntRef != null)
        {
            // Adjust volume based on the PlayerIntRef status
            backgroundMusic.volume = PlayerIntRef.audioPlaying ? 0.3f : 1f;
        }
    }
}
