using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(CharacterController))]
public class ClickToMove : MonoBehaviour
{
    [Header("Настройки движения")]
    public float moveSpeed = 5f;
    public float stoppingDistance = 0.1f;
    public float rotationSpeed = 10f;
    private float _currentSpeed;

    private CharacterController _controller => GetComponent<CharacterController>();
    private Vector3 _targetPosition;
    private bool _isMoving;
    [SerializeField] private Camera _mainCamera;
    private Animator _animator => GetComponent<Animator>();

    private void Awake()
    {
        //_mainCamera = GetComponent<Camera>();
        _isMoving = false;
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        }

        if (_isMoving)
        {
            MoveToTarget();
        }
    }

    private void SetTargetPosition()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            _targetPosition = hit.point;
            _isMoving = true;
        }
    }

    private void MoveToTarget()
    {

        Vector3 direction = _targetPosition - transform.position;
    direction.y = 0;
    float distanceToTarget = direction.magnitude;

    // Управление скоростью и анимацией
    if (distanceToTarget <= stoppingDistance)
    {
        // Достигли точки - плавно останавливаемся
        _currentSpeed = Mathf.Lerp(_currentSpeed, 0f, 4 * Time.deltaTime);
        _isMoving = false;
        
        // Включаем анимацию покоя
        _animator.SetFloat("Blend", 0f);
        return;
    }

    // Поворот персонажа
    if (direction != Vector3.zero)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime);
    }

    // Плавный разгон
    _currentSpeed = Mathf.Lerp(_currentSpeed, moveSpeed, 2 * Time.deltaTime);

    // Движение
    Vector3 moveVector = direction.normalized * _currentSpeed * Time.deltaTime;
    _controller.Move(moveVector);

    // Управление анимацией
    float animationBlendValue = Mathf.Clamp01(_currentSpeed / moveSpeed); // Нормализуем скорость
    _animator.SetFloat("Blend", animationBlendValue);

        // Vector3 direction = _targetPosition - transform.position;
        // direction.y = 0;
        // _currentSpeed = moveSpeed;

        // if (direction.magnitude <= stoppingDistance)
        // {
        //     _isMoving = false;
        //     return;
        // }

        // if (direction != Vector3.zero)
        // {
        //     Quaternion targetRotation = Quaternion.LookRotation(direction);
        //     transform.rotation = Quaternion.Slerp(
        //         transform.rotation,
        //         targetRotation,
        //         rotationSpeed * Time.deltaTime);
        // }


        // Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
        // _controller.Move(moveVector);
        // _animator.SetFloat("Blend", _currentSpeed);

    }

    private void OnDrawGizmos()
    {
        if (_isMoving)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_targetPosition, 0.2f);
            Gizmos.DrawLine(transform.position, _targetPosition);
        }
    }
}