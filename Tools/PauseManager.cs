using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    //[SerializeField] private Button pauseButton; // Reference to your pause button in the UI.

    private void Start()
    {
        // Attach the TogglePause method to the button's OnClick event.
        //pauseButton.onClick.AddListener(TogglePause);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // You can change the key as needed.
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause time.
            // Optionally, you can display a pause menu UI or perform other actions.
        }
        else
        {
            Time.timeScale = 1f; // Unpause time.
            // Optionally, you can hide the pause menu UI or resume other game activities.
        }
    }
}