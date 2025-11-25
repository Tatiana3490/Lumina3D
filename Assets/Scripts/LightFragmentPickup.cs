using UnityEngine;

public class LightFragmentPickup : MonoBehaviour
{
    public float energyAmount = 25f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Fragment tocado por: " + other.name);

        EnergySystem energy = other.GetComponent<EnergySystem>();
        if (energy != null)
        {
            Debug.Log("EnergySystem encontrado, añadiendo energia: " + energyAmount);
            energy.AddEnergy(energyAmount);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("No se encontro EnergySystem en " + other.name);
        }
    }
}
