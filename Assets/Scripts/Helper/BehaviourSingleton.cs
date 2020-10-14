using UnityEngine;

namespace Helper
{
    /// <summary>
    /// Implements Singleton Pattern for MonoBehaviours.
    /// </summary>
    /// <typeparam name="T">Class name</typeparam>
    public abstract class BehaviourSingleton<T> : MonoBehaviour where T : BehaviourSingleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError(typeof(T) + " is NULL");

                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this as T;

            Init();
        }

        protected virtual void Init() { }
    }
}