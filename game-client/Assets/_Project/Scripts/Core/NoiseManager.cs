using System;
using UnityEngine;

namespace Bloodfiend.Core
{
    /// <summary>
    /// Quản lý hệ thống phát và nhận diện tiếng ồn trong không gian 2D.
    /// Dành cho các quái vật nhạy cảm âm thanh (như Speedster).
    /// </summary>
    public class NoiseManager : MonoBehaviour
    {
        public static NoiseManager Instance { get; private set; }

        public static event Action<Vector2, float> OnNoiseEmitted;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Phát ra tiếng ồn tại một vị trí với bán kính lan tỏa nhất định.
        /// </summary>
        /// <param name="position">Vị trí phát ra tiếng ồn</param>
        /// <param name="radius">Bán kính âm thanh lan tới</param>
        public static void EmitNoise(Vector2 position, float radius)
        {
            OnNoiseEmitted?.Invoke(position, radius);
        }
    }
}

