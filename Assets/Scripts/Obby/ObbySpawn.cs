
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ObbySpawn : UdonSharpBehaviour
{
    public MeshRenderer mat;
    public Vector3 position;
    public Quaternion rotation;
    [SerializeField] ObbyManager manager;

    void Start()
    {
        mat = gameObject.GetComponent<MeshRenderer>();
        position = transform.position;
        rotation = transform.rotation;
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if(player != Networking.LocalPlayer) return;
        
        manager.UpdateSpawn(this);
    }
}
