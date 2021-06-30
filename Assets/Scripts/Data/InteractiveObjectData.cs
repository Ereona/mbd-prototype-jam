using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.Data
{
    [Serializable]
    public class InteractiveObjectData
    {
        public string objectId;
        public List<ContextMenuItemData> contextMenu;
    }
}
