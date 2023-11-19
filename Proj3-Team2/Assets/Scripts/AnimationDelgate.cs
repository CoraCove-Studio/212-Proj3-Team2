using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelgate : MonoBehaviour
{
    //[SerializeField] private GameObject fireVFX;
    //[SerializeField] private GameObject fireVFX_2;
    //[SerializeField] private GameObject doorToBurn;
    //[SerializeField] private GameObject boxToBurn;
    [Header("Audio Clips")]
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip dontDoIt;
    [SerializeField] private AudioClip chainLowering;
    [SerializeField] private AudioClip pipeSFX;
    [SerializeField] private AudioClip keySFX;
    [SerializeField] private AudioClip coinSFX;
    [SerializeField] private AudioClip coreSFX;
    [SerializeField] private AudioClip rockSFX;



    [Header("Audio Sources")]
    [SerializeField] private AudioSource audioSourceSFX;
    [SerializeField] private AudioSource audioSourceMusic;

    //[Header("Scene Animators")]
    //[SerializeField] private Animator dropDownPlate_1;
    //[SerializeField] private Animator dropDownPlate_2;

    //public for access as keyframe event
    //public void BurningDoor()
    //{
    //    fireVFX.SetActive(true);
    //    doorToBurn.GetComponent<MeshRenderer>().enabled = false;
    //}

    //public void BoxToBurn()
    //{
    //    fireVFX_2.SetActive(true);
    //    boxToBurn.GetComponent<MeshRenderer>().enabled = false;
    //}

    //calls burnSFX on a burning object
    //public void BurnSFX()
    //{
    //    audioSource.volume = 0.5f;
    //    audioSource.clip = burningSFX;
    //    audioSource.Play();
    //}

    public void buttonClickSFX()
    {
        audioSourceSFX.volume = 0.5f;
        audioSourceSFX.clip = buttonClick;
        audioSourceSFX.Play();
    }

    public void OnQuitHoverSFX()
    {
        audioSourceSFX.volume = 0.5f;
        audioSourceSFX.clip = dontDoIt;
        audioSourceSFX.Play();
    }

    //public void DropDownPlate_1()
    //{
    //    dropDownPlate_1.SetTrigger("Activated");
    //}

    //public void DropDownPlate_2()
    //{
    //    dropDownPlate_2.SetTrigger("Activated");
    //}

    public void ChainSFX()
    {
        audioSourceSFX.volume = .5f;
        audioSourceSFX.clip = chainLowering;
        audioSourceSFX.Play();
    }

    public void PipeSFX()
    {
        audioSourceSFX.volume = 0.5f;
        audioSourceSFX.clip = pipeSFX;
        audioSourceSFX.Play();
    }

    public void KeySFX()
    {
        audioSourceSFX.volume = 0.5f;
        audioSourceSFX.clip = keySFX;
        audioSourceSFX.Play();
    }

    public void CoinSFX()
    {
        audioSourceSFX.volume = 0.5f;
        audioSourceSFX.clip = coinSFX;
        audioSourceSFX.Play();
    }

    public void CoreSFX()
    {
        audioSourceSFX.volume = 0.5f;
        audioSourceSFX.clip = coreSFX;
        audioSourceSFX.Play();
    }

    public void RockSFX()
    {
        audioSourceSFX.volume = 0.5f;
        audioSourceSFX.clip = rockSFX;
        audioSourceSFX.Play();
    }
}
