using BomberSquad.Stats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace BomberSquad.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance = null;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("GameManager").AddComponent<GameManager>();
                }
                return instance;
            }
        }
        private void OnEnable()
        {
            instance = this;
        }
        [SerializeField] Camera _startCamera;
        PlayerStats _playerStats;
        public bool isGameStart;
        [SerializeField] GameObject startPanel;
        [SerializeField] Transform startPoint;
        GameObject _player;
        // Start is called before the first frame update
        void Start()
        {
            _player = GameObject.FindWithTag("Player");
            _playerStats = _player.GetComponent<PlayerStats>();
            startPoint.transform.position = new Vector3(startPoint.transform.position.x, 1, startPoint.transform.position.z);
            _player.transform.position = startPoint.transform.position;
            _player.transform.rotation = startPoint.transform.rotation;
            _startCamera.gameObject.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            if (!isGameStart)
            {
                startPanel.SetActive(true);
                _startCamera.gameObject.SetActive(true);
            }
            if (isGameStart)
            {
                _startCamera.gameObject.SetActive(false);
            }
        }
        public void GameStart()
        {
            isGameStart= true;
            startPanel.SetActive(false);
            _playerStats.SetAmmo();
        }
    }
}