using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BomberSquad.Managers
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance = null;
        public static LevelManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("LevelManager").AddComponent<LevelManager>();
                }
                return instance;
            }
        }
        private void OnEnable()
        {
            instance = this;
        } 

        [SerializeField] Slider _levelSlider;
        [SerializeField] TextMeshProUGUI baseText;
        [SerializeField] TextMeshProUGUI enemyText;
        [SerializeField] GameObject winPanel;

        int maxEnemyCount;
        int maxEnemyBase;
        [HideInInspector]
        public int currentBase;
        [HideInInspector]
        public int currentEnemyCount;
        // Start is called before the first frame update
        void Start()
        {
            foreach( GameObject x in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                maxEnemyCount++;
            }
            foreach (GameObject x in GameObject.FindGameObjectsWithTag("EnemyBase"))
            {
                maxEnemyBase++;
            }
            currentEnemyCount = 0;
            currentBase= 0;
            Debug.Log(maxEnemyCount);
            Debug.Log(maxEnemyBase);
            baseText.text = "Destroyed Base : " + currentBase + "/" + maxEnemyBase;
            enemyText.text = "Destroyed Enemies : " + currentEnemyCount + "/" + maxEnemyCount;
            winPanel.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if(currentBase == maxEnemyBase && currentEnemyCount == maxEnemyCount)
            {
                StartCoroutine(Win());
            }
            baseText.text = "Destroyed Base : " + currentBase + "/" + maxEnemyBase;
            enemyText.text = "Destroyed Enemies : " + currentEnemyCount + "/" + maxEnemyCount;
        }
        public void AddLevelValue(float x)
        {
            float temp = (float)((x * maxEnemyCount / maxEnemyCount) * (100/maxEnemyCount))/2;
            _levelSlider.value += temp;
            Debug.Log(temp);
            currentEnemyCount++;
        }
        public void AddLevelValue()
        {
            float temp = (( 1 * maxEnemyBase / maxEnemyBase) * (100 / maxEnemyBase)) / 2;
            _levelSlider.value += temp;
            Debug.Log(temp);
            currentBase++;
        }
        IEnumerator Win()
        {
            yield return new WaitForSeconds(1);
            winPanel.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            LoadNextScene();
        }
        public void LoadNextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}