using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] songs;
    private int index = 0;

    private void Awake()
    {
        MusicHandler[] obs = GameObject.FindObjectsOfType<MusicHandler>();
        if (obs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Update()
    {
        if (!this.audioSource.isPlaying)
        {
            this.audioSource.clip = this.songs[index];
            this.audioSource.Play();
            this.index++;
            if (this.index == this.songs.Length)
            {
                this.index = 0;
            }
        }
    }
}
