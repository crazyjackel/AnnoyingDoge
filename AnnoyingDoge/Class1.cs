using System;
using System.Collections;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Reflection;
using UnityEditor;
using MonsterTrainModdingAPI.Managers;
using MonsterTrainModdingAPI.Utilities;

namespace AnnoyingDoge
{
    // Credit to Rawsome, Stable Infery for the base of this method.
    [BepInPlugin("com.name.package.generic", "Test Plugin", "0.1")]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    [BepInDependency("api.modding.train.monster")]
    public class TestPlugin : BaseUnityPlugin
    {
        public GameObject Canvas;
        public GameObject AnnoyingDoge;
        public RectTransform AnnoyingDogeTransform;
        void Awake()
        {
            var harmony = new Harmony("com.name.package.generic");
            harmony.PatchAll();


            Canvas = GameObject.Instantiate(AssetBundleUtils.LoadAssetFromPath<GameObject>("prefab","canvas"));
            AnnoyingDoge = Canvas.transform.Find("Image").gameObject;
            AnnoyingDogeTransform = (RectTransform)AnnoyingDoge.transform;
            DontDestroyOnLoad(Canvas);

            
        }

        void Start()
        {
            foreach (string s in PluginManager.GetAllPluginGUIDs())
            {
                Console.WriteLine(s);
            }
        }

        void Update()
        {
            AnnoyingDogeTransform.position += 0.05f * new Vector3(20*(float)Math.Sin(Time.time/20), 19*(float)Math.Cos(Time.time/21));
        }
    }
}
