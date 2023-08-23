using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pokemon.InventorySystem
{
    public class UIInventory : MonoBehaviour
    {
        [Header("Category")]
        [SerializeField] Image categoryIconImage;
        [SerializeField] Text categoryText;
        
        [Header("Current Item")]
        [SerializeField] Image currentItemIconImage;
        [SerializeField] Text descriptionText;

        [Header("Item List")] 
        [SerializeField] UIItem itemUIPrefab;
        [SerializeField] List<UIItem> itemUIList = new List<UIItem>();

        void Start()
        {
            itemUIPrefab.gameObject.SetActive(false);
        }

        public void SetCategory(CategoryInfo info)
        {
            categoryIconImage.sprite = info.icon;
            categoryText.text = info.name;
        }
        
        public void SetCurrentItemInfo(ItemData data)
        {
            descriptionText.text = data.description;
            currentItemIconImage.sprite = data.icon;
        }

        public void SetItemList(UIItem_Data[] uiDatas)
        {
            ClearAllItemUIs();
            foreach (var uiItemData in uiDatas)
            {
                var newItemUI = Instantiate(itemUIPrefab,itemUIPrefab.transform.parent,false);
                newItemUI.gameObject.SetActive(true);
                itemUIList.Add(newItemUI);
                newItemUI.SetData(uiItemData);
            }
        }

        public void ClearAllItemUIs()
        {
            foreach (UIItem uiItem in itemUIList)
                Destroy(uiItem.gameObject);
            
            itemUIList.Clear();
        }
    }

    [Serializable]
    public class CategoryInfo
    {
        public string name;
        public Sprite icon;
    }
}