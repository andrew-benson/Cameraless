using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : ParanormalTrigger {
    public Material diffuse, black;
    VideoPlayer player;
    public MeshRenderer videoRenderer; 

    private void Awake()
    {
        StartEvent += LookedAtTv;
    }

    private void LookedAtTv(object sender, EventArgs e)
    {
        Invoke("PlayScaryVideo", UnityEngine.Random.Range(3, 6));
    }

    private void Player_loopPointReached(VideoPlayer source)
    {
        Destroy(player);
        videoRenderer.material = black;

        FinishedEvent();
    }

    void PlayScaryVideo()
    {
        player = GetComponentInChildren<VideoPlayer>();

        if(player == null || player.isPlaying)
        {
            GetComponent<Collider>().enabled = false;
            return;
        }

        videoRenderer.material = diffuse;
        player.Play();
        player.loopPointReached += Player_loopPointReached;
    }
}
