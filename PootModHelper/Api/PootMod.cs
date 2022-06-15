using BokuMono;
using BokuMono.Data;
using BokuMono.FieldEvent;
using BokuMono.Utility;
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
        /// <summary>
        /// Contains all loaded PootMods.
        /// </summary>
        internal static List<PootMod> loadedMods = new List<PootMod>();

        #region Properties

        /// <summary>
        /// The instance of the <see cref="GameController"/>.
        /// </summary>
        public GameController gameController => GameController.Instance;

        /// <summary>
        /// The instance of the <see cref="PlayerCharacter"/>.
        /// </summary>
        public PlayerCharacter playerCharacter => gameController?.playerCharacter;

        /// <summary>
        /// The instance of the player's inventory.
        /// </summary>
        public BagManager playerInventory => gameController?.BM;

        /// <summary>
        /// The instance of <see cref="FacilityData"/>.
        /// </summary>
        public FacilityData facilityData => gameController?.FacilityData;

        /// <summary>
        /// The instance of <see cref="GameSetting"/>.
        /// </summary>
        public GameSetting gameSetting => gameController?.GameSetting;

        /// <summary>
        /// The instance of <see cref="UIConnector"/>.
        /// </summary>
        public UIConnector uiConnector => gameController?.uiConector;


        /// <summary>
        /// The instance of <see cref="MasterDataManager"/>.
        /// </summary>
        public MasterDataManager masterDataMgr => gameController?.GetMasterDataMgr();

        /// <summary>
        /// The instance of <see cref="LanguageManager"/>.
        /// </summary>
        public LanguageManager languageMgr => gameController?.GetLanguageMaster();

        /// <summary>
        /// The instance of <see cref="MakerManager"/>.
        /// </summary>
        public MakerManager makerMgr => SingletonManagerAccessorBehaviour<MakerManager>.Instance;

        /// <summary>
        /// The instance of <see cref="MarriageManager"/>.
        /// </summary>
        public MarriageManager marriageMgr => SingletonManagerAccessorBehaviour<MarriageManager>.Instance;

        /// <summary>
        /// The instance of <see cref="AchieveManager"/>.
        /// </summary>
        public AchieveManager achieveMgr => SingletonManagerAccessorBehaviour<AchieveManager>.Instance;

        public CityDevelopManager cityDevelopMgr => SingletonManagerAccessorBehaviour<CityDevelopManager>.Instance;

        public CookingManager cookingMgr => SingletonManagerAccessorBehaviour<CookingManager>.Instance;

        public DateManager dateMgr => SingletonManagerAccessorBehaviour<DateManager>.Instance;

        public DlcManager dlcMgr => SingletonManagerAccessorBehaviour<DlcManager>.Instance;

        public DialogOpenRequestManager dialogOpenRequestMgr => SingletonManagerAccessorBehaviour<DialogOpenRequestManager>.Instance;

        public EventManager eventMgr => SingletonManagerAccessorBehaviour<EventManager>.Instance;

        public FieldManager fieldMgr => SingletonManagerAccessorBehaviour<FieldManager>.Instance;

        public FishManager fishMgr => SingletonManagerAccessorBehaviour<FishManager>.Instance;

        public FontReferenceManager fontReferenceMgr => SingletonManagerAccessorBehaviour<FontReferenceManager>.Instance;

        public GourmetHouseManager gourmetHouseMgr => SingletonManagerAccessorBehaviour<GourmetHouseManager>.Instance;

        public HelpManager helpMgr => SingletonManagerAccessorBehaviour<HelpManager>.Instance;

        public KoroponManager koroponMgr => SingletonManagerAccessorBehaviour<KoroponManager>.Instance;

        public LikeabilityManager likeabilityMgr => SingletonManagerAccessorBehaviour<LikeabilityManager>.Instance;

        public MuseumManager MuseumMgr => SingletonManagerAccessorBehaviour<MuseumManager>.Instance;




        /// <summary>
        /// Reflects whether or not the game is paused.
        /// <br/>The same as GameController.IsPause.
        /// </summary>
        public bool IsPaused => gameController.IsPause;

        /// <summary>
        /// Reflects whether or not the game is quitting.
        /// <br/>The same as GameController.IsQuitting.
        /// </summary>
        public bool IsQutting => gameController.IsQuitting;

        /// <summary>
        /// Reflects whether or not the player is sleeping.
        /// <br/>The same as GameController.IsSleeping.
        /// </summary>
        public bool IsSleeping => gameController.IsSleeping;



        /// <summary>
        /// The Player's Current Health. 
        /// <br/>The same as GameController.PlayerHP.
        /// </summary>
        public float playerHP { get => gameController.PlayerHP; set => gameController.PlayerHP = value; }

        /// <summary>
        /// The Player's Max Health. 
        /// <br/>The same as GameController.PlayerMaxHP.
        /// </summary>
        public float playerMaxHP { get => gameController.PlayerMaxHP; set => gameController.PlayerMaxHP = value; }

        /// <summary>
        /// The Player's Current Money. 
        /// <br/>The same as GameController.PlayerMoney.
        /// </summary>
        public uint playerMoney { get => gameController.PlayerMoney; set => gameController.PlayerMoney = value; }

        /// <summary>
        /// The Player's Current KoroCoin. 
        /// <br/>The same as GameController.PlayerKoroCoin.
        /// </summary>
        public uint playerKoroCoin { get => gameController.PlayerKoroCoin; set => gameController.PlayerKoroCoin = value; }

        /// <summary>
        /// The Player's Current KoroponPoint. 
        /// <br/>The same as GameController.PlayerKoroponPoint.
        /// </summary>
        public uint playerKoroponPoint { get => gameController.PlayerKoroponPoint; set => gameController.PlayerKoroponPoint = value; }



        /// <summary>
        /// A unique folder made just for this mod. Useful for storing/saving settings/config files/assets/etc.
        /// </summary>
        public string ModFolder
        {
            get => modFolder;
            private set => modFolder = value;
        }
        private string modFolder;

        #endregion


        /// <summary>
        /// Initializes this mod.
        /// </summary>
        public PootMod()
        {
            loadedMods.Add(this);
            
        }

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            modFolder = $"{System.Environment.CurrentDirectory}\\Mods\\{this.Info.Name}";
            Directory.CreateDirectory(modFolder);
        }


        #region Patch Methods


        /// <summary>
        /// Called whenever the MainMenu screen is shown.
        /// </summary>
        public virtual void OnMainMenu() { }

        /// <summary>
        /// Called when the game has loaded a save file.
        /// </summary>
        public virtual void OnGameJoined() { }

        /// <summary>
        /// Called when the game is paused.
        /// </summary>
        public virtual void OnGamePaused() { }

        /// <summary>
        /// Called when the game is resumed after being paused.
        /// </summary>
        public virtual void OnGameResumed() { }

        /// <summary>
        /// Called when the player quits the game.
        /// </summary>
        public virtual void OnGameQuit() { }

        #endregion


        #region Other Methods

        /// <summary>
        /// Returns an <see cref="ItemMasterData"/> based on it's itemId.
        /// </summary>
        /// <param name="itemId">The ID of the item you want to get.</param>
        /// <returns>If successful, the item will be returned. Otherwise, it will be null.</returns>
        public ItemMasterData GetItemFromID(uint itemId)
        {
            return gameController?.GetItemFromID(itemId);
        }

        #endregion
    }
}
