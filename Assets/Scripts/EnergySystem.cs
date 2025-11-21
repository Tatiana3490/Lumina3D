using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnergySystem : MonoBehaviour
{
    public float maxEnergy = 100f;
    public float drainPerSecond = 5f;
    public Slider energyBar;

    public float CurrentEnergy { get; private set; }

    void Start()
    {
        CurrentEnergy = maxEnergy;
        UpdateUI();
    }

    void Update()
    {
        CurrentEnergy -= drainPerSecond * Time.deltaTime;
        if (CurrentEnergy < 0) CurrentEnergy = 0;

        UpdateUI();

        if (CurrentEnergy <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddEnergy(float amount)
    {
        CurrentEnergy = Mathf.Min(maxEnergy, CurrentEnergy + amount);
        UpdateUI();
    }

    public void RemoveEnergy(float amount)
    {
        CurrentEnergy = Mathf.Max(0, CurrentEnergy - amount);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (energyBar) energyBar.value = CurrentEnergy;
    }
}
