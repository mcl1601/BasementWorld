
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ObbyGlide : UdonSharpBehaviour
{
    private Vector3 recalculatedVel;
    void Start()
    {
        
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if(player != Networking.LocalPlayer) return;

        Vector3 initialVel = player.GetVelocity();
        Vector3 velOnPlane = Vector3.ProjectOnPlane(initialVel, transform.forward).normalized;
        recalculatedVel = velOnPlane * initialVel.magnitude;
    }

    public override void OnPlayerTriggerStay(VRCPlayerApi player)
    {
        if(player != Networking.LocalPlayer) return;

        player.SetVelocity(recalculatedVel);
    }
}
