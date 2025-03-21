using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Window;

namespace Triggers
{
    public class GainTrigger : BaseTrigger
    {
        private static IWindowService _windowService;
        private const string PATH_WINDOW_GAIN = "Window/Gain";
        private const string PATH_WINDOW_INTERACT = "Window/Interact";

        private InputActions _inputActions;

        private GameObject _windowGain;
        private GameObject _windowInteract;
        
        private void Awake()
        {
            _windowService = new WindowService();
            _windowGain = Instantiate(_windowService.GetWindow(PATH_WINDOW_GAIN));
            _windowInteract = Instantiate(_windowService.GetWindow(PATH_WINDOW_INTERACT));

            _inputActions = new InputActions();
            _inputActions.Player.Interaction.started += OnInteraction;
            _inputActions.Player.Interaction.canceled += OnInteraction;
            
            _inputActions.Enable();
        }

        private void OnInteraction(InputAction.CallbackContext ctx)
        {
            if (ctx.started && _windowInteract.activeSelf)
            {
                _windowInteract.SetActive(false);
                _windowGain.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }

        protected override void OnPlayerEnter()
        {
            _windowInteract.SetActive(true);
        }

        protected override void OnPlayerExit()
        {
            _windowInteract.SetActive(false);
        }

        private void OnDestroy()
        {
            _inputActions.Disable();
        }
    }
}