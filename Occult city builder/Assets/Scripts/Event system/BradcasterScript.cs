using System.Collections;
using UnityEngine;

public class BradcasterScript : MonoBehaviour
{
    public VoidEventChannelSO CollectReasources;
    [SerializeField] private float time;

    private void Start()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        CollectReasources.RaiseEvent();
        StartCoroutine(Timer());
    }  
}
