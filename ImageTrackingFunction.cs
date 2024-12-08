using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ImageTrackingFunction : MonoBehaviour
{
    public vid_url_test videoController; // Reference to the vid_url_test component
    public vid_title titleManager; // Reference to vid_title instance
    public MarqueeText textScroller1;
    public MarqueeText textScroller2;
    public VideoPlayer videoPlayer_force;
   

    public void TargetSeen()
    {
        // Play the next video
        int currentIndex = videoController.PlayNextVideo();
        videoPlayer_force.Play();
        
        
        // Display the corresponding title
        titleManager.DisplayTitle(currentIndex);

        textScroller1.ToggleDirection();
        textScroller2.ToggleDirection();

    }

    // public void TargetNotSeen()
    // {   
    // }
}
