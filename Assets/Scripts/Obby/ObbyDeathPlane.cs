
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ObbyDeathPlane : UdonSharpBehaviour
{
    [SerializeField] ObbyManager manager;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if(player != Networking.LocalPlayer) return;

        manager.RespawnPlayer();

        if(audioSource)
        {
            audioSource.Play();
        }
    }
}
