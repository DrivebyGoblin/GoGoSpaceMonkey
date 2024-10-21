using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private int _score;
    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _scoreText.text = _score.ToString();


        if (Input.GetMouseButtonDown(0))
        {
            _score = _score + 1;
        }
    }
}
