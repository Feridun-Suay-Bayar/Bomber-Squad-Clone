using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.SO
{
    [CreateAssetMenu(fileName = "Datas", menuName = "ScriptableObjects/PlayerStats", order = 50)]
    public class SOPlayerStats : ScriptableObject
    {
        public int _capacity;
        public int _armor;
        public int _damage;
        public int _coin;
    }
}