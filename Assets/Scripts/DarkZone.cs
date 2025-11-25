using UnityEngine;

public class DarkZone : MonoBehaviour
{
    // Energía que quita por segundo mientras estás dentro
    public float drainPerSecond = 25f;

    private void OnTriggerStay(Collider other)
    {
        EnergySystem energy = other.GetComponent<EnergySystem>();
        if (energy != null)
        {
            energy.RemoveEnergy(drainPerSecond * Time.deltaTime);
        }
    }
}
