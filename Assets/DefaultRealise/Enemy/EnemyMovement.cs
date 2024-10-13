using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.U2D;



public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // �������� ��������
    public float amplitude = 1f; // ��������� �����
    public float frequency = 1f; // ������� �����
    public float delay = 0.5f; // �������� ��� ���������� �����

    Rigidbody2D rb;

    private float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time; // ��������� ����� ������
    }

    void Update()
    {
        MoveInWave();
    }

    void MoveInWave()
    {
        // ��������� ����� �������� �� Y � ������ ��������
        float timeElapsed = Time.time - (startTime + delay * transform.GetSiblingIndex());
        float newY = transform.position.y + Mathf.Sin(timeElapsed * frequency) * amplitude * Time.deltaTime; // ����� �������� Y
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, newY, transform.localPosition.z); // ������� ����� �����



    }




}


