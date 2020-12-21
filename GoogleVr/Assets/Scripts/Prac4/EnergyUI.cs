using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    protected float maxEnergy, currentEnergy;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void InitializeEnergy(float energy)
    {
        maxEnergy = energy;
        currentEnergy = energy;
    }

    public void SetEnergy(float newEnergy)
    {
        currentEnergy = newEnergy;
        float energyRatio = currentEnergy / maxEnergy;
        image.fillAmount = energyRatio;
    }
}
