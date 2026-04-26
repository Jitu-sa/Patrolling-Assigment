using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody2D rb;
    Vector2 movement;

    public static bool PlayerInArea=false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Area"))
        {
            PlayerInArea = true;
        }
          if (other.CompareTag("Star"))
          {
              GameManager.Instance.AddScore();
              StarPool.Instance.ReturnStar(other.gameObject);
          }

          if (other.CompareTag("Enemy"))
          {
              GameManager.Instance.GameOver();
          }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Area"))
        {
            PlayerInArea = false;
        }
    }
}