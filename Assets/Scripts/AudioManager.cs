using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource deathSound;
    [SerializeField] AudioSource fireSound;
    [SerializeField] AudioSource winSound;
    [SerializeField] AudioSource hitSound;



    
    public void JumpSound()
    {
        jumpSound.Play();
    }
    public void DeathSound()
    {
        deathSound.Play();
    }
    public void FireSound()
    {
        fireSound.Play();
    }
    public void WinSound()
    {
        winSound.Play();
    }
    public void HitSound()
    {
        hitSound.Play();
    }

}
