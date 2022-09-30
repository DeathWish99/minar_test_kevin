using Project.Components;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Hometown
{
    [RequireComponent(typeof(InputManager) , typeof(Spawner))]
    public class HometownContext : MonoBehaviour
    {
        [SerializeField]
        private InputManager _inputManager;
        [SerializeField]
        private Spawner _spawner;

        private UpgradeableRepository _upgradeableRepository;

        public HouseController HouseController { get; private set; }
        public HouseView HouseView;
        

        private void Awake()
        {
            if(_inputManager == null)
            {
                _inputManager = GetComponent<InputManager>();
            }

            if (_spawner == null)
            {
                _spawner =  GetComponent<Spawner>();
            }

            //add implementation
            _upgradeableRepository = new UpgradeableRepository(this);
            HouseController = new HouseController(this, "House", _inputManager, _upgradeableRepository);
            if(HouseView == null)
            {
                HouseView = GetComponent<HouseView>();
            }
            HouseView.Setup(HouseController);
        }

        private void Update()
        {
            if(HouseController.upgradeableData != null)
            {
                if ((HouseController.upgradeableData.Level == HouseController.upgradeableData.MaxLevel))
                {
                    _spawner.enabled = true;
                }
            }
        }

        private void OnDestroy()
        {
            //add implementation
        }
    }
}