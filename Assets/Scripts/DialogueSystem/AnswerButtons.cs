using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtons : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    private TMP_Text[] _buttonsText;
    private string[] _currentReplyTags;
    private DialogueStory _dialogueStory;

    private void Start()
    {
        // Получаем компонент DialogueStory на этом объекте
        _dialogueStory = GetComponent<DialogueStory>();

        // Подписываем метод ChangeAnswers на событие ChangedStory, чтобы обновлять ответы при изменении истории
        _dialogueStory.ChangedStory += ChangeAnswers;

        // Инициализируем массивы _buttonsText и _currentReplyTags в соответствии с количеством кнопок
        _buttonsText = new TMP_Text[_buttons.Length];
        _currentReplyTags = new string[_buttons.Length];

        // Цикл для инициализации каждой кнопки
        for (int i = 0; i < _buttons.Length; i++)
        {
            int button = i; // Локальная переменная для использования внутри лямбда-выражения

            // Добавляем слушатель для нажатия кнопки, который вызывает метод SendAnswer с индексом кнопки
            _buttons[i].onClick.AddListener(() => SendAnswer(button));

            // Получаем компонент TMP_Text у каждого элемента кнопки
            _buttonsText[i] = _buttons[i].gameObject.GetComponentInChildren<TMP_Text>();
        }
    }
    private void ChangeAnswers(DialogueStory.Story story)
    {
        for (int i = 0; i < _buttonsText.Length; i++)
        {
            // Проверяем, есть ли ответы для текущей кнопки
            if (story.Answers.Length <= i)
            {
                // Если нет ответа, то делаем кнопку неактивной и очищаем текст
                _buttonsText[i].text = null;
                _buttons[i].interactable = false;
                continue;
            }

            // Устанавливаем текст для кнопки
            _buttonsText[i].text = story.Answers[i].Text;
            // Сохраняем тег для ответа, чтобы потом использовать его в методе SendAnswer
            _currentReplyTags[i] = story.Answers[i].ReposeText;
            // Делаем кнопку активной
            _buttons[i].interactable = true;
        }
    }

    private void SendAnswer(int button)
        => _dialogueStory.ChangeStory(_currentReplyTags[button]);


}
