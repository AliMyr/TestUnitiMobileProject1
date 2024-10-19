using UnityEngine;
using TMPro;  // �� ������ �������� ���� using ��� TextMeshPro
using UnityEngine.UI;  // ��� ������ � UI ����������

public class NPCInteraction : MonoBehaviour
{
    public string[] randomTexts;  // ������ ��������� ������� ��� NPC
    public TMP_Text dialogueText;  // ���������� TMP_Text ��� TextMeshPro
    public Button interactButton;  // ������ ��������������

    private bool isPlayerInRange = false;  // ����, ����� �����, ����� �� �����

    void Start()
    {
        interactButton.gameObject.SetActive(false);  // ��������� ������ � ������
        interactButton.onClick.AddListener(ShowRandomText);  // ��������� ���������� ������� ������
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactButton.gameObject.SetActive(true);  // �������� ������, ����� ����� �����
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueText.text = "";  // ������� �����, ����� ����� ������
            interactButton.gameObject.SetActive(false);  // ��������� ������, ����� ����� ������
        }
    }

    private void ShowRandomText()
    {
        if (randomTexts.Length > 0 && isPlayerInRange)  // ��������, ��� ����� � ���� � ���� ������
        {
            int randomIndex = Random.Range(0, randomTexts.Length);
            dialogueText.text = randomTexts[randomIndex];
        }
    }
}
