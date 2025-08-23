using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class TransformBlock : MonoBehaviour, ITransform
{
    [SerializeField] private Vector3 _Direction;
    [SerializeField] private float _Time;
    

    // private void OnEnable()
    // {
    //     RayScript.OnMoveBlock += StartTransform;
    // }

    // private void OnDisable()
    // {
    //      RayScript.OnMoveBlock -= StartTransform;

    // }

    public void OnTransformBlock()
    {
        StartCoroutine(TranformObject());
    }

    private IEnumerator TranformObject()
    {

        

        //Vector3 startPosition = transform.position;
        //Vector3 targetPosition = startPosition + _Direction * 5f;
        float duration = 2f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.DOLocalMove(_Direction * 5f, _Time);
            //transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //transform.position = targetPosition;
    }
}
