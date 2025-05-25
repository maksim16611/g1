using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    public GameObject[] mushroomPrefabs; // Массив префабов грибов (обычные, плохие, бонусные)
    public float spawnInterval = 1f; // Интервал между спавнами грибов (в секундах)

    private float timer; // Таймер для отслеживания времени между спавнами
    private float screenHalfWidthInWorldUnits; // Половина ширины экрана в мировых координатах

    void Start()
    {
        // Вычисляем половину ширины экрана на старте
        screenHalfWidthInWorldUnits = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        // Обновляем таймер
        timer += Time.deltaTime;

        // Если прошло достаточно времени — спавним гриб
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnMushroom();
        }
    }

    void SpawnMushroom()
    {
        // Случайная позиция X внутри границ экрана, с небольшим отступом (0.5f)
        float x = Random.Range(-screenHalfWidthInWorldUnits + 0.5f, screenHalfWidthInWorldUnits - 0.5f);

        // Выбираем случайный гриб из массива
        int i = Random.Range(0, mushroomPrefabs.Length);

        // Спавним гриб чуть выше видимой области камеры, чтобы он падал сверху
        Vector3 spawnPosition = new Vector3(x, Camera.main.orthographicSize + 1f, 0);

        // Создаём гриб
        Instantiate(mushroomPrefabs[i], spawnPosition, Quaternion.identity);
    }
}