using BokuMono;
using HarmonyLib;

namespace PootModHelper.Patches.Game
{

    [HarmonyPatch(typeof(GameController), nameof(GameController.Pause))]
    internal class GameController_OnPause
    {
        [HarmonyPrefix]
        internal static bool Prefix(GameController __instance)
        {
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(GameController __instance)
        {
            PatchManager.ExecutePatch(mod => mod.OnGamePaused());
        }
    }
}
