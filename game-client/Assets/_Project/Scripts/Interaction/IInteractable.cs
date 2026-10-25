using UnityEngine;

namespace Bloodfiend.Interaction
{
    public interface IInteractable
    {
        string GetInteractionPrompt();
        void Interact(GameObject interactor);
    }
}

