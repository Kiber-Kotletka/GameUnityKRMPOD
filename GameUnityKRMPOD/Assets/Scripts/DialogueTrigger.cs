using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        // Остановить игровой процесс перед началом диалога
        Time.timeScale = 0f;

        // Начать диалог с помощью менеджера диалогов
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, false); // NPC бабушки начинает диалог, поэтому передаем false
    }
}