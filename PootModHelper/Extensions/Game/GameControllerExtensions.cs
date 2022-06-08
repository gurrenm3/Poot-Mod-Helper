using BokuMono;
using BokuMono.Data;
using BokuMono.Utility;

namespace PootModHelper.Api
{
    /// <summary>
    /// Extension methods for <see cref="GameController"/>.
    /// </summary>
    public static class GameControllerExtensions
    {
        /// <summary>
        /// Returns the instance of <see cref="MasterDataManager"/>.
        /// </summary>
        /// <param name="gc"></param>
        /// <returns></returns>
        public static MasterDataManager GetMasterDataMgr(this GameController gc)
        {
            return Singleton<MasterDataManager>.Instance;
        }

        /// <summary>
        /// Returns the instance of <see cref="LanguageManager"/>.
        /// </summary>
        /// <param name="gc"></param>
        /// <returns></returns>
        public static LanguageManager GetLanguageMaster(this GameController gc)
        {
            return Singleton<LanguageManager>.Instance;
        }

        /// <summary>
        /// Returns an <see cref="ItemMasterData"/> based on it's itemId.
        /// </summary>
        /// <param name="gc"></param>
        /// <param name="itemId">The ID of the item you want to get.</param>
        /// <returns>If successful, the item will be returned. Otherwise, it will be null.</returns>
        public static ItemMasterData GetItemFromID(this GameController gc, uint itemId)
        {
            return gc?.GetMasterDataMgr()?.ItemMaster?.GetData(itemId);
        }
    }
}
