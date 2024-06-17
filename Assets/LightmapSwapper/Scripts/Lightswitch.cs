
using Lightmapmanager;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Lightswitch : UdonSharpBehaviour
{
    [SerializeField] LightmapManager manager;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clipOn, clipOff;
    bool on;

    void Start()
    {
        if(Networking.LocalPlayer.IsUserInVR())
        {
            gameObject.SetActive(false);
        }
        on = true;
    }

    public override void Interact()
    {
        on = !on;
        
        manager.Apply();

        animator.Play((on ? "On" : "Off"));

        audioSource.clip = (on ? clipOn : clipOff);
        audioSource.Play();
    }
}
