using MurderByDeath.Data;
using MurderByDeath.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MurderByDeath.ContextMenu
{
    public class ContextMenuUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject _menuRoot;
        [SerializeField]
        private ContextMenuItemUI _itemPrefab;
        [SerializeField]
        private RectTransform _itemsParent;

        private List<ContextMenuItemUI> _items = new List<ContextMenuItemUI>();
        private Action<ContextMenuItemData> _clickAction;

        public void Init(Vector2 pos, List<ContextMenuItemData> contextMenu)
        {
            Clear();
            Vector2 localPoint = new Vector2(pos.x / _itemsParent.lossyScale.x, pos.y / _itemsParent.lossyScale.y);
            _itemsParent.anchoredPosition = localPoint;
            foreach (ContextMenuItemData itemData in contextMenu)
            {
                ContextMenuItemUI item = SimplePool.Spawn(_itemPrefab.gameObject).GetComponent<ContextMenuItemUI>();
                item.Init(itemData, OnItemClick);
                item.transform.SetParent(_itemsParent);
                item.transform.localScale = Vector3.one;
                item.transform.SetAsLastSibling();
                _items.Add(item);
            }
        }

        public void Show()
        {
            _menuRoot.SetActive(true);
        }

        public void Hide()
        {
            _menuRoot.SetActive(false);
        }

        public void SetClickAction(Action<ContextMenuItemData> clickAction)
        {
            _clickAction = clickAction;
        }

        private void Clear()
        {
            foreach (ContextMenuItemUI item in _items)
            {
                SimplePool.Despawn(item.gameObject);
            }
            _items.Clear();
        }

        private void OnItemClick(ContextMenuItemData itemData)
        {
            _clickAction?.Invoke(itemData);
        }
    }
}
