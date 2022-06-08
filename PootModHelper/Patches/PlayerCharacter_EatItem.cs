using BokuMono;
using HarmonyLib;

namespace PootModHelper.Patches
{
    [HarmonyPatch(typeof(PlayerCharacter), nameof(PlayerCharacter.EatItem))]
    internal class PlayerCharacter_EatItem
    {
        [HarmonyPrefix]
        internal static bool Prefix(PlayerCharacter __instance, int quality)
        {
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(PlayerCharacter __instance)
        {

        }
    }
}
