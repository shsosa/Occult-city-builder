using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentecle : MonoBehaviour
{

    public int length;

    public LineRenderer LineRenderer;

    public Vector3[] segmentPoses;
    public Vector3[] segmentV;

    public Transform targetDir;
    public Transform wiggleDir;
    private MonsterManager _monsterManager;

    public float targetDist;

    public float smoothSpeed;

    public int trailSpeed;

    public float wiggleSpeed;

    public float wiggleMagnitude;
    
    [SerializeField] private float targetGrowth;
    [SerializeField] private float timeOfGrowth =0.05f;
    // Start is called before the first frame update
    void Start()
    {
        _monsterManager = FindObjectOfType<MonsterManager>();
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
        
      //  GrowTanticle();
       // HungerAgetated();
        LineRenderer.SetPositions(segmentPoses);
    }

    void GrowTanticle()
    {
        targetGrowth = _monsterManager.monsterPower / 10f;
        targetDist = Mathf.Lerp(targetDist, targetGrowth, timeOfGrowth);
        targetDist = Mathf.Clamp(targetDist, 0.2f, 0.5f);
            
    }

    void HungerAgetated()
    {
        wiggleMagnitude = Mathf.Lerp(wiggleMagnitude, _monsterManager.monsterHunger * 2f, 0.5f);
        wiggleMagnitude = Mathf.Clamp(wiggleMagnitude, 1f, 30);
        
        wiggleSpeed = Mathf.Lerp(wiggleSpeed, _monsterManager.monsterHunger * 2f, 0.5f);
        wiggleSpeed = Mathf.Clamp(wiggleSpeed, 1f, 30);
    }
}
