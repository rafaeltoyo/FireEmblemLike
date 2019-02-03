using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element { NEUTRAL, FIRE, ICE, EARTH }

[System.Serializable]
public class BaseStatus
{
    [SerializeField]
    private int healthPoints;
    [SerializeField]
    private int physicalPower;
    [SerializeField]
    private int elementalPower;
    [SerializeField]
    private int physicalDefense;
    [SerializeField]
    private int elementalDefense;
    [SerializeField]
    private int weight;
    [SerializeField]
    private Element element;

    public int HealthPoints { get => healthPoints; set => healthPoints = value; }
    public int PhysicalPower { get => physicalPower; set => physicalPower = value; }
    public int ElementalPower { get => elementalPower; set => elementalPower = value; }
    public int PhysicalDefense { get => physicalDefense; set => physicalDefense = value; }
    public int ElementalDefense { get => elementalDefense; set => elementalDefense = value; }
    public int Weight { get => weight; set => weight = value; }
    internal Element Element { get => element; set => element = value; }
}
