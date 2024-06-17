
using System.Collections.Generic;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;





#if !COMPILER_UDONSHARP && UNITY_EDITOR
using UnityEditor;
using UdonSharpEditor;
#endif

namespace Lightmapmanager 
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class LightmapManager : UdonSharpBehaviour
    {
        [SerializeField] LightmapHolder[] lightMapHolders;
        public Renderer[] renderers;
        public ReflectionProbe[] refProbes;
        MaterialPropertyBlock block;
        [SerializeField] int activeLightmapHolder = 0;

        void Start()
        {
            block = new MaterialPropertyBlock();
            ToggleActiveProbes();
        }

        public void Apply()
        {
            ToggleActiveProbes();
            activeLightmapHolder = (activeLightmapHolder + 1) % lightMapHolders.Length;

            foreach (var renderer in renderers)
            {
                var index = renderer.lightmapIndex;
                if (index < 0) continue;
                renderer.GetPropertyBlock(block);
                block.SetTexture("unity_Lightmap", lightMapHolders[activeLightmapHolder].lightmaps[index]);
                renderer.SetPropertyBlock(block);
            }

            ToggleActiveProbes();
        }

        public void ToggleActiveProbes()
        {
            foreach(ReflectionProbe probe in refProbes)
            {
                probe.RenderProbe();
            }
        }
    }

    #if !COMPILER_UDONSHARP && UNITY_EDITOR
    [CustomEditor(typeof(LightmapManager))]
    public class LightmapPopulator : Editor
    {
        public override void OnInspectorGUI()
        {
            if (UdonSharpGUI.DrawDefaultUdonSharpBehaviourHeader(target)) return;

            DrawDefaultInspector();

            LightmapManager manager = (LightmapManager)target;

            if(GUILayout.Button("Populate Renderers and Reflection Probes"))
            {
                manager.renderers = getRenderers();
                manager.refProbes = getProbes();
            }

            if(GUILayout.Button("Bake Reflection Probes"))
            {
                manager.ToggleActiveProbes();
            }
        }

        private Renderer[] getRenderers()
        {
            Renderer[] rawRenderers = FindObjectsOfType<Renderer>(true);
            List<Renderer> renderers = new List<Renderer>();
            foreach(Renderer r in rawRenderers)
            {
                if(GameObjectUtility.GetStaticEditorFlags(r.gameObject).HasFlag(StaticEditorFlags.ContributeGI))
                {
                    renderers.Add(r);
                }
            }

            return renderers.ToArray();
        }

        private ReflectionProbe[] getProbes()
        {
            ReflectionProbe[] rawProbes = FindObjectsOfType<ReflectionProbe>(false);
            List<ReflectionProbe> probes = new List<ReflectionProbe>();
            foreach(ReflectionProbe probe in rawProbes)
            {
                if(probe.mode == UnityEngine.Rendering.ReflectionProbeMode.Realtime)
                {
                    probes.Add(probe);
                }
            }

            return probes.ToArray();
        }
    }
    #endif
}


