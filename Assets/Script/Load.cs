using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class Load : MonoBehaviour
{
    [SerializeField] private GameObject _LoadUI;
    [SerializeField] private float _MaxLoad;
    [SerializeField] private TMP_Text _TextLoading;
    [SerializeField] private float _loadSpeed = 1f;
    [SerializeField] private string _loadingFormat;
    public float _currentLoad { get; private set; }
    public event Action<int> OnLoadMilestone;


    private void Awake()
    {
        _currentLoad = 0;
        _LoadUI.SetActive(true);

        StartLoadingAsync();
    }


    public async Task StartLoadingAsync()
    {
        float[] _milestones = new float[] {_MaxLoad * 0.25f, _MaxLoad * 0.5f, _MaxLoad * 0.75f, _MaxLoad};
        // _currentLoad = 0;

        // while (_currentLoad < _MaxLoad)
        // {
        //     _currentLoad += _loadSpeed;
        //     UpdateLoadBar();
        //     await Task.Delay(150);
        // }

        // _currentLoad = _MaxLoad;
        // UpdateLoadBar();
        // _LoadUI.SetActive(false);

        for (int i = 0; i < _milestones.Length; i++)
        {
            float targetLoad = _milestones[i];

            while (_currentLoad < targetLoad)
            {
                _currentLoad = Mathf.Min(_currentLoad + _loadSpeed, targetLoad);
                UpdateLoadBar();
                await Task.Delay(150);
            }

            OnLoadMilestone?.Invoke(i);
            Debug.Log($"Достигнут milestone {i}: {_currentLoad}%");

            if (i < _milestones.Length - 1)
            {
                await Task.Delay(3000);
            }
        }
        
        await Task.Delay(1500); 
        _LoadUI.SetActive(false);
    }

    private void UpdateLoadBar()
    {
        float percentage = Mathf.RoundToInt(_currentLoad);
        _TextLoading.text = string.Format(_loadingFormat, percentage);
    }
}