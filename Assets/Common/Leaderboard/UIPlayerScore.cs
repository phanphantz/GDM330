using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SuperGame.Leaderboard
{
    public class UIPlayerScore : MonoBehaviour
    {
        [SerializeField] TMP_Text orderText;
        [SerializeField] Image photoImage;
        [SerializeField] TMP_Text usernameText;
        [SerializeField] TMP_Text scoreText;
        [SerializeField] List<Image> starList = new List<Image>();

        public void SetPhoto(Sprite photo)
        {
            photoImage.sprite = photo;
        }
        
        public void SetData(PlayerScoreData data)
        {
            orderText.text = data.order.ToString();
            usernameText.text = data.username;
            scoreText.text = data.score.ToString();

            for (int i = 0; i < starList.Count; i++)
                starList[i].color = i < data.star? Color.white : Color.black;
        }
    }
}