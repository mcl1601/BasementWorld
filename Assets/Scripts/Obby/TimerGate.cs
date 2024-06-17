
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TimerGate : UdonSharpBehaviour
{
    [SerializeField] ObbyManager manager;
    [SerializeField] bool start;
    void Start()
    {
        
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if(player != Networking.LocalPlayer) return;

        if(start)
            manager.StartTimer();
        else
            manager.EndTimer();
    }
}
