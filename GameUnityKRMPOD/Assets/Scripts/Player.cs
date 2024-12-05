using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Обработка движения персонажа
        Move();

        // Обработка анимации
        UpdateAnimation();

        // Обработка взаимодействия с NPC
        InteractWithNPC();
    }

    void Move()
    {
        // Получаем ввод от пользователя для движения
        float horizontalInput = Input.GetAxis("Horizontal");

        // Перемещаем персонажа
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Поворачиваем персонажа в нужную сторону
        if (horizontalInput > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if (horizontalInput < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    void UpdateAnimation()
    {
        // Проверяем, находится ли персонаж на земле
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        // Устанавливаем параметры аниматора в зависимости от состояния персонажа
        if (isGrounded && rb.velocity.magnitude == 0)
        {
            // Статическая анимация
            anim.SetInteger("State", 1);
        }
        else if (isGrounded && rb.velocity.magnitude > 0)
        {
            // Анимация ходьбы
            anim.SetInteger("State", 2);
        }
    }

    void InteractWithNPC()
    {
        // Обработка взаимодействия с NPC при нажатии клавиши "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 50f);
            foreach (Collider2D collider in colliders)
            {
                DialogueTrigger dialogueTrigger = collider.GetComponent<DialogueTrigger>();
                if (dialogueTrigger != null)
                {
                    dialogueTrigger.TriggerDialogue(); // Запускаем диалог с NPC
                }
            }
        }
    }
}
