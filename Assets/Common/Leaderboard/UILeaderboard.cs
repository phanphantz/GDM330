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

        [Header("Saving")] 
        [SerializeField] string savePath;
        
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
            if (string.IsNullOrEmpty(savePath))
            {
                Debug.LogError("No save path ja");
                return;
            }
            
            var scoreJson = JsonConvert.SerializeObject(playerScoreList);
            var dataPath = Application.dataPath;
            var targetFilePath = Path.Combine(dataPath,savePath);

            var directoryPath = Path.GetDirectoryName(targetFilePath);
            if (Directory.Exists(directoryPath) == false)
                Directory.CreateDirectory(directoryPath);
            
            File.WriteAllText(targetFilePath, scoreJson);
        }

        [ContextMenu(nameof(LoadScoreData))]
        void LoadScoreData()
        {
            var dataPath = Application.dataPath;
            var targetFilePath = Path.Combine(dataPath,savePath);
            
            var directoryPath = Path.GetDirectoryName(targetFilePath);
            if (Directory.Exists(directoryPath) == false)
            {
                Debug.LogError("No save folder at provided path");
                return;
            }

            if (File.Exists(targetFilePath) == false)
            {
                Debug.LogError("No save file at provided path");
                return;
            }

            var scoreJson = File.ReadAllText(targetFilePath);
            playerScoreList = JsonConvert.DeserializeObject<List<PlayerScoreData>>(scoreJson);
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