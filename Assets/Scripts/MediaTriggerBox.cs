
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MediaTriggerBox : UdonSharpBehaviour
{
    [SerializeField]
    private RectTransform mediaControls;
    [SerializeField]
    private Vector3 posOn;
    [SerializeField]
    private Vector3 posOff;
    void Start()
    {
        
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if(!player.isLocal) return;

        mediaControls.localPosition = posOn;
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if(!player.isLocal) return;

        mediaControls.localPosition = posOff;
    }
}
