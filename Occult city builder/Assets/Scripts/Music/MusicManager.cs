using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private float timeToFade;
    [SerializeField] AudioSource normalMusic;
    [SerializeField] AudioSource powerMusic;
    [SerializeField] AudioSource hungerMusic;
    private AudioSource curentllyPlaying, curentllyChosen;

    [SerializeField] MonsterManager monster;

    [SerializeField] private int hungerThreshhold, powerThreshold;

    
    private void Start()
    {
        powerMusic.volume = 0;
        powerMusic.Play();
        hungerMusic.volume = 0;
        hungerMusic.Play();
        curentllyChosen =curentllyPlaying= normalMusic;
        curentllyPlaying.Play();
        curentllyPlaying.volume = 1;

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
          StartCoroutine(CrossFade(curentllyPlaying, curentllyChosen));
        
    }
   
    private IEnumerator CrossFade(AudioSource audio1, AudioSource audio2)
    {
        if (curentllyChosen.clip != curentllyPlaying.clip)
        {
           // audio2.Play();
            float currentTime = 0;
            while (currentTime < timeToFade)
            {
                audio1.volume = Mathf.Lerp(1, 0, currentTime / timeToFade);
                audio2.volume = Mathf.Lerp(0, 1, currentTime / timeToFade);
                currentTime += Time.deltaTime;
                yield return null;
            }
            //audio1.Stop();
        }
        curentllyPlaying = curentllyChosen;
       // 
    }
}
