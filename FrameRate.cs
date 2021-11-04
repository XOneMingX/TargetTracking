using UnityEngine;
using Vuforia;

public class FrameRate : MonoBehaviour
{
    void Start()
    {
        VuforiaApplication.Instance.OnVuforiaStarted += OnVuforiaStarted;
    }

    void OnVuforiaStarted()
    {
        // Query Vuforia for recommended frame rate and set it in Unity
        var targetFps = VuforiaBehaviour.Instance.CameraDevice.GetRecommendedFPS();

        // By default, we use Application.targetFrameRate to set the recommended frame rate.
        // Google Cardboard does not use vsync, and OVR explicitly disables it. If developers 
        // use vsync in their quality settings, they should also set their QualitySettings.vSyncCount
        // according to the value returned above.
        // e.g: If targetFPS > 50 --> vSyncCount = 1; else vSyncCount = 2;
        if (Application.targetFrameRate != targetFps)
        {
            Debug.Log("Setting frame rate to " + targetFps + "fps");
            Application.targetFrameRate = targetFps;
        }
    }
}