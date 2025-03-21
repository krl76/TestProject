using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Recources/" + nameof(PlayerConfig))]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] public float Speed;
        [SerializeField] public float HealthPoint;
        [SerializeField] public float Damage;
    }
}