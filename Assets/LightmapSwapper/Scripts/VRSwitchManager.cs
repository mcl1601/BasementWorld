
using Lightmapmanager;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class VRSwitchManager : UdonSharpBehaviour
{
    [SerializeField] GameObject onCol, offCol;
    [SerializeField] FingerCollider left, right;
    [SerializeField] LightmapManager manager;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clipOn, clipOff;
    bool on;
    void Start()
    {
        Debug.Log("Start Called");
        SendCustomEventDelayedFrames(nameof(LateStarting), 1);
    }

    public void LateStarting() 
    {
        Debug.Log("Late Start Called");
        if(!Networking.LocalPlayer.IsUserInVR())
        {
            gameObject.SetActive(false);
            return;
        }
        on = true;
        Debug.Log("Waiting to Activate...");
        SendCustomEventDelayedSeconds(nameof(ActivateFingers), 5.0f);
    }

    public void ActivateFingers()
    {
        Debug.Log("Activating Fingers...");
        left.enabled = true;
        right.enabled = true;
    }

    public void Switch()
    {
        on = !on;
        
        manager.Apply();

        animator.Play((on ? "On" : "Off"));

        onCol.SetActive(!onCol.activeSelf);
        offCol.SetActive(!offCol.activeSelf);

        audioSource.clip = (on ? clipOn : clipOff);
        audioSource.Play();
    }
}
