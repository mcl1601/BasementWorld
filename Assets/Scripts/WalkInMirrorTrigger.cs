
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class WalkInMirrorTrigger : UdonSharpBehaviour
{
    private bool isOn;

    [SerializeField]
    private Animator mirrorAnimator;

    void Start()
    {
        isOn = false;
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if(!player.isLocal) return;

        mirrorAnimator.Play("Base Layer.MirrorFadeIn", 0);

        isOn = true;
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if(!player.isLocal || !isOn) return;

        mirrorAnimator.Play("Base Layer.MirrorFadeOut", 0);

        isOn = false;
    }
}
