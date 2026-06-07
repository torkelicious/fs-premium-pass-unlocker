using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace fspremiumpassunlocker
{
    [BepInPlugin("com.torkelicious.fspremiumpassunlocker", "Premium Pass Unlocker", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource logger;
        private Harmony harmony;

        private void Awake()
        {
            logger = Logger;
            logger.LogInfo("Premium Pass Unlocker is loading...");

            harmony = new Harmony("com.torkelicious.fspremiumpassunlocker.harmony");
            harmony.PatchAll();

            logger.LogInfo("Premium Pass patches applied successfully");
        }
    }

    [HarmonyPatch(typeof(BaseSeasonDataManager), "ImportSaveData")]
    internal class SeasonPassPatch
    {
        [HarmonyPostfix]
        private static void Postfix(BaseSeasonDataManager __instance)
        {
            if (__instance == null) return;

            if (SeasonPassDataManager.Instance == null)
            {
                Plugin.logger.LogWarning("SeasonPassDataManager instance is null. Skipping premium activation for now.");
                return;
            }

            try
            {
                __instance.EnablePremiumPlusPass(saveNonVaultFlags: false);
                Plugin.logger.LogInfo("Successfully unlocked Season Pass Premium Plus for this save");
            }
            catch (Exception e)
            {
                Plugin.logger.LogError($"Failed to grant Premium Plus Pass: {e.Message}");
            }
        }
    }
}
