using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Bloodfiend.Gameplay
{
    public enum FlashlightMode
    {
        Off,
        LowPower,
        HighPower
    }

    /// <summary>
    /// Điều khiển đèn pin: Chế độ thường (soi đường) vs Chế độ công suất cao (khống chế quái).
    /// </summary>
    public class FlashlightController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Light2D _flashlightSource;
        [SerializeField] private Collider2D _highBeamTrigger; // Collider gây choáng quái

        [Header("Battery Settings")]
        [SerializeField] private float _maxBattery = 100f;
        [SerializeField] private float _lowDrainRate = 1.5f;   // Tiêu hao pin mức thấp (% / giây)
        [SerializeField] private float _highDrainRate = 6.0f;  // Tiêu hao pin mức cao (% / giây)

        [Header("Light Intensity Settings")]
        [SerializeField] private float _lowIntensity = 1.0f;
        [SerializeField] private float _highIntensity = 2.5f;
        [SerializeField] private float _lowOuterAngle = 45f;
        [SerializeField] private float _highOuterAngle = 65f;

        private float _currentBattery;
        private FlashlightMode _currentMode = FlashlightMode.Off;

        public float CurrentBattery => _currentBattery;
        public float MaxBattery => _maxBattery;
        public FlashlightMode CurrentMode => _currentMode;

        private void Awake()
        {
            _currentBattery = _maxBattery;
            SetMode(FlashlightMode.Off);
        }

        private void Update()
        {
            // Phím F: Bật / Tắt đèn
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (_currentMode == FlashlightMode.Off)
                    SetMode(FlashlightMode.LowPower);
                else
                    SetMode(FlashlightMode.Off);
            }

            // Phím Q: Chuyển đổi giữa mức thấp và mức cao
            if (Input.GetKeyDown(KeyCode.Q) && _currentMode != FlashlightMode.Off)
            {
                if (_currentMode == FlashlightMode.LowPower)
                    SetMode(FlashlightMode.HighPower);
                else
                    SetMode(FlashlightMode.LowPower);
            }

            // Xử lý tiêu hao pin
            HandleBatteryConsumption();
        }

        private void HandleBatteryConsumption()
        {
            if (_currentMode == FlashlightMode.Off) return;

            float drainRate = _currentMode == FlashlightMode.HighPower ? _highDrainRate : _lowDrainRate;
            _currentBattery -= drainRate * Time.deltaTime;

            if (_currentBattery <= 0f)
            {
                _currentBattery = 0f;
                SetMode(FlashlightMode.Off);
            }
        }

        public void SetMode(FlashlightMode mode)
        {
            if (_currentBattery <= 0f && mode != FlashlightMode.Off) return;

            _currentMode = mode;

            if (_flashlightSource == null) return;

            switch (_currentMode)
            {
                case FlashlightMode.Off:
                    _flashlightSource.enabled = false;
                    if (_highBeamTrigger != null) _highBeamTrigger.enabled = false;
                    break;

                case FlashlightMode.LowPower:
                    _flashlightSource.enabled = true;
                    _flashlightSource.intensity = _lowIntensity;
                    _flashlightSource.pointLightOuterAngle = _lowOuterAngle;
                    if (_highBeamTrigger != null) _highBeamTrigger.enabled = false;
                    break;

                case FlashlightMode.HighPower:
                    _flashlightSource.enabled = true;
                    _flashlightSource.intensity = _highIntensity;
                    _flashlightSource.pointLightOuterAngle = _highOuterAngle;
                    if (_highBeamTrigger != null) _highBeamTrigger.enabled = true;
                    break;
            }
        }

        public void Recharge(float amount)
        {
            _currentBattery = Mathf.Clamp(_currentBattery + amount, 0f, _maxBattery);
        }
    }
}

