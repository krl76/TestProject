using System;
using Events;
using Providers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GainUI : MonoBehaviour
    {
        [SerializeField] private Button hp;
        [SerializeField] private Button damage;
        [SerializeField] private Button speed;

        private static IEventService _eventService;
        private static ILoadConfigs _loadConfigs;

        private void Awake()
        {
            _loadConfigs = new LoadConfigs();
            _eventService = EventService.Instance;
            
            hp.onClick.AddListener(OnHp);
            damage.onClick.AddListener(OnDamage);
            speed.onClick.AddListener(OnSpeed);
        }

        private void OnHp()
        {
            _loadConfigs.GetPlayerConfig().HealthPoint += 50;
            gameObject.SetActive(false);
            _eventService.Event();
        }

        private void OnDamage()
        {
            _loadConfigs.GetPlayerConfig().Damage += 10;
            gameObject.SetActive(false);
            _eventService.Event();
        }

        private void OnSpeed()
        {
            _loadConfigs.GetPlayerConfig().Speed += 10;
            gameObject.SetActive(false);
            _eventService.Event();
        }
    }
}