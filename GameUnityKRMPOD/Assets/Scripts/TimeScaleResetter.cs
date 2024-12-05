using UnityEngine;

public class TimeScaleResetter : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1f;
    }
}
