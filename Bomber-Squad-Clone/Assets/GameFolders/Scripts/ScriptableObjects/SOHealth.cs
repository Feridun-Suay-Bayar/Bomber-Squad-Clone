using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.SO
{
    [CreateAssetMenu(fileName = "Datas", menuName = "ScriptableObjects/HeathSystem", order = 50)]
    public class SOHealth : ScriptableObject
    {
        public float maxHealth; 
    }
}