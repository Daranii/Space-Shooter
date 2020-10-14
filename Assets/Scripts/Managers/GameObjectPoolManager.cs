using System.Collections.Generic;
using Helper;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Implements Object Pool Pattern for GameObjects.
    /// </summary>
    public class GameObjectPoolManager : BehaviourSingleton<GameObjectPoolManager>
    {
        private readonly Dictionary<string, Queue<GameObject>> _gameObjects
            = new Dictionary<string, Queue<GameObject>>();

        /// <summary>
        /// Requests a Instance of a prefab to be retrieved or created.
        /// </summary>
        /// <returns>GameObject Instance of prefab</returns>
        public GameObject RequestObject(GameObject gameObj, Vector3 position, Quaternion rotation, 
            Transform parent = null)
        {
            var projName = string.Concat(gameObj.name, "(Clone)");
            
            if (!_gameObjects.TryGetValue(projName, out var value))
            {
                // The first time a new prefab is passed through, a new Key is created in the dictionary
                // and a new Queue is added to that Key
                _gameObjects.Add(projName, new Queue<GameObject>());
            }
            else if (value != null && value.Count > 0)
            {
                var returnedObject = _gameObjects[projName].Dequeue();
                returnedObject.transform.position = position;
                returnedObject.transform.rotation = rotation;
                
                return returnedObject;
            }

            // Either if it is the first time a prefab is created, or there are no available GameObjects in the
            // Queue, a new GameObject is instantiated.
            var returnedGameObject = Instantiate(gameObj, position, rotation);
            if (parent) 
                returnedGameObject.transform.parent = parent;
            
            return returnedGameObject;
        }

        /// <summary>
        /// Returns a GameObject to the queue
        /// </summary>
        public void ReturnObject(GameObject gameObj)
        {
            _gameObjects[gameObj.name].Enqueue(gameObj);
        }
    }
}