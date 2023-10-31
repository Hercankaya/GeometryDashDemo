using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
  
    private Color _startColor = Color.blue;
    private Color _endColor = Color.red;
    private float _transitionDuration = 7.0f;

    private float _startTime;
    private SpriteRenderer _spriteRenderer;
    private bool _isTransitioning = true;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _startColor;
        _startTime = Time.time;
    }

    void Update()
    {
        if (_isTransitioning)
        {
            float t = (Time.time - _startTime) / _transitionDuration;
            _spriteRenderer.color = Color.Lerp(_startColor, _endColor, t);

            if (t >= 1.0f)
            {
                _startTime = Time.time;
                _isTransitioning = false;
            }
        }
        else
        {
            float t = (Time.time - _startTime) / _transitionDuration;
            _spriteRenderer.color = Color.Lerp(_endColor, _startColor, t);

            if (t >= 1.0f)
            {
                _startTime = Time.time;
                _isTransitioning = true;
            }
        }
    }
}


