using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class vid_url_test : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoPlayer videoPlayerEnd;
    public Button restartButton; // Reference to the restart button
    
    private List<string> videoURLs = new List<string>();
    // private string videoURLEnd = "https://weihuang415.github.io/video_webgl/video_end.mp4";

    public vid_title titleManager; // Reference to title manager



    public int videoNumber;
    private int currentIndex = 0;

    private bool allVideosPlayed = false;

    void Start()
    {
        for (int i = 0; i <= videoNumber; i++)
        {
            string videoURL = $"https://weihuang415.github.io/video_webgl/video{i:D2}.mp4";
            videoURLs.Add(videoURL);
        }
        
        // Start playing the first video
        currentIndex = 0; // Ensure we start from the first video
        PlayCurrentVideo();

        // Ensure the ending video player and restart button are hidden initially
        videoPlayerEnd.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        // Add listener to the restart button
        restartButton.onClick.AddListener(RestartSequence);
       
    }

    public int PlayNextVideo()
    {   
        if (!allVideosPlayed)
        {
            if (currentIndex < videoURLs.Count - 1)
            {
                // Play the next video
                currentIndex++;
                PlayCurrentVideo();
            }
            else if (currentIndex == videoURLs.Count - 1)
            {
                // Mark all videos as played
                allVideosPlayed = true;

                // Update titles
                titleManager.UpdateAllTitles("ART ART ART ART ART ART ART ART RESTART RESTART RESTART ART ART ART ART ART ART");

                // Show and play the ending video
                videoPlayerEnd.gameObject.SetActive(true);
                videoPlayerEnd.Play();

                videoPlayer.SetDirectAudioVolume(0, 0f);
                
                // Show the restart button after the ending video finishes
                StartCoroutine(ShowRestartButtonAfterVideo());
            }
     
        }
        return currentIndex;
    }
    IEnumerator ShowRestartButtonAfterVideo()
    {
        // Wait until the ending video finishes
        while (videoPlayerEnd.isPlaying)
        {
            yield return null;
        }

        // Show the restart button
        restartButton.gameObject.SetActive(true);
    }

    void PlayCurrentVideo()
    {
        // Play the current video
        videoPlayer.url = videoURLs[currentIndex];
        videoPlayer.Play();

    }

    public void RestartSequence()
    {
        // Reset variables
        currentIndex = 0;
        allVideosPlayed = false;

        // Clear titles
        titleManager.ResetTitles();

        // Hide the restart button and ending video player
        restartButton.gameObject.SetActive(false);
        videoPlayerEnd.gameObject.SetActive(false);

        // Show the main video player
        videoPlayer.gameObject.SetActive(true);

        // Start from the first video
        PlayCurrentVideo();
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }
}
