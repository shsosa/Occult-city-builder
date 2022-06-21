using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    public UnityAction OnEventRaised;

    public void RaiseEvent()
    {
        //check if somone is listening to 
        OnEventRaised?.Invoke();
    }
}
