using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using Utilla;

namespace Penthouse
{
    /// <summary>
    /// This is your mod's main class.u
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.6.4")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        public GameObject penthouse;
        void OnGameInitialized(object sender, EventArgs e)
        {
            /* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
            Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("Penthouse.Assets.penthouse");
            AssetBundle bundle = AssetBundle.LoadFromStream(str);
            GameObject house = bundle.LoadAsset<GameObject>("penthouse");
            penthouse = Instantiate(house);
            penthouse.SetActive(false);
        }
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            inRoom = true;
            penthouse.SetActive(true);
        }
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            inRoom = false;
            penthouse.SetActive(false);
        }
    }
}
