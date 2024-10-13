using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.U2D;



public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Скорость движения
    public float amplitude = 1f; // Амплитуда волны
    public float frequency = 1f; // Частота волны
    public float delay = 0.5f; // Задержка для следующего врага

    Rigidbody2D rb;

    private float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time; // Сохраняем время старта
    }

    void Update()
    {
        MoveInWave();
    }

    void MoveInWave()
    {
        // Вычисляем новое значение по Y с учетом задержки
        float timeElapsed = Time.time - (startTime + delay * transform.GetSiblingIndex());
        float newY = transform.position.y + Mathf.Sin(timeElapsed * frequency) * amplitude * Time.deltaTime; // Новое значение Y
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, newY, transform.localPosition.z); // Двигаем врага влево



    }




}


