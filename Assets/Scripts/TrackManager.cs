﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine;
public class TrackManager : MonoBehaviour
{
    public List<AudioClip> audios = new List<AudioClip>();
    public GameObject Container;
    public Transform Bar;
    public float Separation;
    private AudioSource _APlayer;

    private void Awake()
    {
        _APlayer = gameObject.GetComponent<AudioSource>();        
    }
    public void tracksreproduction()
    {
        StartCoroutine(playAudioSequentially());
    }
    public IEnumerator playAudioSequentially()
    {
        yield return null;
        for (int i = 0; i < audios.Count; i++)
        {
            _APlayer.clip = audios[i];
            _APlayer.Play();
            while (_APlayer.isPlaying)
            {
                yield return null;
            }
         }
    }
    public void PlayCurrentTrack()
    {
        _APlayer.Stop();
        _APlayer.Play();
    }
    public void StopCurrent()
    {
        _APlayer.Stop();
    }
    public void AddNewContainer(Sprite img)
    {
        var toSpawn = Instantiate(Container);
        toSpawn.transform.SetParent(Bar);
        toSpawn.GetComponent<Image>().sprite = img;
        toSpawn.GetComponent<Image>().rectTransform.transform.localPosition = new Vector3(0 + Separation * audios.Count-1, 0, 0);
        toSpawn.GetComponent<Image>().rectTransform.localScale = new Vector3(1, 1, 1);

    }
    public void SetTrack(AudioClip preview) 
    {
        _APlayer.clip = preview;
        PlayCurrentTrack();
    }  
}
