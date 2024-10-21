using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.U2D;



public class EnemyMovement : MonoBehaviour
{
    private float _speed; // Скорость движения
    private float _amplitude; // Амплитуда волны
    private float _frequency; // Частота волны
    private float _delay; // Задержка для следующего врага

    [SerializeField] private Player _player;
    private WaveComplexity _waveComplexity;
    Rigidbody2D _rb;

    private float _startTime;


    public void ChangeParameters(float speed, float amplitude, float freq, float delay)
    {
        _speed = speed;
        _amplitude = amplitude;
        _frequency = freq;
        _delay = delay;
    }


    public void Change()
    {
        switch (_player.ShotSystem)
        {
            case SingleShot:
                ChangeMovement(Random.Range(0 ,3));
                break;
            case FastSingleShot:
                ChangeMovement(Random.Range(3 ,5));
                break;
            case DoubleShot:
                ChangeMovement(Random.Range(5, 8));
                break;
            case FastDoubleShot:
                ChangeMovement(Random.Range(5, 8));
                break;
            case TripleShot:
                ChangeMovement(Random.Range(5, 8));
                break;
            case FastTripleShot:
                ChangeMovement(Random.Range(5, 8));
                break;
        }
    }



    public void ChangeMovement(int _wave)
    {
        
        switch (_wave)
        {
            case 0:
                ChangeParameters(2f, 0.1f, 0.5f,0.5f);// самое начало
                break;

            case 1:
                ChangeParameters(2f, 1f, 3f,0.2f);// не сложно
                break;

            case 2:
                ChangeParameters(2f, 1.5f, 2.25f,0.2f);// не сложно но так
                break;

            case 3:
                ChangeParameters(2f, 1.9f, 5f,0.1f);// не сложно
                break;

            case 4:
                ChangeParameters(2.5f, 1f, 1f,0.5f);// не приятно
                break;

            case 5:
                ChangeParameters(4f, 3.72f, 3f,0.2f);// сложненько
                break;

            case 6:
                ChangeParameters(2.5f, 4f, 4f,0.1f);// сложно
                break;

            case 7:
                ChangeParameters(4f, 3.72f, 4.07f,0.2f);// сложненько тоже
                break;

            case 8:
                ChangeParameters(4.5f, 3.8f, 4.07f,0.2f);// сложно вроде как
                break;
        }
       
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startTime = Time.time; // Сохраняем время старта
        Change();

        

    }

    void Update()
    {
        

        MoveInWave();

        
    }

    void MoveInWave()
    {
        // Вычисляем новое значение по Y с учетом задержки
        float timeElapsed = Time.time - (_startTime + _delay * transform.GetSiblingIndex());
        float newY = transform.position.y + Mathf.Sin(timeElapsed * _frequency) * _amplitude * Time.deltaTime; // Новое значение Y
        transform.position = new Vector3(transform.position.x - _speed * Time.deltaTime, newY, transform.localPosition.z); // Двигаем врага влево



    }




}


