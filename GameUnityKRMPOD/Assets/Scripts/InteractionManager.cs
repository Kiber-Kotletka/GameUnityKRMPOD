// Скрипт InteractionManager.cs
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bb"))
        {
            // Запустить диалог
            Debug.Log("Начать диалог");
        }
    }
}
