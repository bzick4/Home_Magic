using UnityEngine;



public class Walk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody _rb => GetComponent<Rigidbody>();

    private float _vert, _horiz;
    private Vector3 _moveDirection;

    [SerializeField] private Transform _CameraTransform;
    [SerializeField, Range(0, 15)] private float _speed, _maxSpeed;




    private void Update()
    {
        _vert = Input.GetAxis("Vertical");
        _horiz = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        WalkSpeed();
        LimitSpeed();
    }

    public void WalkSpeed()
    {
        _moveDirection = new Vector3(_horiz, 0, _vert);
        _moveDirection = Quaternion.AngleAxis(_CameraTransform.rotation.eulerAngles.y, Vector3.forward) * _moveDirection;
        if (_vert > 0.0f)
        {
            _rb.AddForce(_moveDirection * _speed);
        }
        else if (_vert < 0f)
        {
            _rb.AddForce(_moveDirection * _speed);
        }
        else
        {
            _moveDirection = Vector3.zero;
        }
    }

    public void LimitSpeed()
    {
        if (_rb.linearVelocity.magnitude > _maxSpeed)
        {
            _rb.linearVelocity = _rb.linearVelocity.normalized * _maxSpeed;
        }
    }
}
