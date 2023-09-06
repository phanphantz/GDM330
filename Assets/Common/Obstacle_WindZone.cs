using System.Collections;
using UnityEngine;

namespace SuperGame
{
    public class Obstacle_WindZone : Obstacle
    {
        [SerializeField] SpriteRenderer renderer;
        public override void Play()
        {
            var player = PlayerManager.Instance.GetPlayer();
            StartCoroutine(WindEffect(player.transform));
        }

        IEnumerator WindEffect(Transform player)
        {
            renderer.enabled = true;
            var currentTime = 0f;
            while (currentTime < 1f)
            {
                player.transform.position += new Vector3(0.01f, 0, 0);
                transform.position = player.transform.position;
                currentTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            renderer.enabled = false;
        }
    }
}