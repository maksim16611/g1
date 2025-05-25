using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float fallSpeed = 2f; // Скорость падения гриба
    public int score = 1;
    public bool isBad = false;
    public bool isBonus = false;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isBad)
                GameManager.Instance.TakeDamage();
            else if (isBonus)
                GameManager.Instance.AddScore(5);
            else
                GameManager.Instance.AddScore(score);

            Destroy(gameObject);
        }
    }
}