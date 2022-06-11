using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrag : MonoBehaviour
{
    public float force = 100;

    public Vector3 _clickPosition;
    public Vector3 _spritePosition;
    public Vector3 _deltaPosition;

    public Transform _spriteRenderer;
    public Transform _spriteRendererStretch;
    private Rigidbody2D _rigidbody;
    private Plane _plane = new Plane(Vector3.forward, Vector3.zero);

    public LayerMask stageLayer;

    public PlayerHP playerHP;
    public AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
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
                _spritePosition = _spriteRenderer.localPosition;
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
                if (_deltaPosition.y > 0)
                {
                    var hit = Physics2D.Raycast(transform.position, Vector2.down, 1, stageLayer);
                    if (hit.collider)
                    {
                        var platform = hit.collider.GetComponent<SoftPlatform>();
                        platform.PassThrough();
                    }
                }
                _rigidbody.AddForce(_deltaPosition * -force);

                // HPå∏è≠
                playerHP.Jump();

                // ÉWÉÉÉìÉvâπ
                AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            }
        }
        _spriteRenderer.localPosition = _spritePosition + _deltaPosition;

        var angle = _spriteRendererStretch.localEulerAngles;
        angle.z = Mathf.Atan2(_deltaPosition.y, _deltaPosition.x);
        _spriteRendererStretch.localEulerAngles = Mathf.Rad2Deg * angle;

        _spriteRendererStretch.transform.localPosition = _deltaPosition / 2;

        var scale = _spriteRendererStretch.localScale;
        scale.x = 1 + _deltaPosition.magnitude * 2;
        _spriteRendererStretch.localScale = scale;
    }
}
