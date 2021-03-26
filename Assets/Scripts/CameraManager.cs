using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] BandMembers;
    public Animator Anim;
    public static CameraManager instance;
    public GameObject PlayButton;
    void Awake()
    {
        Anim = gameObject.GetComponent<Animator>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    public void ChangeState(String CamName)
    {
      Anim.SetTrigger(CamName);
        if (CamName== "Idle")
        {
            PlayButton.SetActive(true);
        }
        else
        {
            PlayButton.SetActive(false);
        }
    }   
}
