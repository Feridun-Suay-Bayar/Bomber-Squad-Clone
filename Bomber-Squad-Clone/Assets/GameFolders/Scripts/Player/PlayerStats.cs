using BomberSquad.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.Stats
{
    public class PlayerStats : MonoBehaviour
    {
        int _capacity;
        int _armor;
        int _damage;

        int _capacityCount;
        int _armorCount;
        int _damageCount;

        PlayerView _playerView;

        public int ammo;
        public int coin;
        public int Capacity => _capacity;
        public int Armor => _armor;
        public int Damage => _damage;

        public int CapacityCount => _capacityCount;
        public int ArmorCount => _armorCount;
        public int DamageCount => _damageCount;
        private void Start()
        {
            _capacity = PlayerPrefsManager.Instance.capacity;
            _armor = PlayerPrefsManager.Instance.armor;
            _damage = PlayerPrefsManager.Instance.damage;

            _capacityCount = PlayerPrefsManager.Instance.capacityCount;
            _armorCount = PlayerPrefsManager.Instance.armorCount;
            _damageCount = PlayerPrefsManager.Instance.damageCount;

            coin = PlayerPrefsManager.Instance.coin;

            _playerView = GetComponent<PlayerView>();
            SetAmmo();
        }
        public void UpdateCapacity()
        {
            _capacity += 2;
            ammo = _capacity;
            _capacityCount++;
            _playerView.ChangeCapacity(_capacityCount);
            PlayerPrefsManager.Instance.capacity = _capacity;
            PlayerPrefsManager.Instance.capacityCount= _capacityCount;
            PlayerPrefs.SetInt(PlayerPrefsManager.Instance.capacityString,PlayerPrefsManager.Instance.capacity);
            PlayerPrefs.SetInt(PlayerPrefsManager.Instance.capacityCountString, PlayerPrefsManager.Instance.capacityCount);
            
        }
        public void UpdateArmor()
        {
            _armor += 20;
            _armorCount++;
            _playerView.ChangePlane(_armorCount);
            PlayerPrefsManager.Instance.armor= _armor;
            PlayerPrefsManager.Instance.armorCount= _armorCount;
            PlayerPrefs.SetInt(PlayerPrefsManager.Instance.armorString, PlayerPrefsManager.Instance.armor);
            PlayerPrefs.SetInt(PlayerPrefsManager.Instance.armorCountString, PlayerPrefsManager.Instance.armorCount);
        }
        public void UpdateDamage()
        {
            _damage += 10;
            _damageCount++;
            _playerView.ChangeGunner(_damageCount);
            PlayerPrefsManager.Instance.damage= _damage;
            PlayerPrefsManager.Instance.damageCount= _damageCount;
            PlayerPrefs.SetInt(PlayerPrefsManager.Instance.damageString, PlayerPrefsManager.Instance.damage);
            PlayerPrefs.SetInt(PlayerPrefsManager.Instance.damageCountString, PlayerPrefsManager.Instance.damageCount);
        }
        public void AddCoin()
        {
            coin += 1;
            PlayerPrefsManager.Instance.coin= coin;
            PlayerPrefs.SetInt(PlayerPrefsManager.Instance.coinString, PlayerPrefsManager.Instance.coin);
        }
        public void SetAmmo()
        {
            ammo = _capacity;
        }
    }
}