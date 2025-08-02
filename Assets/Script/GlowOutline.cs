using System;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class GlowOutline : MonoBehaviour
{
    private Outline _outline;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineWidth = 0f;
    }

    public void OnOutline()
    {
        _outline.OutlineWidth = 9f;
       
    }

    public void OffOutline()
    {
        _outline.OutlineWidth = 0f;
        Debug.Log("Outline disabled for: ");
    }
    
}