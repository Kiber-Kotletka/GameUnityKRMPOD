using UnityEngine;

public class DialogueAnimation : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        // Получаем компонент Animator
        animator = GetComponent<Animator>();
    }

    // Метод для проигрывания анимации появления диалога
    public void PlayAppearAnimation()
    {
        animator.SetTrigger("Appear");
    }

    // Метод для проигрывания анимации исчезновения диалога
    public void PlayDisappearAnimation()
    {
        animator.SetTrigger("Disappear");
    }
}
