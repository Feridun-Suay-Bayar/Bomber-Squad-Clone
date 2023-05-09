using BomberSquad.Stats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BomberSquad.Managers
{
    public class UIManager : MonoBehaviour
    {

        private static UIManager instance = null;
        public static UIManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("UIManager").AddComponent<UIManager>();
                }
                return instance;
            }
        }
        private void OnEnable()
        {
            instance = this;
        }

        [SerializeField] TextMeshProUGUI _capacityText;
        [SerializeField] TextMeshProUGUI _armorText;
        [SerializeField] TextMeshProUGUI _damageText;
        [SerializeField] TextMeshProUGUI _coinText;

        PlayerStats _playerStats;

        int _cost = 100;
        private void Start()
        {
            _playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        }
        private void Update()
        {
            _capacityText.text = "" + _playerStats.Capacity;
            _armorText.text = ""+ _playerStats.Armor;
            _damageText.text = "" + _playerStats.Damage;
            _coinText.text = "" + _playerStats.coin;
        }
        public void UpgradeCapacity()
        {
            if (_playerStats.coin >= _cost && _playerStats.CapacityCount<3)
            {
                _playerStats.UpdateCapacity();
                _playerStats.coin -= _cost;
                PlayerPrefsManager.Instance.coin = _playerStats.coin;
                PlayerPrefs.SetInt(PlayerPrefsManager.Instance.coinString, PlayerPrefsManager.Instance.coin);
            }
        }
        public void UpdateArmor() 
        {
            if (_playerStats.coin >= _cost && _playerStats.ArmorCount<2)
            {
                _playerStats.UpdateArmor();
                _playerStats.coin -= _cost;
                PlayerPrefsManager.Instance.coin = _playerStats.coin;
                PlayerPrefs.SetInt(PlayerPrefsManager.Instance.coinString, PlayerPrefsManager.Instance.coin);
            }
        }
        public void UpdateDamage()
        {
            if (_playerStats.coin >= _cost && _playerStats.DamageCount <3)
            {
                _playerStats.UpdateDamage();
                _playerStats.coin -= _cost;
                PlayerPrefsManager.Instance.coin = _playerStats.coin;
                PlayerPrefs.SetInt(PlayerPrefsManager.Instance.coinString, PlayerPrefsManager.Instance.coin);
            }
            
        }

    }
}