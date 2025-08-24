using System.Collections;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    [SerializeField] private float _MaxDistance = 5f;


    [SerializeField] private AnimationClip _ReturnAnimation;
    [SerializeField] private ParticleSystem _particleSystem;
    private Animator _animator => GetComponent<Animator>();

    private RaycastHit hit;
    private GlowOutline _lastOutlineObject;

    private void Start()
    {
        _animator.SetLayerWeight(1, 1f);
    }
    private void Update()
    {
        CastRay();
    }
    
    

    void CastRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, _MaxDistance))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red, 0.1f);

            var outline = hit.collider.TryGetComponent<GlowOutline>(out var _outline);
            var transformable = hit.collider.TryGetComponent<ITransform>(out var _transformable);

            if (outline && transformable)
            {
                ViewOutline(_outline);
                BackToTime(_transformable);
            }
        }
        else if (_lastOutlineObject != null)
            {
                DisableOutline(_lastOutlineObject);
                _lastOutlineObject = null;
            }
            else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * _MaxDistance, Color.green, 0.1f);
        }
    }


    private void BackToTime(ITransform transformable)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Попал в: " + hit.collider.name);
            StartCoroutine(WaitTranformObject(transformable));
            
            _animator.SetTrigger("Return");
        }
    }

    private void ViewOutline(GlowOutline outline)
    {
        outline.OnOutline();
    }

    private void DisableOutline(GlowOutline outline)
    {
        outline.OffOutline();
    }

    private IEnumerator WaitTranformObject(ITransform transformable)
    {
        float animationDuration = _ReturnAnimation.length;
         _particleSystem.Play();
        yield return new WaitForSeconds(animationDuration / 2);
        _particleSystem.Stop();
        transformable.OnTransformBlock();

    }

    }
