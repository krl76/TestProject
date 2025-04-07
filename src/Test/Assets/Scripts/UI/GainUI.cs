using System;
using Configs;
using Events;
using Providers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
    public class GainUI : MonoBehaviour
    {
        [SerializeField] private Button hp;
        [SerializeField] private Button damage;
        [SerializeField] private Button speed;
        [SerializeField] private GameObject textOfNull;

        private static IEventService _eventService;
        private static ILoadConfigs _loadConfigs;

        private InputActions _inputActions;
        private PlayerConfig _playerConfig;
        private Action _buttonAction;
        private int _buttonCount;

        private void Awake()
        {
            _loadConfigs = new LoadConfigs();
            _eventService = EventService.Instance;
            
            _inputActions = new InputActions();
            _inputActions.Player.ExitFromUI.started += OnExit;
            
            _inputActions.Enable();

            _playerConfig = _loadConfigs.GetPlayerConfig();
            
            hp.onClick.AddListener(OnHp);
            damage.onClick.AddListener(OnDamage);
            speed.onClick.AddListener(OnSpeed);
            
            _buttonAction += ButtonAction;
        }

        private void OnExit(InputAction.CallbackContext context)
        {
            if(context.started) gameObject.SetActive(false);
        }

        private void ButtonAction()
        {
            if (++_buttonCount == 3)
            {
                textOfNull.SetActive(true);
            }
        }

        private void OnHp()
        {
            _playerConfig.HealthPoint += Mathf.RoundToInt(_playerConfig.HealthPoint * 0.05f);
            hp.gameObject.SetActive(false);
            gameObject.SetActive(false);
            _eventService.Event();
            _buttonAction.Invoke();
        }

        private void OnDamage()
        {
            _playerConfig.Damage += Mathf.RoundToInt(_playerConfig.Damage * 0.1f);
            damage.gameObject.SetActive(false);
            gameObject.SetActive(false);
            _eventService.Event();
            _buttonAction.Invoke();
        }

        private void OnSpeed()
        {
            _playerConfig.Speed += Mathf.RoundToInt(_playerConfig.Speed * 0.15f);
            speed.gameObject.SetActive(false);
            gameObject.SetActive(false);
            _eventService.Event();
            _buttonAction.Invoke();
        }
    }
}