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
        // �������� ��������� DialogueStory �� ���� �������
        _dialogueStory = GetComponent<DialogueStory>();

        // ����������� ����� ChangeAnswers �� ������� ChangedStory, ����� ��������� ������ ��� ��������� �������
        _dialogueStory.ChangedStory += ChangeAnswers;

        // �������������� ������� _buttonsText � _currentReplyTags � ������������ � ����������� ������
        _buttonsText = new TMP_Text[_buttons.Length];
        _currentReplyTags = new string[_buttons.Length];

        // ���� ��� ������������� ������ ������
        for (int i = 0; i < _buttons.Length; i++)
        {
            int button = i; // ��������� ���������� ��� ������������� ������ ������-���������

            // ��������� ��������� ��� ������� ������, ������� �������� ����� SendAnswer � �������� ������
            _buttons[i].onClick.AddListener(() => SendAnswer(button));

            // �������� ��������� TMP_Text � ������� �������� ������
            _buttonsText[i] = _buttons[i].gameObject.GetComponentInChildren<TMP_Text>();
        }
    }
    private void ChangeAnswers(DialogueStory.Story story)
    {
        for (int i = 0; i < _buttonsText.Length; i++)
        {
            // ���������, ���� �� ������ ��� ������� ������
            if (story.Answers.Length <= i)
            {
                // ���� ��� ������, �� ������ ������ ���������� � ������� �����
                _buttonsText[i].text = null;
                _buttons[i].interactable = false;
                continue;
            }

            // ������������� ����� ��� ������
            _buttonsText[i].text = story.Answers[i].Text;
            // ��������� ��� ��� ������, ����� ����� ������������ ��� � ������ SendAnswer
            _currentReplyTags[i] = story.Answers[i].ReposeText;
            // ������ ������ ��������
            _buttons[i].interactable = true;
        }
    }

    private void SendAnswer(int button)
        => _dialogueStory.ChangeStory(_currentReplyTags[button]);


}
