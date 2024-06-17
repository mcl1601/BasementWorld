
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DyeSideSwap : UdonSharpBehaviour
{
    [SerializeField] Material mat;
    [SerializeField] MeshRenderer dyeTable;
    void Start()
    {
        
    }

    public override void Interact()
    {
        Material[] temp = new Material[4];
        temp = dyeTable.materials;
        temp[0] = mat;
        dyeTable.materials = temp;
    }
}
