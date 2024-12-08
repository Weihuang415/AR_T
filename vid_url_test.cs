using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class vid_url_test : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public int videoNumber;

    public vid_title titleManager; // Reference to title manager
    private List<string> videoURLs = new List<string>();
    private int currentIndex = 0;

    private HashSet<int> playedVideos = new HashSet<int>();
    private bool allVideosPlayed = false;

    void Start()
    {
        for (int i = 0; i <= videoNumber; i++)
        {
            string videoURL = $"https://weihuang415.github.io/video_webgl/video{i:D2}.mp4";
            videoURLs.Add(videoURL);
        }

        PlayCurrentVideo();
       
    }

    public int PlayNextVideo()
    {
        // Play the next video
        currentIndex = (currentIndex + 1) % videoURLs.Count;
        PlayCurrentVideo();

        // Track played videos
        playedVideos.Add(currentIndex);

        // Check if all videos have been played
        if (playedVideos.Count == videoURLs.Count && !allVideosPlayed)
        {
            allVideosPlayed = true;
            titleManager.UpdateAllTitles("ART ART ART ART ART ART ART ART ART ART ART ART ART ART ART ART ART ART ART ART"); // Update titles
        }

        return currentIndex;
    }

    void PlayCurrentVideo()
    {
        videoPlayer.url = videoURLs[currentIndex];
        // Instead of preparing, directly start the video
        videoPlayer.Play();
    }



    public int GetCurrentIndex()
    {
        return currentIndex;
    }
}
