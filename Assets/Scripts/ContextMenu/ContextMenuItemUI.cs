using MurderByDeath.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MurderByDeath.ContextMenu
{
    public class ContextMenuItemUI : MonoBehaviour
    {
        [SerializeField]
        private Text _text;
        [SerializeField]
        private Button _btn;

        private ContextMenuItemData _data;

        private Action<ContextMenuItemData> _clickAction;

        private void Start()
        {
            _btn.onClick.AddListener(OnButtonClick);
        }

        public void Init(ContextMenuItemData itemData, Action<ContextMenuItemData> clickAction)
        {
            _text.text = itemData.text;
            _clickAction = clickAction;
            _data = itemData;
        }

        private void OnButtonClick()
        {
            _clickAction?.Invoke(_data);
        }
    }
}
