using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pokemon.InventorySystem
{
    public class InventoryPresenter : MonoBehaviour
    {
        int currentItemIndex;
        int currentCategoryIndex;
        int pageSize = 6;

        int maxShownItemCount;
        int maxCategoryCount = 4;
        
        ItemType currentCategory => (ItemType)currentCategoryIndex;
        
        [SerializeField] UIInventory ui;
        [SerializeField] Inventory inventory;
        [SerializeField] List<CategoryInfo> categoryInfoList = new List<CategoryInfo>();

        void Start()
        {
            RefreshUI();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PrevCategory();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                NextCategory();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                PrevItem();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                NextItem();
            }
        }

        void PrevCategory()
        {
            if (currentCategoryIndex <= 0)
                return;
            
            currentCategoryIndex--;
            currentItemIndex = 0;
            RefreshUI();
        }

        void NextCategory()
        {
            if (currentCategoryIndex >= maxCategoryCount - 1)
                return;
            
            currentCategoryIndex++;
            currentItemIndex = 0;
            RefreshUI();
        }

        void PrevItem()
        {
            if (currentItemIndex <= 0)
                return;

            currentItemIndex--;
            RefreshUI();
        }

        void NextItem()
        {
            if (currentItemIndex >= maxShownItemCount -1)
                return;
            
            currentItemIndex++;
            RefreshUI();
        }

        [ContextMenu(nameof(RefreshUI))]
        void RefreshUI()
        {
            var currentCategoryInfo = categoryInfoList[currentCategoryIndex];
            ui.SetCategory(currentCategoryInfo);

            var itemsToDisplay = inventory.GetItemsByType(currentCategory);
            maxShownItemCount = itemsToDisplay.Length;

            if (maxShownItemCount <= 0)
            {
                ui.ClearAllItemUIs();
                return;
            }
            
            var currentItem = itemsToDisplay[currentItemIndex];
            ui.SetCurrentItemInfo(currentItem);
            
            var uiDataList = new List<UIItem_Data>();

            var currentPageIndex = currentItemIndex / pageSize;
            var startIndexToDisplay = currentPageIndex * pageSize;
            var endIndexToDisplay = startIndexToDisplay + pageSize;
            
            var i = 0;
            foreach (var item in itemsToDisplay)
            {
                if (i >= startIndexToDisplay && i < endIndexToDisplay)
                {
                    uiDataList.Add(new UIItem_Data(item, currentItem == item));
                }
              
                i++;
            }

            ui.SetItemList(uiDataList.ToArray());
        }
    }
}