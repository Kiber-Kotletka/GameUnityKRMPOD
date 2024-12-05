using UnityEngine;

public class DialogTrig : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        // Остановить игровой процесс перед началом диалога
        Time.timeScale = 0f;

        // Начать диалог с помощью менеджера диалогов
        FindObjectOfType<Dial>().StartDialogue(dialogue, false); // NPC бабушки начинает диалог, поэтому передаем false
    }
}