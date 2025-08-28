using UnityEngine;

public static class ScriptEnable
{
    public static void EnableAllScripts(this GameObject go, bool state)
    {
        
        var scripts = go.GetComponents<MonoBehaviour>();
        
    
        foreach (var script in scripts)
        {
            if (script is Load) continue; 
            
            script.enabled = state;
        }
    }
}

