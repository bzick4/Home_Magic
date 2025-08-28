using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ControllerCC : MonoBehaviour
{
    [Header("Movement")]
    private float _walkSpeed;
    private float _runSpeed;
    [SerializeField] private float rotationSpeed = 200f;

    private CharacterController controller;
    private Animator animator;
    // private Health health;

    private void Awake()
    {
       ApplySettings(SettingsManager.Instance.CurrentSettings);
        SettingsManager.Instance.OnSettingsChanged += ApplySettings;
    }
    private void Start()
    {

        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //health = GetComponent<Health>();
    }

    private void Update()
    {
        Move();
        Hello();
    }

    private void ApplySettings(Settings settings)
    {
        _walkSpeed = settings._HeroSpeedWalk;
        _runSpeed = settings._HeroSpeedRun;
        
        Debug.Log($"Применены настройки игрока: Walk={_walkSpeed}, Run={_runSpeed}");
    }

    private void Move()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float speed = isRunning ? _runSpeed : _walkSpeed;

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
    
    private void OnDestroy()
    {
        if (SettingsManager.Instance != null)
            SettingsManager.Instance.OnSettingsChanged -= ApplySettings;
    }

    private void Hello()
    {
        if (Input.GetKeyDown(KeyCode.H))
            animator.SetTrigger("Hello");
    }

}
