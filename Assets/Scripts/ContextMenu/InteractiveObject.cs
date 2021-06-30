using MurderByDeath.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.ContextMenu
{
    public class InteractiveObject : MonoBehaviour
    {
        [SerializeField]
        private string _objectId;
        private InteractiveObjectData _data;

        public string ObjectId
        {
            get { return _objectId; }
        }

        public void SetData(InteractiveObjectData data)
        {
            _data = data;
        }

        public List<ContextMenuItemData> GetContextMenu()
        {
            return _data != null ? _data.contextMenu : new List<ContextMenuItemData>();
        }
    }
}
