using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class TransformBlock : MonoBehaviour, ITransform
{
    [SerializeField] private Vector3 _Direction;
    [SerializeField] private float _Time;


    public void OnTransformBlock()
    {
        StartCoroutine(TranformObject());
    }

    private IEnumerator TranformObject()
    {

        float duration = 2f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.DOLocalMove(_Direction * 5f, _Time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
