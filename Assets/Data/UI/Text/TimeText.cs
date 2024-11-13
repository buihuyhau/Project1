using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeText : BaseText
{
    private float gameTime;
    protected override void Awake()
    {
        gameTime = PlayerPrefs.GetFloat("SavedTime");
        base.Awake();
    }
    private void FixedUpdate()
    {
        gameTime += Time.deltaTime;
        PlayerPrefs.SetFloat("SavedTime", gameTime);

        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);
        this.text.SetText("{0:00}:{1:00}", minutes, seconds);
    }
}

