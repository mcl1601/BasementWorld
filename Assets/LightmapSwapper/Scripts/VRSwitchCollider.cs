
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class VRSwitchCollider : UdonSharpBehaviour
{
    [SerializeField] VRSwitchManager manager;
    [SerializeField] FingerCollider leftHand, rightHand;
    [SerializeField] Collider _leftHand, _rightHand;
    [SerializeField] float cooldownTimer;
    bool cooldown;
    float counter;
    void Start()
    {
        counter = cooldownTimer;
        cooldown = false;
    }

    void FixedUpdate()
    {
        if(cooldown)
        {
            counter -= Time.deltaTime;
            if(counter < 0)
            {
                cooldown = false;
                counter = cooldownTimer;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider Entered");
        if(cooldown) return;
        if(other == _leftHand) 
        {
            manager.Switch();
            leftHand.PlayHaptic();
            cooldown = true;
        }
        else if (other == _rightHand)
        {
            cooldown = true;
            manager.Switch();
            rightHand.PlayHaptic();
        }
        else return;
    }

    
}
