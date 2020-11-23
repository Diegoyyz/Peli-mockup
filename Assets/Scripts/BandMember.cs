using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BandMember : MonoBehaviour
{
    public TrackManager controller;
    public GameObject Canvas;
    public Role Myrole;
    private void OnEnable()
    {
        controller = gameObject.GetComponentInChildren<TrackManager>();
        controller.gameObject.SetActive(false);
    }
    private BandMember OnMouseUp()
    {
        Canvas.SetActive(true);
        CameraManager.instance.ChangeState(Myrole.ToString());
        controller.gameObject.SetActive(true);
        return this;
    }
    public void DeSellect()
    {
        CameraManager.instance.ChangeState("Idle");
        GameManager.instance.ChangeSelection(null);
        Canvas.SetActive(false);
    }
}
public enum Role
{
    Guitar,
    Drums,
    Bass,
    Idle,
}

