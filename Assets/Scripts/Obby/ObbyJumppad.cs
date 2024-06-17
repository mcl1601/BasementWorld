
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ObbyJumppad : UdonSharpBehaviour
{
    [SerializeField] private float strength = 10.0f;
    private AudioSource audioSrc;
    void Start()
    {
        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    public override void OnPlayerTriggerStay(VRCPlayerApi player)
    {
        if(player != Networking.LocalPlayer) return;

        Vector3 playerVel = Networking.LocalPlayer.GetVelocity();
        Vector3 planer = Vector3.ProjectOnPlane(playerVel, transform.forward);
        playerVel = planer + (transform.forward * strength);
        Networking.LocalPlayer.SetVelocity(playerVel);

        audioSrc.Play();
    }
}
