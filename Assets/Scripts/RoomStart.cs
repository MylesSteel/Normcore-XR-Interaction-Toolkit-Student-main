using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Normal.Realtime;


public class RoomStart : RealtimeComponent<RoomStartModel>
{
    [SerializeField] private Text _countdown;
    [SerializeField] private float countdownDuration;
    [SerializeField] private GameManager gameManager;
    public float time
    {
        get
        {
            // return 0 if model not set
            if (model == null) return 0f;
            //make sure time is running 
            if (model.startTime == 0f) return 0f;
            // Calculate how much time has passed
            return (float)(model.startTime - realtime.room.time); 
           // return (float)(countdownDuration -= Time.deltaTime) ;
        }
    }


    public void StartCountdown()
    {
        model.startTime = realtime.room.time + countdownDuration; 
        StartCoroutine(UpdateTime());
    }
    IEnumerator UpdateTime()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        while (timeSpan.Seconds > 0)
        {
            timeSpan = TimeSpan.FromSeconds(time);
            _countdown.text = "Game Starts In: " + timeSpan.Seconds ;
            yield return null;
        }
        gameManager.StartGame();
        gameObject.SetActive(false);

    }
}
