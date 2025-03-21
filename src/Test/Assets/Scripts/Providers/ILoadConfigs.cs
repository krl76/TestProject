using System;
using System.Linq;
using Configs;
using UnityEngine;

namespace Providers
{
    public interface ILoadConfigs
    {
        PlayerConfig GetPlayerConfig();
    }

    public class LoadConfigs : ILoadConfigs
    {
        private readonly PlayerConfig _playerConfig;
        
        public LoadConfigs()
        {
            _playerConfig = LoadConfig<PlayerConfig>("Configs");
        }

        public PlayerConfig GetPlayerConfig() => _playerConfig;
        
        private static T LoadConfig<T>(string path) where T : ScriptableObject =>
            Resources.LoadAll<T>(path).FirstOrDefault()
            ?? throw new Exception($"Не удалось загрузить конфигурацию типа {typeof(T).Name} по пути {path}.");
    }
}