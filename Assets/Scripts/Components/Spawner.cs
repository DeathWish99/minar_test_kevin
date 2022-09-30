using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{

    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject targetSpawnLocation;
        [SerializeField]
        private GameObject targetMoveLocation;
        public GameObject pooledComponent;
        [SerializeField]
        private MoveableComponent _moveableComponent;

        private void OnDisable()
        {
            //add implementation
        }

        private void OnEnable()
        {
            //add implementation
            HandleOnSpawnTriggered();
        }
        private void Awake()
        {
            pooledComponent = Instantiate(_moveableComponent.gameObject, targetSpawnLocation.transform.position, transform.rotation);
            pooledComponent.SetActive(false);
            enabled = false;
        }

        public void Setup(ICanTriggerSpawn spawnTrigger)
        {
            //add implementation
            spawnTrigger.TriggerSpawn += OnEnable;
        }

        public void EnableScript()
        {
            //remember to enable script from context if needed
            enabled = true;
        }

        public void HandleOnSpawnTriggered()
        {
            //add implementation
            SpawnMoveableObject();
        }

        private void SpawnMoveableObject()
        {
            //add implementation
            pooledComponent.SetActive(true);
            pooledComponent.GetComponent<MoveableComponent>().SetDestination(targetMoveLocation.transform.position);
        }
    }
}