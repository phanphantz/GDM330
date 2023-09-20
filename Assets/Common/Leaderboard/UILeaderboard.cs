using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
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

        [ContextMenu(nameof(TestJsonConvert))]
        void TestJsonConvert()
        {
            var scoreJson = JsonConvert.SerializeObject(playerScoreList);
            Debug.Log(scoreJson);
        }

        [ContextMenu(nameof(SaveScoreData))]
        void SaveScoreData()
        {
            var scoreJson = JsonConvert.SerializeObject(playerScoreList);
            var dataPath = Application.dataPath;
            var directoryPath = "score.json";
            var targetFilePath = Path.Combine(dataPath,directoryPath);
            File.WriteAllText(targetFilePath, scoreJson);
        }
        
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