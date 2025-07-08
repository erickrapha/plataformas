using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class ColorEventChannel : ScriptableObject
{
    public event Action<Color> OnEventRaised;

    public void RaiseEvent(Color value)
    {
        OnEventRaised?.Invoke(value);
    }
}
