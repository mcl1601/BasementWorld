
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class LightProbeTesting : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject probe;

    void Start()
    {
        
    }

    public override void Interact()
    {
        probe.SetActive(!probe.activeSelf);
    }
}
