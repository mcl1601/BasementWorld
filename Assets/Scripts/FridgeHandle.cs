
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class FridgeHandle : UdonSharpBehaviour
{
    [SerializeField]
    private Animator animator;
    private bool open;

    void Start()
    {
        open = false;
    }

    public override void Interact()
    {
        if(open)
        {
            animator.Play("FridgeClose");
            open = false;
        } 
        else 
        {
            animator.Play("FridgeOpening");
            open = true;
        }
    }
}
