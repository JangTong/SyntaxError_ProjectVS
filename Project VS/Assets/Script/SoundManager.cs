using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager instance = null;

    AudioSource hitSound;

    [SerializeField] AudioClip hit;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        hitSound = GetComponent<AudioSource>();
        hitSound.clip = hit;
    }

    public static SoundManager Instance
    {
        get
        {
            if (instance != null) return instance;
            return null;
        }
    }
    public void HitSound()
    {
        //if(!hitSound.isPlaying)
            hitSound.Play();
    }
}
