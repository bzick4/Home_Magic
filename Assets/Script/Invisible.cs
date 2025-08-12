using System.Collections;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer[] _Body;
    
    
    private string _nameFloat = "_DissAmount";
    private bool _isInvis = false;
    private float treshold = 0;
    private Material[] _bodyMaterials;

    public float Delay = 1f;

    private float _time = float.MinValue;
    private Coroutine _currentRoutine;

    private void Awake()
    {

        _bodyMaterials = new Material[_Body.Length];
        for (int i = 0; i < _Body.Length; i++)
        {
            if (_Body[i] != null)
            {
                _bodyMaterials[i] = _Body[i].material;
            }
        }
    }

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
            
            SetShaderFloatInAllMaterials(treshold);
           
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
            
            SetShaderFloatInAllMaterials(treshold);
           
            yield return null;
        }
    }

    private void SetShaderFloatInAllMaterials(float value)
    {
        foreach (var mat in _bodyMaterials)
        {
            if (mat != null && mat.HasProperty(_nameFloat))
            {
                mat.SetFloat(_nameFloat, value);
            }
        }
    }
}