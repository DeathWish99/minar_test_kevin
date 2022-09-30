using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Project.Hometown
{
    public class HouseView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text levelText;
        [SerializeField]
        private GameObject house;
        private HouseController _houseController;

        private void OnDisable()
        {
            //add implementation
        }

        private void OnEnable()
        {
            //add implementation
        }
        private void Update()
        {
            if(_houseController.upgradeableData == null)
            {
                levelText.text = "Loading...";
            }
            else
            {
                levelText.text = _houseController.upgradeableData.Level + "/" + _houseController.upgradeableData.MaxLevel;
            }
        }
        public HouseView Setup(HouseController houseController)
        {
            _houseController= houseController;
            return this;
        }

        public void EnableScript()
        {
            //remember to enable script from context if needed
            enabled = true;
        }

        public void HandleOnHouseLevelUp(LevelupEventData data)
        {
            //add implementation
            Vector3 newScale = new Vector3(data.Level / 2f, data.Level / 2f, data.Level / 2f);
            house.transform.localScale = newScale;
        }
    }
}