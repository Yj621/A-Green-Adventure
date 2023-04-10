using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Transform target;  // ī�޶� ����ٴ� ���
    public Vector2 margin;   // �� ��輱�� ī�޶� ��輱 ���� ���� ����

    public float smoothing = 2.5f;  // ī�޶� �̵� �� �ε巯�� ����� ���� smoothing ����

    private BoxCollider2D bounds;  // �� ���

    private Vector3 _minBounds;  // �� ����� �ּҰ�
    private Vector3 _maxBounds;  // �� ����� �ִ밪

    private float _halfHeight;  // ī�޶��� ����
    private float _halfWidth;   // ī�޶��� �ʺ�

    void Start()
    {
        target = GameObject.Find("Player1").GetComponent<Transform>();
        bounds = GameObject.Find("Bounds").GetComponent<BoxCollider2D>();
        _minBounds = bounds.bounds.min;
        _maxBounds = bounds.bounds.max;

        // ī�޶��� ���̿� �ʺ� ���
        _halfHeight = Camera.main.orthographicSize;
        _halfWidth = _halfHeight * Camera.main.aspect;
    }

    void FixedUpdate()
    {
        // ī�޶��� ���� ��ġ�� ����� ��ġ ������ �Ÿ� ���
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

        // �� ��踦 ����� �ʵ��� ī�޶� ��ġ ����
        float cameraHalfWidth = Camera.main.orthographicSize * ((float)Screen.width / Screen.height);
        x = Mathf.Clamp(x, _minBounds.x + cameraHalfWidth, _maxBounds.x - cameraHalfWidth);
        y = Mathf.Clamp(y, _minBounds.y + _halfHeight, _maxBounds.y - _halfHeight);

        // ���ο� ī�޶� ��ġ ����
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
