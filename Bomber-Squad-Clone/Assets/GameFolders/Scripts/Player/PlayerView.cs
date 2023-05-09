using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberSquad.UI
{
    public class PlayerView : MonoBehaviour
    {
        int i = 0;

        [SerializeField] GameObject[] guns1 = new GameObject[4];
        [SerializeField] GameObject[] guns2 = new GameObject[4];
        [SerializeField] GameObject[] guns3 = new GameObject[4];
        [SerializeField] GameObject[] planes= new GameObject[3];

        private void Start()
        {
            ChangeGunner(PlayerPrefsManager.Instance.damageCount);
            ChangeCapacity(PlayerPrefsManager.Instance.capacityCount);
            ChangePlane(PlayerPrefsManager.Instance.armorCount);
        }
        public void ChangeGunner(int i)
        {
            for(int j=0; j< guns1.Length; j++)
            {
                guns1[j].transform.gameObject.SetActive(false);
            }
            for (int j = 0; j < guns2.Length; j++)
            {
                guns2[j].transform.gameObject.SetActive(false);
            }
            guns1[i].transform.gameObject.SetActive(true);
            guns2[i].transform.gameObject.SetActive(true);
        }
        public void ChangePlane(int i)
        {
            for(int j=0; j < planes.Length; j++)
            {
                planes[j].transform.gameObject.SetActive(false);
            }
            if (i < planes.Length)
            {
                planes[i].transform.gameObject.SetActive(true);
            }
        }
        public void ChangeCapacity(int i)
        {
            for (int j = 0; j < guns3.Length; j++)
            {
                guns3[j].transform.gameObject.SetActive(false);
            }
            guns3[i].transform.gameObject.SetActive(true);
        }
    }
}