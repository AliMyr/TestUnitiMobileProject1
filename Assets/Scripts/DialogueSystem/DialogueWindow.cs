using TMPro;
using UnityEngine;

public class DialogueWindow : MonoBehaviour
{
    private TMP_Text _text;
    private DialogueStory _dialogueStory;

    private void Awake()
    {
        // Получаем компонент TMP_Text, который отвечает за отображение текста диалога
        _text = GetComponent<TMP_Text>();

        // Находим объект типа DialogueStory в сцене
        _dialogueStory = FindObjectOfType<DialogueStory>();

        // Подписываемся на событие ChangedStory, чтобы обновлять текст диалога при изменении истории
        _dialogueStory.ChangedStory += ChangeAnswers;
    }

    private void ChangeAnswers(DialogueStory.Story story)
    {
        // Обновляем текст диалогового окна в соответствии с текстом текущей истории
        _text.text = story.Text;
    }
}
