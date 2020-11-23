using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public delegate BandMember SellecAction();
    public static event SellecAction OnSellection;
    public TrackManager[] Banda;



    public BandMember selected;
    public static GameManager instance = null;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playAllMembers();
        }
    }




    public void playAllMembers()
    {
        foreach (var item in Banda)
        {
          item.tracksreproduction();
        }
    }

    public void ChangeSelection(BandMember member)
    {
        if (selected != member)
        {
            selected = member;
        }
    }
    public void CancelSelection()
    {
        selected = null;

    }
}
