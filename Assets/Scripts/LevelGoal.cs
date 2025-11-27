using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    // Panel de victoria que mostraremos al llegar al portal
    public GameObject winPanel;

    private bool levelFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        // Usamos EnergySystem para saber que es el jugador
        EnergySystem energy = other.GetComponent<EnergySystem>();
        if (energy == null || levelFinished)
        {
            return;
        }

        levelFinished = true;
        Debug.Log("Nivel completado!");

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        // Pausar el tiempo del juego
        Time.timeScale = 0f;
    }
}
