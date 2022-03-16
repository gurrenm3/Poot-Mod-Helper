using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Events;

namespace PootModHelper.Api
{
    /// <summary>
    /// A helpful base class for POOT mods.
    /// </summary>
    public abstract class PootMod : MelonMod
    {
        #region Properties

        internal static List<PootMod> loadedMods = new List<PootMod>();


        /// <summary>
        /// A unique folder made just for this mod. Useful for storing/saving settings/config files/assets/etc.
        /// </summary>
        public string ModFolder
        {
            get 
            { 
                Directory.CreateDirectory(modFolder);
                return modFolder; 
            }
            private set { modFolder = value; }
        }
        private string modFolder;

        #endregion



        public PootMod()
        {
            loadedMods.Add(this);
        }

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            ModFolder = $"{Environment.CurrentDirectory}\\Mods\\{this.Info.Name}";
        }


        #region Patch Methods


        /// <summary>
        /// Called whenever the MainMenu screen is shown.
        /// </summary>
        public virtual void OnMainMenu() { }

        #endregion
    }
}
