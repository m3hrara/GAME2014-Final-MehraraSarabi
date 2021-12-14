/*
SFXManager.cs
Author: Mehrara Sarabi 
Student ID: 101247463
Last modified: 2021-12-14
Description: This program contains the two functions of playing shrink sfx and resize sfx. It can be called from the floating platforms on 
player collision.
 */

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
