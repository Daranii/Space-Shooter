using System;
using System.Collections.Generic;
using Entities;

namespace Managers
{
    public static class ScoreManager
    {
        private static int _score;
        private static readonly Dictionary<Type, int> _scoreValues = new Dictionary<Type, int>();

        static ScoreManager()
        {
            _scoreValues[typeof(Enemy)] = 200;
        }

        public static void AddPoints(Type type)
        {
            _score += _scoreValues[type];
            UiManager.Instance.UpdateScore(_score);
        }
    }
}