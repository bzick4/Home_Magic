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


    private void Awake()
    {
        _currentLoad = 0;
        _LoadUI.SetActive(true);
        
        StartLoadingAsync();
    }


    public async Task StartLoadingAsync()
    {
        _currentLoad = 0;

        while (_currentLoad < _MaxLoad)
        {
            _currentLoad += _loadSpeed;
            UpdateLoadBar();
            await Task.Delay(150);
        }

        _currentLoad = _MaxLoad;
        UpdateLoadBar();
        _LoadUI.SetActive(false);
    }

    private void UpdateLoadBar()
    {
        float percentage = Mathf.RoundToInt(_currentLoad);
        _TextLoading.text = string.Format(_loadingFormat, percentage);
    }
}