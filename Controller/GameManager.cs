using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Глобальная ссылка на GameManager (Singleton)

    public TextMeshProUGUI scoreText;    // Ссылка на текст очков
    public TextMeshProUGUI livesText;    // Ссылка на текст жизней
    public GameObject gameOverPanel;     // Панель Game Over

    private int score = 0; // Счёт игрока
    private int lives = 3; // Количество жизней игрока

    void Awake()
    {
        // Назначаем текущий объект как глобальный экземпляр
        Instance = this;
    }

    void Start()
    {
        // Сброс значений при старте
        score = 0;
        lives = 3;

        // Обновляем UI
        UpdateScoreText();
        UpdateLivesText();

        // Прячем экран Game Over
        gameOverPanel.SetActive(false);
    }

    // Метод для добавления очков
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText(); // Обновляем текст очков
    }

    // Метод для уменьшения жизней при получении урона
    public void TakeDamage()
    {
        lives--; // Уменьшаем количество жизней
        UpdateLivesText(); // Обновляем UI

        // Если жизни закончились — вызываем Game Over
        if (lives <= 0)
        {
            GameOver();
        }
    }

    // Обновляет текст очков в интерфейсе
    void UpdateScoreText()
    {
        scoreText.text = "Очки: " + score;
    }

    // Обновляет текст жизней в интерфейсе
    void UpdateLivesText()
    {
        livesText.text = "" + lives;
    }

    // Завершение игры
    void GameOver()
    {
        gameOverPanel.SetActive(true); // Показываем панель
        Time.timeScale = 0f; // Останавливаем игру
    }

    // Перезапуск игры по кнопке
    public void RestartGame()
    {
        Time.timeScale = 1f; // Снимаем паузу
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Загружаем текущую сцену заново
    }
}
