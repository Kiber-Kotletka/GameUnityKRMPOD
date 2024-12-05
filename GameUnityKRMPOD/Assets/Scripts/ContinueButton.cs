using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ContinueButton : MonoBehaviour
{
    public void OnContinueButtonClick()
    {
        StartCoroutine(LoadGameCoroutine());
    }

    private IEnumerator LoadGameCoroutine()
    {
        SaveData data = SaveManager.instance.LoadGame();
        if (data != null)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(data.sceneName);

            // Wait until the asynchronous scene loading is complete
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            // Wait for one frame to ensure the scene is fully loaded
            yield return new WaitForEndOfFrame();

            GameObject player = GameObject.FindGameObjectWithTag("Igor_Static1");
            if (player != null)
            {
                Debug.Log("Loaded player position: " + data.playerPosition);
                yield return new WaitForSeconds(0.1f);
                player.transform.position = data.playerPosition;
                Debug.Log("Loaded and set player position: " + player.transform.position);
                player.SetActive(false);
                player.SetActive(true);

                EventSystem.current.SetSelectedGameObject(null);
            }
            else
            {
                Debug.LogError("Player not found!");
            }
        }
        else
        {
            Debug.LogError("No saved game found!");
        }
    }
}
