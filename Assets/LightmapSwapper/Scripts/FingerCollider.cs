
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class FingerCollider : UdonSharpBehaviour
{
    [SerializeField] HumanBodyBones bone = HumanBodyBones.LeftIndexDistal;
    [SerializeField] VRC_Pickup.PickupHand hand = VRC_Pickup.PickupHand.Left;
    private VRCPlayerApi _lp;
    void Start()
    {
        _lp = Networking.LocalPlayer;
        Debug.Log("Finger Activated");
    }

    void Update()
    {
        if(_lp == null) return;
        transform.position = _lp.GetBonePosition(bone);
    }

    public void PlayHaptic()
    {
        _lp.PlayHapticEventInHand(hand, 0.5f, 0.5f, 0.5f);
    }
}
