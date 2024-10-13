using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapBounds : MonoBehaviour
{
    Camera _camera;

    [SerializeField] private Transform _leftBound;
    [SerializeField] private Transform _rightBound;
    [SerializeField] private Transform _upBound;
    [SerializeField] private Transform _downBound;

    private void Awake()
    {
       _camera = Camera.main;

        SetBounds();
        
    }

    private void SetBounds()
    {
        // Получаем позицию камеры
        Vector3 cameraPosition = _camera.transform.position;



        // Получаем ширину экрана в мировых единицах
        float screenWidthInWorldUnits = _camera.orthographicSize * _camera.aspect * 2;



        // Левую границу камеры
        float leftBoundary = cameraPosition.x - (screenWidthInWorldUnits / 2);







        _leftBound.transform.position = new Vector3(leftBoundary, 0f, 0f);
        _rightBound.transform.position = new Vector3(-leftBoundary, 0f, 0f);



        // Вычисляем центр нижней и верхней границ
        Vector3 upBoundary = _camera.transform.position - new Vector3(0, _camera.orthographicSize, 0f);
        Vector3 downBoundary = _camera.transform.position + new Vector3(0, _camera.orthographicSize, 0f);

        _upBound.transform.position = upBoundary;
        _downBound.transform.position = downBoundary;



        // Получаем высоту видимого пространства
        float height = 2f * Mathf.Tan(_camera.fieldOfView * 0.5f * Mathf.Deg2Rad);

        // Получаем ширину видимого пространства
        float width = height * _camera.aspect;
    }

    
}
