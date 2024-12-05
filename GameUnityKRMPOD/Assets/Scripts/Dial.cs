using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dial : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;
    public Image portraitImage; // Добавляем переменную для отображения портрета
    public Animator endAnimation; // Добавляем переменную для анимации ENDAnimation

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false); // Добавляем эту строку, чтобы в начале диалог был выключен
    }

    // Начать диалог
    public void StartDialogue(Dialogue dialogue, bool isPlayer)
    {
        // Анимация включения диалогового окна
        dialogueBox.SetActive(true);
        dialogueBox.GetComponent<Animator>().SetBool("isOpen", true);

        // Установить имя и предложения диалога
        if (isPlayer)
        {
            nameText.text = dialogue.playerName;
            portraitImage.sprite = dialogue.playerPortrait; // Установка портрета игрока
            foreach (string sentence in dialogue.playerSentences)
            {
                sentences.Enqueue(sentence);
            }
        }
        else
        {
            nameText.text = dialogue.npcName;
            portraitImage.sprite = dialogue.npcPortrait; // Установка портрета NPC
            foreach (string sentence in dialogue.npcSentences)
            {
                sentences.Enqueue(sentence);
            }
        }

        // Отобразить следующее предложение
        DisplayNextSentence();
    }

    // Отобразить следующее предложение в диалоге
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            // Если предложения закончились, завершить диалог
            EndDialogue();
            return;
        }

        // Получить следующее предложение и отобразить его
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // Постепенно отобразить предложение на экране
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    // Завершить диалог
    void EndDialogue()
    {
        // Анимация выключения диалогового окна
        dialogueBox.GetComponent<Animator>().SetBool("isOpen", false);
        // Временно остановить игровой процесс во время диалога
        Time.timeScale = 1f;

        // Здесь добавляем код для загрузки новой сцены
        SceneManager.LoadScene("Menu"); // Замените "NameOfYourScene" на имя вашей сцены
    }

    void Update()
    {
        // Проверка нажатия клавиши "Пробел" для отображения следующего предложения
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }
}
