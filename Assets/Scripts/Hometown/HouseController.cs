using Project.Components;
using System;
using UnityEngine;

namespace Project.Hometown
{
    public class HouseController : IController, IUpgradeable , ICanTriggerSpawn
    {
        public event Action<LevelupEventData> OnLevelUp;
        public event Action TriggerSpawn;

        public UpgradeableData upgradeableData;
        private HometownContext _hometownContext;
        private string _itemName;

        public void OnContextDispose()
        {
            //add implementation
        }

        public HouseController(HometownContext hometownContext , string upgradeableItemName , InputManager inputManager, UpgradeableRepository upgradeableRepository)
        {
            _hometownContext = hometownContext;
            _itemName = upgradeableItemName;
            inputManager.OnInputTouch += HandleOnInputTouch;

            //add implementation
            upgradeableRepository.GetUpgradeableData(x => {
                upgradeableData = x;
            });
        }

        public void Upgrade()
        {
            Debug.Log($"Handle Upgrade {_itemName}");
            //add implementation
            upgradeableData.LevelUp();

            LevelupEventData levelupEvent = new LevelupEventData(upgradeableData.Level, upgradeableData.MaxLevel);
            _hometownContext.HouseView.HandleOnHouseLevelUp(levelupEvent);
        }

        public void HandleOnInputTouch()
        {
            //add implementation
            Upgrade();
        }

    }
}