using UnityEngine;
using Bloodfiend.Core;

namespace Bloodfiend.Gameplay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float _walkSpeed = 3.5f;
        [SerializeField] private float _sprintSpeed = 6.0f;
        [SerializeField] private float _noiseSprintRadius = 8.0f;

        [Header("Stamina Settings")]
        [SerializeField] private float _maxStamina = 100f;
        [SerializeField] private float _staminaDrainRate = 25f;
        [SerializeField] private float _staminaRegenRate = 15f;

        private Rigidbody2D _rb;
        private Vector2 _moveInput;
        private float _currentStamina;
        private bool _isSprinting;

        public float CurrentStamina => _currentStamina;
        public float MaxStamina => _maxStamina;
        public bool IsSprinting => _isSprinting;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _currentStamina = _maxStamina;
        }

        private void Update()
        {
            // Đọc input cơ bản (hỗ trợ cả New Input System và legacy axes)
            _moveInput.x = Input.GetAxisRaw("Horizontal");
            _moveInput.y = Input.GetAxisRaw("Vertical");
            _moveInput.Normalize();

            // Kiểm tra trạng thái chạy nhanh
            bool wantsToSprint = Input.GetKey(KeyCode.LeftShift) && _moveInput.sqrMagnitude > 0.01f;

            if (wantsToSprint && _currentStamina > 0)
            {
                _isSprinting = true;
                _currentStamina -= _staminaDrainRate * Time.deltaTime;
                if (_currentStamina < 0) _currentStamina = 0;

                // Phát tiếng động thu hút quái vật (Speedster)
                NoiseManager.EmitNoise(transform.position, _noiseSprintRadius);
            }
            else
            {
                _isSprinting = false;
                if (_currentStamina < _maxStamina)
                {
                    _currentStamina += _staminaRegenRate * Time.deltaTime;
                    if (_currentStamina > _maxStamina) _currentStamina = _maxStamina;
                }
            }

            // Xoay nhân vật theo con trỏ chuột
            RotateTowardsMouse();
        }

        private void FixedUpdate()
        {
            float speed = _isSprinting ? _sprintSpeed : _walkSpeed;
            _rb.linearVelocity = _moveInput * speed;
        }

        private void RotateTowardsMouse()
        {
            if (Camera.main == null) return;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}

