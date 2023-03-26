using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Transform target;  // 카메라가 따라다닐 대상
    public Vector2 margin;   // 맵 경계선과 카메라 경계선 간의 여유 공간

    public float smoothing = 2.5f;  // 카메라 이동 시 부드러운 모션을 위한 smoothing 변수

    private BoxCollider2D bounds;  // 맵 경계

    private Vector3 _minBounds;  // 맵 경계의 최소값
    private Vector3 _maxBounds;  // 맵 경계의 최대값

    private float _halfHeight;  // 카메라의 높이
    private float _halfWidth;   // 카메라의 너비

    void Start()
    {
        target = GameObject.Find("Player1").GetComponent<Transform>();
        bounds = GameObject.Find("Bounds").GetComponent<BoxCollider2D>();
        _minBounds = bounds.bounds.min;
        _maxBounds = bounds.bounds.max;

        // 카메라의 높이와 너비를 계산
        _halfHeight = Camera.main.orthographicSize;
        _halfWidth = _halfHeight * Camera.main.aspect;
    }

    void FixedUpdate()
    {
        // 카메라의 현재 위치와 대상의 위치 사이의 거리 계산
        float x = transform.position.x;
        float y = transform.position.y;

        if (Mathf.Abs(x - target.position.x) > margin.x)
        {
            x = Mathf.Lerp(x, target.position.x, smoothing * Time.deltaTime);
        }

        if (Mathf.Abs(y - target.position.y) > margin.y)
        {
            y = Mathf.Lerp(y, target.position.y, smoothing * Time.deltaTime);
        }

        // 맵 경계를 벗어나지 않도록 카메라 위치 제한
        float cameraHalfWidth = Camera.main.orthographicSize * ((float)Screen.width / Screen.height);
        x = Mathf.Clamp(x, _minBounds.x + cameraHalfWidth, _maxBounds.x - cameraHalfWidth);
        y = Mathf.Clamp(y, _minBounds.y + _halfHeight, _maxBounds.y - _halfHeight);

        // 새로운 카메라 위치 설정
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
