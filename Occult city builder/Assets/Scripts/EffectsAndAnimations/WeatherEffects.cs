using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherEffects : MonoBehaviour
{
    Vector3 originalPosition;
    [SerializeField] private float positiveOffset, negetiveOffset;
    [SerializeField] private float minTimeToSpawn, maxTimeToSpawn;
    [SerializeField] private int secondsToWait;
    [SerializeField] private float speed;
    private void Start()
    {
        negetiveOffset = 0 - positiveOffset;
        originalPosition = transform.position;
        StartCoroutine(Spawn());
    }
    void Update()
    {
        MovementControls();
    }
    private void MovementControls()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(secondsToWait);
        secondsToWait = Random.Range((int)minTimeToSpawn, (int)maxTimeToSpawn);
        transform.position = new Vector3(Random.Range(negetiveOffset, positiveOffset), originalPosition.y, originalPosition.z);
        StartCoroutine(Spawn());
    }
}
