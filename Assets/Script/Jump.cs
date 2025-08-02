using UnityEngine;

public class Jump : MonoBehaviour
{
    private RaycastHit hit;
    private Animator _animator => GetComponent<Animator>();



    private void Update()
    {
        JumpRay();
    }
    private void JumpRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 1f))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.blue, 0.1f);

            var jump = hit.collider.CompareTag("Jump");

            // if (jump)
                // _animator.SetInteger("Jump");


        }
    }
}
