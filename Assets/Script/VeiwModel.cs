using UnityEngine;

using UnityEngine.UIElements;
using UnityWeld.Binding;
using System.ComponentModel;
using Unity.Entities.UniversalDelegates;


[Binding]
public class VeiwModel : MonoBehaviour, INotifyPropertyChanged
{
    private string _health;

    public event PropertyChangedEventHandler PropertyChanged;

    [Binding]
    public string Health
    {
        get => _health;
        set
        {
            if (_health!=null && _health.Equals(value)) return;
            _health = value;
            OnPropertyChange(nameof(Health));
        }

    }

    private void OnPropertyChange(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
