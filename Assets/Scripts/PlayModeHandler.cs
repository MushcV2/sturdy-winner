using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Management;

[InitializeOnLoad]
public class PlayModeHandler
{
    static PlayModeHandler()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            // Desativa os subsistemas XR quando o modo de play termina
            if (XRGeneralSettings.Instance.Manager.activeLoader != null)
            {
                XRGeneralSettings.Instance.Manager.StopSubsystems();
                XRGeneralSettings.Instance.Manager.DeinitializeLoader();
            }
        }
    }
}
