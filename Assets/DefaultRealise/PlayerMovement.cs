using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed;

    private bool _canMove;

    private void Start()
    {
        _speed = 3.5f;
        _canMove = true;
    }

    public void MovementPossibility(bool canMove)
    {
        _canMove = canMove;
    }

    public void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        if (_canMove)
        {
            transform.Translate(new Vector3(x, y, 0) * Time.deltaTime * _speed);
        }
    }

    private void Update()
    {
        Move();
    }



    //public float moveSpeed = 3.5f; // �������� �����������
    //private Rigidbody2D rb;
    //private Vector2 moveInput;

    //void Start()
    //{
    //    // �������� ��������� Rigidbody2D, ����� ��������� �������
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //void Update()
    //{
    //    // �������� ���� � ����������
    //    moveInput.x = Input.GetAxisRaw("Horizontal"); // A � D ��� ��� X
    //    moveInput.y = Input.GetAxisRaw("Vertical");   // W � S ��� ��� Y
    //}

    //void FixedUpdate()
    //{
    //    // ������� ���������
    //    rb.MovePosition(rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
    //}
}
