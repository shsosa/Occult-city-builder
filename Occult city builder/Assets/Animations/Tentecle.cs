using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Monster;
using UnityEngine;

public class Tentecle : MonoBehaviour
{

    
    //todo - whrn to follow mouse - when has secrifice building - can be done with scrifice- after destroyed un follow
    public int length;

    public LineRenderer LineRenderer;

    public Vector3[] segmentPoses;
    public Vector3[] segmentV;

    public Transform targetDir;
    public Transform wiggleDir;
   

    public float targetDist;

    public float smoothSpeed;

    public int trailSpeed;

    public float wiggleSpeed;

    public float wiggleMagnitude;

    [SerializeField] float wiggleMagOG, wiggleSpeedOG; 

    [SerializeField] private float targetGrowth;
    [SerializeField] private float timeOfGrowth =0.05f;

    
    // Start is called before the first frame update
    void Start()
    {
        wiggleMagOG = wiggleMagnitude;
        wiggleSpeedOG = wiggleSpeed;
        LineRenderer.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        wiggleDir.localRotation = Quaternion.Euler(0,0,Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);
        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] =Vector3.SmoothDamp(segmentPoses[i],segmentPoses[i-1] +targetDir.right * targetDist,ref segmentV[i],smoothSpeed + i/ trailSpeed);
        }
        
    
        LineRenderer.SetPositions(segmentPoses);

        if (Input.GetKey(KeyCode.Space))
        {
           // StartCoroutine(Pulse(10, 20, 0.1f,0.1f,1));
        }
    }

    public void GrowTanticle( float monsterPower)
    {
        targetGrowth =monsterPower / 10f;
        targetDist = Mathf.Lerp(targetDist, targetGrowth, timeOfGrowth);
        targetDist = Mathf.Clamp(targetDist, 0.2f, 0.5f);
            
    }

    public void HungerAgetated(float monsterHunger)
    {
        wiggleMagnitude = Mathf.Lerp(wiggleMagnitude, monsterHunger * 2f, 0.5f);
        wiggleMagnitude = Mathf.Clamp(wiggleMagnitude, 1f, 30);
        
        wiggleSpeed = Mathf.Lerp(wiggleSpeed, monsterHunger * 2f, 0.5f);
        wiggleSpeed = Mathf.Clamp(wiggleSpeed, 1f, 30);
    }

    public IEnumerator Pulse(MonsterEmot monsterEmot)
    {
       

        yield return PulseChange(monsterEmot.wiggleSpeed,monsterEmot.wiggleMag,monsterEmot.reactPulseTime);
        targetDist = Mathf.Lerp(targetDist, targetDist + monsterEmot.tenticleGrowth, 0.5f);
        yield return new WaitForSeconds(monsterEmot.reactPulseTime);
        targetDist = Mathf.Lerp(targetDist, targetDist - monsterEmot.tenticleGrowth, 0.5f);
        yield return PulseChange(-monsterEmot.wiggleSpeed, -monsterEmot.wiggleMag,monsterEmot.reactPulseTime);
       


    }

    IEnumerator PulseChange(float speed, float wiggleMag, float pulseTime)
    {
        wiggleSpeed = Mathf.Lerp(wiggleSpeed, wiggleSpeed + speed,pulseTime);
        wiggleMagnitude = Mathf.Lerp(wiggleMagnitude, wiggleMagnitude + wiggleMag, pulseTime);
        yield return null;
    }
}
