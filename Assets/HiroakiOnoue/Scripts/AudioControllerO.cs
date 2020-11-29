using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerO : MonoBehaviour
{
    [SerializeField] AudioClip m_load = null;
    AudioSource m_audio;
    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    
    public void LoadSound()
    {
        m_audio.PlayOneShot(m_load);
    }
}

