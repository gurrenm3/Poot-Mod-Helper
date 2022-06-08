using BokuMono;
using HarmonyLib;

namespace PootModHelper.Patches.Game
{
    [HarmonyPatch(typeof(GameController), nameof(GameController.Resume))]
    internal class GameController_OnResume
    {
        private static bool isFirstLoad = true;
        [HarmonyPrefix]
        internal static bool Prefix(GameController __instance)
        {
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(GameController __instance)
        {
            if (isFirstLoad)
            {
                isFirstLoad = false;
                return;
            }

            PatchManager.ExecutePatch(mod => mod.OnGameResumed());
        }
    }
}
