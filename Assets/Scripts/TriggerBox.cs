
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TriggerBox : UdonSharpBehaviour
{
    [SerializeField] GameObject toToggle;
    [SerializeField] bool activate;
    void Start()
    {
        
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if(player != Networking.LocalPlayer) return;

        toToggle.SetActive(activate);
    }
}
