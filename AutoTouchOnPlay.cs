using UnityEngine;
using System.Runtime.InteropServices;



public class AutoTouchOnPlay : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SimulateTouchEvent();

    void Start()
    {
        // Call the JavaScript function
        #if UNITY_WEBGL && !UNITY_EDITOR
        SimulateTouchEvent();
        #endif
    }
}
