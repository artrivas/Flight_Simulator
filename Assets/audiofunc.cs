using System.Collections;
using System.Collections.Generic;

//This script allows you to toggle music to play and stop.
//Assign an AudioSource to a GameObject and attach an Audio Clip in the Audio Source. Attach this script to the GameObject.

using UnityEngine;

public class audiofunc : MonoBehaviour
{
    AudioSource m_MyAudioSource;

    [SerializeField]
    private List<AudioClip> m_AudioClips;

    bool m_Play;
    bool m_ToggleChange;


    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        m_Play= true;
        m_ToggleChange = true;

        // 1 debería ser el max de duración de todos tus audios
        float time = Random.Range(4, 10);
        Invoke("playAudio", time);
    }

    void playAudio()
    {
        var position = Random.Range(0, m_AudioClips.Count);

        //if (m_Play && m_ToggleChange)
        //{
            Debug.Log("playing\n");
            m_MyAudioSource.clip = m_AudioClips[position];
            m_MyAudioSource.Play();
        //}
        //m_Play = true;

        float time = Random.Range(4, 10);
        Invoke("playAudio", time);
    }

    /*
    void OnGUI()
    {
        //Switch this toggle to activate and deactivate the parent GameObject
        m_Play = GUI.Toggle(new Rect(10, 10, 100, 30), m_Play, "Play Music");

        //Detect if there is a change with the toggle
        if (GUI.changed)
        {
            //Change to true to show that there was just a change in the toggle state
            m_ToggleChange = true;
        }
    }*/
}
