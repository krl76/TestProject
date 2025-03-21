using System;

namespace Player
{
    public interface IPlayerService
    {
        event Action TriggerEnter;
    }

    public class PlayerService : IPlayerService
    {
        public event Action TriggerEnter;
        
        
    }
}