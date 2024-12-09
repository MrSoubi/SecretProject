using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceGame : MonoBehaviour
{
    [Header("ScriptableObject")]
    [SerializeField] private PlayerStats playerStats;

    [Header("References")]
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private TextMeshProUGUI textHealth;
    [SerializeField] private GameObject panelGameOver;

    private void Start()
    {
        sliderHealth.maxValue = playerStats.Health;
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
