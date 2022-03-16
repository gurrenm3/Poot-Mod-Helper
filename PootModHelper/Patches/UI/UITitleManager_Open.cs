using BokuMono;
using HarmonyLib;

namespace PootModHelper.Patches.UI
{
    [HarmonyPatch(typeof(UITitleManager), nameof(UITitleManager.Open))]
    internal class UITitleManager_Open
    {

        [HarmonyPostfix]
        internal static void Postfix(UITitleManager __instance)
        {
            PatchManager.ExecutePatch(m => m.OnMainMenu());
        }
    }
}
