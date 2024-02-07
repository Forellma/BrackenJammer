using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LC_BrackenJammer.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_BrackenJammer
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class BrackenJammer : BaseUnityPlugin
    {
        private const string modGUID = "Forellma.LCBrackenJammer";
        private const string modName = "LC Bracken Jammer";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        internal static BrackenJammer Instance;

        internal static ManualLogSource mls;

        internal ConfigurationController ConfigManager;


        void Awake()
        {
            if (Instance == null) 
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);


            mls.LogInfo("Mod has started");

            harmony.PatchAll(typeof(BrackenJammer));
            harmony.PatchAll(typeof(WalkieTalkiePatch));

            ConfigManager = new ConfigurationController(Config);
            mls = Logger;


        }

        

    }
}
