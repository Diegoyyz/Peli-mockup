using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] BandMembers;
    public Animator Anim;
    public static CameraManager instance;
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
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
