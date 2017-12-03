using UnityEngine;

public class Utility
{
    public static Vector3 GetEffectiveScaling(Transform transform)
    {
        return transform.parent == null ? transform.localScale : Vector3.Scale(GetEffectiveScaling(transform.parent), transform.localScale);
    }        
}