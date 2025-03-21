using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Window
{
    public interface IWindowService
    {
        GameObject GetWindow(string path);
    }

    public class WindowService : IWindowService
    {
        public GameObject GetWindow(string path)
        {
            return LoadWindow(path);
        }
        
        private static GameObject LoadWindow(string path) =>
            Resources.LoadAll<GameObject>(path).FirstOrDefault()
            ?? throw new Exception($"Не удалось загрузить префаб по пути {path}.");
    }
}