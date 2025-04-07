using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // This method will be called when the Start Game button is clicked
    public void OnStartGameButtonPressed()
    {
        Debug.Log("Button Pressed! Switching scene...");
        SceneManager.LoadScene("MegaScene");
    }
}
