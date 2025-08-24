using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ControllerCC : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private float rotationSpeed = 200f;

    private CharacterController controller;
    private Animator animator;
    private Health health;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    private void Update()
    {
        Move();
        Hello();
    }

    private void Move()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float speed = isRunning ? runSpeed : walkSpeed;

        transform.Rotate(Vector3.up * horiz * rotationSpeed * Time.deltaTime);

        Vector3 move = transform.forward * vert * speed * Time.deltaTime;
        controller.Move(move);

        if (animator != null)
        {
            float blend = Mathf.Abs(vert) > 0 ? (isRunning ? 2f : 1f) : 0f;
            animator.SetFloat("Blend", blend, 0.2f, Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        Health.OnDamage += PlayDeathAnimation;
    }

    private void OnDisable()
    {
        Health.OnDamage -= PlayDeathAnimation;
    }

    private void PlayDeathAnimation()
    {
        animator.SetTrigger("Dead");
        animator.SetLayerWeight(1, 0f);
    }

    private void Hello()
    {
        if (Input.GetKeyDown(KeyCode.H))
        animator.SetTrigger("Hello");
    }

}
