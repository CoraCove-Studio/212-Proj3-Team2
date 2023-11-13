using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelgate : MonoBehaviour
{
    [Header("Assigned In Inspector")]
    [SerializeField] private GameObject fireVFX;
    [SerializeField] private GameObject fireVFX_2;
    [SerializeField] private GameObject doorToBurn;
    [SerializeField] private GameObject boxToBurn;
    [SerializeField] private AudioClip burningSFX;
    [SerializeField] private AudioSource audioSource;

    //public for access as keyframe event
    public void BurningDoor()
    {
        fireVFX.SetActive(true);
        doorToBurn.GetComponent<MeshRenderer>().enabled = false;
    }

    public void BoxToBurn()
    {
        fireVFX_2.SetActive(true);
        boxToBurn.GetComponent<MeshRenderer>().enabled = false;
    }

    public void BurnSFX()
    {
        audioSource.volume = 0.5f;
        audioSource.clip = burningSFX;
        audioSource.Play();
    }
}
