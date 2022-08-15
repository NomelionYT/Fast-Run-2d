using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _background;
    private float _maxXOffset = 1;
    private float _positionX;

    private void Start()
    {
        _background = GetComponent<RawImage>();
    }

    private void Update()
    {
        _positionX += _speed * Time.deltaTime;

        if (_positionX >= _maxXOffset)
        {
            _positionX = 0;
        }

        _background.uvRect = new Rect(_positionX, _background.uvRect.y, _background.uvRect.width, _background.uvRect.height);
    }
}
