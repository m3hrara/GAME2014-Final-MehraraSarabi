using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource shrinkAudioSource;
    [SerializeField]
    private AudioSource resizeAudioSource;

    public void PlayShrink()
    {
        shrinkAudioSource.Play();
    }
    public void PlayResize()
    {
        resizeAudioSource.Play();
    }
}
