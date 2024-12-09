using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
public class InterfaceGame : MonoBehaviour
{
    [Header("ScriptableObject")]
    [SerializeField] private PlayerStats playerStats;

    [Header("References")]
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private TextMeshProUGUI textHealth;
    [SerializeField] private GameObject panelGameOver;

    [SerializeField] private GameObject _gameLife;
    [SerializeField] private Transform _gameLifePosition;

    [SerializeField] private Transform _lifes;

    private List<GameObject> gameLifeList = new List<GameObject>();
    private void Start()
    {
        sliderHealth.maxValue = playerStats.Health;
        for(int i = 0; i < playerStats.Health; i++){
            var gameObject = Instantiate(_gameLife, _gameLifePosition.position, Quaternion.identity, _lifes);

            gameObject.transform.position = new Vector3(_gameLifePosition.position.x + i*-150, _gameLifePosition.position.y, _gameLifePosition.position.z);
            gameLifeList.Add(gameObject);
        }
        sliderHealth.value = playerStats.Health;
        textHealth.text = playerStats.Health.ToString();
    }

    private void OnEnable()
    {
        playerStats.OnLooseHealth += UpdateUI;
        playerStats.OnDeath += Restart;
    }

    private void OnDisable()
    {
        playerStats.OnLooseHealth -= UpdateUI;
        playerStats.OnDeath -= Restart;
    }

    /// <summary>
    /// Update the UI
    /// </summary>
    private void UpdateUI()
    {
        sliderHealth.value = playerStats.Health;
        textHealth.text = playerStats.Health.ToString();
        Destroy(gameLifeList[gameLifeList.Count-1]);
        gameLifeList.Remove(gameLifeList[gameLifeList.Count-1]);
        
    }

    /// <summary>
    /// Player Death
    /// </summary>
    private void GameOver()
    {
        panelGameOver.SetActive(true);
    }

    /// <summary>
    /// Restart Level
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Quit Game
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
