using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed;


    private void Start()
    {
        _speed = 3.5f;
    }

    public void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(x, y, 0) * Time.deltaTime * _speed);
    }

    private void Update()
    {
        Move();
    }



    //public float moveSpeed = 3.5f; // скорость перемещения
    //private Rigidbody2D rb;
    //private Vector2 moveInput;

    //void Start()
    //{
    //    // Получаем компонент Rigidbody2D, чтобы управлять физикой
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //void Update()
    //{
    //    // Получаем ввод с клавиатуры
    //    moveInput.x = Input.GetAxisRaw("Horizontal"); // A и D для оси X
    //    moveInput.y = Input.GetAxisRaw("Vertical");   // W и S для оси Y
    //}

    //void FixedUpdate()
    //{
    //    // Двигаем персонажа
    //    rb.MovePosition(rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
    //}
}
