using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLvl11Button : MonoBehaviour
{
    public void OnGoToLvl11ButtonClick()
    {
        SceneManager.LoadScene("lvl1.2");
    }
}
