using System;
using System.Collections.Generic;
using UnityEngine;

namespace SuperGame.Leaderboard
{
    public class UILeaderboard : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] List<PlayerScoreData> playerScoreList = new List<PlayerScoreData>();

        [Header("UI")] [SerializeField] Transform scoreParent;
        [SerializeField] UIPlayerScore scoreUIPrefab;
        [SerializeField] List<UIPlayerScore> scoreUIList = new List<UIPlayerScore>();
        
        void Awake()
        {
            scoreUIPrefab.gameObject.SetActive(false);
            Refresh();
        }

        [ContextMenu(nameof(ClearUIs))]
        void ClearUIs()
        {
            foreach (var uiPlayerScore in scoreUIList)
                Destroy(uiPlayerScore.gameObject);
            
            scoreUIList.Clear();
        }

        public void SetData(List<PlayerScoreData> dataList)
        {
            playerScoreList = dataList;
            Refresh();
        }

        [ContextMenu(nameof(Refresh))]
        void Refresh()
        {
            ClearUIs();
            for (int i = 0; i < playerScoreList.Count; i++)
            {
                var newUI = Instantiate(scoreUIPrefab, scoreParent, false);
                newUI.gameObject.SetActive(true);
                newUI.SetData(playerScoreList[i]);
                scoreUIList.Add(newUI);
            }
        }
    }
}