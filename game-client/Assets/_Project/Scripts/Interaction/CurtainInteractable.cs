using UnityEngine;

namespace Bloodfiend.Interaction
{
    /// <summary>
    /// Kéo rèm cửa sổ để ánh nắng tràn vào phòng (Tạo vùng an toàn đẩy lùi quái).
    /// </summary>
    public class CurtainInteractable : MonoBehaviour, IInteractable
    {
        [Header("Settings")]
        [SerializeField] private GameObject _sunlightArea;
        [SerializeField] private bool _isOpen;

        public string GetInteractionPrompt()
        {
            return _isOpen ? "Đóng rèm cửa sổ (E)" : "Kéo rèm đón ánh nắng (E)";
        }

        public void Interact(GameObject interactor)
        {
            _isOpen = !_isOpen;
            if (_sunlightArea != null)
            {
                _sunlightArea.SetActive(_isOpen);
            }
        }
    }
}

