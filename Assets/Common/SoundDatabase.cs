using UnityEngine;
using System.Collections.Generic;

namespace SuperGame
{
    [CreateAssetMenu(menuName = "SuperGame/SoundDatabase", fileName = "SoundDatabase")]
    public class SoundDatabase : ScriptableObject
    {
        public List<AudioRecord> recordList = new List<AudioRecord>();
    }
}