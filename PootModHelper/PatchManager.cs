using PootModHelper.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PootModHelper
{
    internal class PatchManager
    {
        public static void ExecutePatch(Action<PootMod> action)
        {
            PootMod.loadedMods.ForEach(mod => action.Invoke(mod));
        }
    }
}
