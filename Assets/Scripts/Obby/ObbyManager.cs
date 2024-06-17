
using System;
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
public class ObbyManager : UdonSharpBehaviour
{
    public ObbySpawn activeSpawn;
    [SerializeField] Material offMat;
    [SerializeField] Material onMat;
    [SerializeField] Transform tp;
    [SerializeField] bool devTP;
    private AudioSource audioSource;
    private float timer = 0f;
    private bool running = false;
    [SerializeField] GameObject timerObj;
    private TextMeshProUGUI timerText;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        timerText = timerObj.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(running)
        {
            timer += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        timer = 0f;
        running = true;
        timerText.text = "";
    }

    public void EndTimer()
    {
        if(running == false) return;
        running = false;
        TimeSpan finalTime = TimeSpan.FromSeconds(timer);
        timerText.text = finalTime.Minutes.ToString() + ":" + finalTime.Seconds.ToString() + "." + finalTime.Milliseconds.ToString();
    }

    public void RespawnPlayer()
    {
        if(devTP)
        {
            Networking.LocalPlayer.TeleportTo(tp.position, tp.rotation);
            devTP = false;
            Networking.LocalPlayer.SetVelocity(Vector3.zero);
            return;
        }

        if(activeSpawn == null) return;

        Networking.LocalPlayer.TeleportTo(activeSpawn.position, activeSpawn.rotation);
        Networking.LocalPlayer.SetVelocity(Vector3.zero);
    }

    public void UpdateSpawn(ObbySpawn newSpawn)
    {
        if(activeSpawn != null)
        {
            activeSpawn.mat.material = offMat;
        }

        if(activeSpawn != newSpawn)
        {
            audioSource.Play();
        }

        activeSpawn = newSpawn;

        activeSpawn.mat.material = onMat;
    }
}