using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private float fadeRate;
    [SerializeField] AudioSource normalMusic;
    [SerializeField] AudioSource powerMusic;
    [SerializeField] AudioSource hungerMusic;
    private AudioSource curentllyPlaying, curentllyChosen;

    [SerializeField] MonsterManager monster;

    [SerializeField] private int hungerThreshhold, powerThreshold;

    
    private void Start()
    {
        powerMusic.volume = 0;
        hungerMusic.volume = 0;
        curentllyChosen =curentllyPlaying= normalMusic;
        curentllyPlaying.Play();
    }
    private void FixedUpdate()
    {
        MusicSwitch();
    }

    private void MusicSwitch()
    {
        if (monster.monsterHunger >= hungerThreshhold)
        {
            curentllyChosen = hungerMusic;
            
        }
        else if (monster.monsterPower >= powerThreshold)
        {
            
            curentllyChosen = powerMusic;
        }
        else
        {
           
            curentllyChosen = normalMusic;  
        }
        Music(curentllyPlaying, curentllyChosen);
    }
    private void Music(AudioSource audio1,AudioSource audio2)
    {
        if (curentllyChosen!=curentllyPlaying)
        {
            audio2.Play();
            float currentTime = 0;
            while (currentTime < fadeRate)
            {
                currentTime ++;
                audio1.volume = Mathf.Lerp(audio1.volume, 0, currentTime * fadeRate);
                audio2.volume= Mathf.Lerp(audio2.volume, 1, currentTime * fadeRate);
                
            }
            curentllyPlaying = curentllyChosen;
        }
    }
}
