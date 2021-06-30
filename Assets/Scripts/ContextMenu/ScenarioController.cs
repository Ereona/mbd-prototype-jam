using MurderByDeath.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MurderByDeath.ContextMenu
{
    public static class ScenarioController
    {
        public static List<ContextMenuItemData> GetFilteredContextMenu(InteractiveObject obj)
        {
            return obj.GetContextMenu().Where(c => IsContextMenuItemAvailable(obj, c)).ToList();
        }

        private static bool IsContextMenuItemAvailable(InteractiveObject obj, ContextMenuItemData contextMenu)
        {
            //TODO: filter context menu items by different conditions: active character, inventory items, knowledges etc
            return true;
        }
    }
}
