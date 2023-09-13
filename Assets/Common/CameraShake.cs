using UnityEngine;
using DG.Tweening;

namespace SuperGame
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] float duration = 1f;
        [SerializeField] float strength = 10f;
        [SerializeField] int vibrato = 10;
        [SerializeField] float randomness = 10f;
        
        [ContextMenu(nameof(Shake))]
        void Shake()
        {
            transform.DOShakePosition(duration, strength, vibrato, randomness);
        }
    }
}