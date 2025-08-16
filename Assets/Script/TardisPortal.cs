using UnityEngine;

public class TardisPortal : MonoBehaviour
{
    [SerializeField] private Camera _PortalCamera;
    [SerializeField] private RenderTexture _PortalTexture;
    [SerializeField] private Transform _Player;
    [SerializeField] private Transform _InsideSpawnPoint;

    private void Start()
    {
        if (_PortalCamera != null && _PortalTexture != null)
        {
            _PortalCamera.targetTexture = _PortalTexture;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _Player)
        {
            _Player.position = _InsideSpawnPoint.position;
            _Player.rotation = _InsideSpawnPoint.rotation;
        }
    }
}