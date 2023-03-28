using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource deathSound;
    [SerializeField] AudioSource fireSound;
    [SerializeField] AudioSource winSound;
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource BGM;
    private bool isMusicOn = true;



    
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
    public void ToggleMusic()
    {
        if (isMusicOn)
        {
            BGM.Pause();
            isMusicOn= false;
        }
        else
        {
            BGM.Play();
            isMusicOn= true;
        }
    }

}
