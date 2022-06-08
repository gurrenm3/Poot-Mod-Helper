using BokuMono;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;

namespace PootModHelper.Api
{
    /// <summary>
    /// Extension methods for <see cref="LocalizeTextProvider"/>.
    /// </summary>
    public static class LocalizeTextProviderExtensions
    {
        /// <summary>
        /// Returns a List containing all TextData for the provided <see cref="LocalizeTextTableType"/>.
        /// </summary>
        /// <param name="textProvider"></param>
        /// <param name="tableType"></param>
        /// <returns></returns>
        public static List<LocalizeTextData> GetLocalizeTextData(this LocalizeTextProvider textProvider, LocalizeTextTableType tableType)
        {
            var textTable = textProvider.GetTextTable(LocalizeTextTableType.Angela);
            return textTable?.list;
        }

        /// <summary>
        /// Returns the name of ID Name of a <see cref="LocalizeTextTableType"/>.
        /// Used to get all dialogs of a TextTable.
        /// <br/><br/>Example: <see cref="LocalizeTextTableType.Angela"/> has an ID Name of 
        /// <see cref="AngelaId"/>.
        /// </summary>
        /// <param name="textProvider"></param>
        /// <param name="tableType"></param>
        /// <returns></returns>
        public static string GetTextTableName(this LocalizeTextProvider textProvider, LocalizeTextTableType tableType)
        {
            return textProvider.FindTextIdType(tableType)?.Name;
        }

        /// <summary>
        /// Returns the ID for the provided <see cref="LocalizeTextTableType"/>.
        /// </summary>
        /// <param name="textProvider"></param>
        /// <param name="tableType"></param>
        /// <returns></returns>
        public static uint GetTextTableId(this LocalizeTextProvider textProvider, LocalizeTextTableType tableType)
        {
            var dialogTypeName = textProvider.GetTextTableName(tableType);
            return textProvider.GetTextTableId(dialogTypeName);
        }

        /// <summary>
        /// Returns the ID for the provided <see cref="LocalizeTextTableType"/>.
        /// </summary>
        /// <param name="textProvider"></param>
        /// <param name="dialogTypeName"></param>
        /// <returns></returns>
        public static uint GetTextTableId(this LocalizeTextProvider textProvider, string dialogTypeName)
        {
            if (string.IsNullOrEmpty(dialogTypeName))
            {
                MyMod.Logger.Error($"Failed to get the TextTable ID because the name was null");
                return 0;
            }

            foreach (var item in textProvider.types)
            {
                if (item == null)
                    continue;

                if (item.Key.Name == dialogTypeName)
                    return item.Value;
            }

            MyMod.Logger.Error($"Failed to get text table ID for {dialogTypeName}");
            return 0;
        }

        /// <summary>
        /// Returns a list of all registered table types.
        /// </summary>
        /// <param name="textProvider"></param>
        /// <returns></returns>
        public static List<Type> GetAllTableTypes(this LocalizeTextProvider textProvider)
        {
            List<Type> types = new List<Type>();
            foreach (var type in textProvider.types)
            {
                if (type != null)
                    types.Add(type.Key);
            }

            return types;
        }

        /// <summary>
        /// Returns a list of the names of each registered table type.
        /// </summary>
        /// <param name="textProvider"></param>
        /// <returns></returns>
        public static List<string> GetAllTableTypeNames(this LocalizeTextProvider textProvider)
        {
            var types = textProvider.GetAllTableTypes();
            if (types == null)
            {
                MyMod.Logger.Error("Failed to get all table types!");
                return null;
            }

            var typeNames = new List<string>();
            foreach (var type in types)
            {
                typeNames.Add(type.Name);
            }
            return typeNames;
        }

        /// <summary>
        /// Returns the <see cref="LocalizeTextTable"/> for a <see cref="LocalizeTextTableType"/>.
        /// </summary>
        /// <param name="textProvider"></param>
        /// <param name="textTable"></param>
        /// <returns></returns>
        public static LocalizeTextTable GetTextTable(this LocalizeTextProvider textProvider, LocalizeTextTableType textTable)
        {
            string textTableName = textProvider.GetTextTableName(textTable);
            return textProvider.GetTextTable(textTableName);
        }

        /// <summary>
        /// Returns the <see cref="LocalizeTextTable"/> for a <see cref="LocalizeTextTableType"/>.
        /// </summary>
        /// <param name="textProvider"></param>
        /// <param name="textTableName"></param>
        /// <returns></returns>
        public static LocalizeTextTable GetTextTable(this LocalizeTextProvider textProvider, string textTableName)
        {
            if (string.IsNullOrEmpty(textTableName))
            {
                MyMod.Logger.Error($"Failed to get the TextTable because the name was null");
                return null;
            }

            foreach (var item in textProvider.tablese)
            {
                if (item.Value.IdType.Name == textTableName)
                    return item.Value;
            }

            return null;
        }
    }
}
