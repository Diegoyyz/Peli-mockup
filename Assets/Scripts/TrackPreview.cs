using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TrackPreview : MonoBehaviour
{
    public AudioClip Track;
    public TrackManager player;
    public Sprite Wave;
    public bool pushed;
    [Range(0, 2)]
    public float enlargement;
    Vector3 initialsize;

    private void Awake()
    {
        player = GetComponentInParent<TrackManager>();
        initialsize = transform.localScale;
    }
    public void OnMouseOver()
    {
        transform.localScale += new Vector3(2, 2, 0);

    }

    public void triggerPreview()
    {
        if (!pushed)
        {
            transform.localScale += new Vector3(enlargement, enlargement, 0);
            player.SetTrack(Track);
            player.PlayCurrentTrack();
        }
    }
    public void stopPreview()
    {
        player.StopCurrent();
        if (!pushed)
        {
            transform.localScale = initialsize;
        }
    }
    public void AddVisual()
    {
        player.AddNewContainer(Wave);
        pushed = true;
    }
    public void addToTracks()
    {
        player.audios.Add(Track);
    }
}
