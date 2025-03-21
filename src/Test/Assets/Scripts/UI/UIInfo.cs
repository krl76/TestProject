using System;
using Events;
using Providers;
using TMPro;
using UnityEngine;

public class UIInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _texts;

    private static ILoadConfigs _loadConfigs;
    private static IEventService _eventService;
    
    private void Awake()
    {
        _loadConfigs = new LoadConfigs();
        _eventService = EventService.Instance;
        
        var playerConfig = _loadConfigs.GetPlayerConfig();
        _eventService.OnUIButton += OnButtonUpdate;

        _texts[0].text = "HP: " + playerConfig.HealthPoint;
        _texts[1].text = "Speed: " + playerConfig.Speed;
        _texts[2].text = "Damage: " + playerConfig.Damage;
    }

    private void OnButtonUpdate()
    {
        var playerConfig = _loadConfigs.GetPlayerConfig();
        
        _texts[0].text = "HP: " + playerConfig.HealthPoint;
        _texts[1].text = "Speed: " + playerConfig.Speed;
        _texts[2].text = "Damage: " + playerConfig.Damage;
    }
}
