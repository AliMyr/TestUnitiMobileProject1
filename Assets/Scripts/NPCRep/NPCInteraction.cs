using UnityEngine;
using TMPro;  // Не забудь добавить этот using для TextMeshPro
using UnityEngine.UI;  // Для работы с UI элементами

public class NPCInteraction : MonoBehaviour
{
    public string[] randomTexts;  // Список случайных текстов для NPC
    public TMP_Text dialogueText;  // Используем TMP_Text для TextMeshPro
    public Button interactButton;  // Кнопка взаимодействия

    private bool isPlayerInRange = false;  // Флаг, чтобы знать, рядом ли игрок

    void Start()
    {
        interactButton.gameObject.SetActive(false);  // Отключаем кнопку в начале
        interactButton.onClick.AddListener(ShowRandomText);  // Добавляем обработчик нажатия кнопки
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactButton.gameObject.SetActive(true);  // Включаем кнопку, когда игрок рядом
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueText.text = "";  // Очищаем текст, когда игрок уходит
            interactButton.gameObject.SetActive(false);  // Отключаем кнопку, когда игрок уходит
        }
    }

    private void ShowRandomText()
    {
        if (randomTexts.Length > 0 && isPlayerInRange)  // Проверка, что игрок в зоне и есть тексты
        {
            int randomIndex = Random.Range(0, randomTexts.Length);
            dialogueText.text = randomTexts[randomIndex];
        }
    }
}
