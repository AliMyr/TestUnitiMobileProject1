using TMPro;
using UnityEngine;

public class DialogueWindow : MonoBehaviour
{
    private TMP_Text _text;
    private DialogueStory _dialogueStory;

    private void Awake()
    {
        // �������� ��������� TMP_Text, ������� �������� �� ����������� ������ �������
        _text = GetComponent<TMP_Text>();

        // ������� ������ ���� DialogueStory � �����
        _dialogueStory = FindObjectOfType<DialogueStory>();

        // ������������� �� ������� ChangedStory, ����� ��������� ����� ������� ��� ��������� �������
        _dialogueStory.ChangedStory += ChangeAnswers;
    }

    private void ChangeAnswers(DialogueStory.Story story)
    {
        // ��������� ����� ����������� ���� � ������������ � ������� ������� �������
        _text.text = story.Text;
    }
}
