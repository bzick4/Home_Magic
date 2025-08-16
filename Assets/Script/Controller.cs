using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float _Speed, _RunSpeed, _RotSpeed, _MaxSpeed;
    [SerializeField] private Transform _CameraTransform;

    private Animator _animator => GetComponent<Animator>();
    // private Vector3 _moveDirect;
    private Rigidbody _hero => GetComponent<Rigidbody>();

    private bool isMove;
    private float _currentSpeed;

    private float _vert, _horiz;


    private void Awake()
    {
        _currentSpeed = _Speed;
        // isMove = true;
    }

    private void Update()
    {
        _vert = Input.GetAxis("Vertical");
        _horiz = Input.GetAxis("Horizontal");
        Debug.Log(_currentSpeed);
    }

    private void FixedUpdate()
    {
        Walk();
        LimitSpeed();
    }




    private void Walk()
    {
        // Vector3 inputDirection = new Vector3(_horiz, 0f, _vert);
        // inputDirection.Normalize();

        // Vector3 moveDirection = transform.TransformDirection(inputDirection);

        // Vector3 targetVelocity = moveDirection * _currentSpeed;

        // targetVelocity.y = _hero.linearVelocity.y;

        // Vector3 velocityChange = targetVelocity - _hero.linearVelocity;

        // _hero.AddForce(velocityChange, ForceMode.VelocityChange);

        Vector3 moveDirection = new Vector3(_horiz, 0, _vert);

        moveDirection = Quaternion.AngleAxis(_CameraTransform.rotation.eulerAngles.y, Vector3.up) * moveDirection;

        if (_vert > 0.0f)
            _hero.AddForce(moveDirection * _Speed);

        else if (_vert < 0f)
            _hero.AddForce(moveDirection * _Speed);

        else
            moveDirection = Vector3.zero;


        // _animator.SetFloat("Blend", _hero.linearVelocity.magnitude);
        _animator.SetFloat("Blend", Vector3.ClampMagnitude(moveDirection,1).magnitude);


    }
    
      public void LimitSpeed()
    {
        if (_hero.linearVelocity.magnitude > _MaxSpeed)
        {
            _hero.linearVelocity = _hero.linearVelocity.normalized * _MaxSpeed;
        }
    }
    

   
   

   
}