using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrag : MonoBehaviour
{
    public float force = 100;

    public Vector3 _clickPosition;
    public Vector3 _spritePosition;
    public Vector3 _deltaPosition;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Plane _plane = new Plane(Vector3.forward, Vector3.zero);

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (_plane.Raycast(ray, out float distance))
        {
            var mousePosition = ray.GetPoint(distance);
            mousePosition.z = 0;

            if (Input.GetMouseButtonDown(0))
            {
                _clickPosition = mousePosition;
                _spritePosition = _spriteRenderer.transform.localPosition;
            }
            if (Input.GetMouseButton(0))
            {
                _deltaPosition = mousePosition - _clickPosition;
            }
            else
            {
                _deltaPosition = Vector3.Lerp(_deltaPosition, Vector3.zero, 0.2f);
            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("jump: " + _deltaPosition);
                _rigidbody.AddForce(_deltaPosition * -force);
            }
        }
        _spriteRenderer.transform.localPosition = _spritePosition + _deltaPosition;
    }
}