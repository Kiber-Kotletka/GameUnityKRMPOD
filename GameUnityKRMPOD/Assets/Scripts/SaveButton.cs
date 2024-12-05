using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveButton : MonoBehaviour
{
    public void OnSaveAndExitButtonClick()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Igor_Static1");
        if (player != null)
        {
            SaveManager.instance.SaveGame(SceneManager.GetActiveScene().name, player.transform.position);
            Debug.Log("Saved player position: " + player.transform.position);
            SceneManager.LoadScene("Menu");
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }
}
