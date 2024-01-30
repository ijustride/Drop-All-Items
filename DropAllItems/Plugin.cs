using BepInEx;
using BepInEx.Logging;
using DropAllItems.Patches;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropAllItems
{
    [BepInPlugin(modGUID,modName,modVersion)]
    public class DropAllItemsModBase : BaseUnityPlugin
    {
        private const string modGUID = "brooklynbaby.DropAllItems";
        private const string modName = "DropAllItems";
        private const string modVersion = "0.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static DropAllItemsModBase Instance;

        public static ManualLogSource mls;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("The DropAllItems mod has awaken :");
            harmony.PatchAll(typeof(DropAllItemsModBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}
