using System.Collections;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer _Body,
    _Cloack, _Skirt, _Weapons;
    private string _nameFloat = "_DissAmount";
    private bool _isInvis = false;
    private float treshold = 0;

    public float Delay = 1f;

    private float _time = float.MinValue;
    private Coroutine _currentRoutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Execute();
        }
    }
    public void Execute()
    {
        if (Time.time < _time + Delay) return;
        _time = Time.time;

        if (_currentRoutine != null)
            StopCoroutine(_currentRoutine);

        if (_isInvis)
            _currentRoutine = StartCoroutine(NotInvisible());
        else
            _currentRoutine = StartCoroutine(InvisibleOn());

        Debug.Log("WORK");
    }

    private IEnumerator InvisibleOn()
    {
        _isInvis = true;
        float elapsed = 0f;

        while (elapsed < Delay)
        {
            elapsed += Time.deltaTime;
            treshold = Mathf.Clamp01(elapsed / Delay);
            _Body.material.SetFloat(_nameFloat, treshold);
            _Cloack.material.SetFloat(_nameFloat, treshold);
            _Skirt.material.SetFloat(_nameFloat, treshold);
            _Weapons.material.SetFloat(_nameFloat, treshold);
            yield return null;
        }
    }

    private IEnumerator NotInvisible()
    {
        _isInvis = false;
        float elapsed = 0f;

        while (elapsed < Delay)
        {
            elapsed += Time.deltaTime;
            treshold = 1f - Mathf.Clamp01(elapsed / Delay);
            _Body.material.SetFloat(_nameFloat, treshold);
            _Cloack.material.SetFloat(_nameFloat, treshold);
            _Skirt.material.SetFloat(_nameFloat, treshold);
            _Weapons.material.SetFloat(_nameFloat, treshold);
            yield return null;
        }
    }
}