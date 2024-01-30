using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Windows;

namespace DropAllItems.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void dropAllItemsPatch(PlayerControllerB __instance)
        {
            if (BepInEx.UnityInput.Current.GetKeyDown("T"))
            {
                DropAllItemsModBase.mls.LogInfo("Trying to discard of all objects");
                __instance.DropAllHeldItems();
            }
        }
    }
}
