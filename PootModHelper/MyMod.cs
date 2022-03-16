using MelonLoader;
using PootModHelper.Api;

namespace PootModHelper
{
    internal class MyMod : PootMod
    {
        public static MelonLogger.Instance Logger { get; private set; }
        public static MyMod Instance { get; private set; }

        public const string modName = "Poot Mod Helper";
        public const string modVersion = "1.0.0.0";
        public const string modAuthor = "Gurrenm4";

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();

            Instance = this;
            Logger = LoggerInstance;

            Logger.Msg($"{modName} has finished loading");
        }
    }
}
