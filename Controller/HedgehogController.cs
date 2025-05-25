using UnityEngine;

public class HedgehogController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения

    private float screenHalfWidthInWorldUnits;
    private float playerHalfWidth;

    void Start()
    {
        // Получаем половину ширины персонажа
        float halfPlayerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;

        // Получаем половину ширины экрана в мировых координатах
        screenHalfWidthInWorldUnits = Camera.main.orthographicSize * Camera.main.aspect;
        playerHalfWidth = halfPlayerWidth;
    }

    void Update()
    {
        float move = 0f;

        // --- УНИВЕРСАЛЬНОЕ УПРАВЛЕНИЕ ---

        // Поддержка клавиш (ПК и WebGL)
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            move = -1f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            move = 1f;

        // Поддержка касаний / мыши — работает и на мобилках, и в браузере
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Input.mousePosition;
            if (touchPos.x < Screen.width / 2)
                move = -1f;
            else
                move = 1f;
        }

        // Перемещение
        Vector3 position = transform.position;
        position.x += move * moveSpeed * Time.deltaTime;

        // Ограничение в пределах экрана
        position.x = Mathf.Clamp(
            position.x,
            -screenHalfWidthInWorldUnits + playerHalfWidth,
            screenHalfWidthInWorldUnits - playerHalfWidth
        );

        transform.position = position;
    }
}