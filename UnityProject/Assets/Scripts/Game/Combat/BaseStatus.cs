using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private Element.EnumElement element;

    public int HealthPoints { get => healthPoints; set => healthPoints = value; }
    public int PhysicalPower { get => physicalPower; set => physicalPower = value; }
    public int ElementalPower { get => elementalPower; set => elementalPower = value; }
    public int PhysicalDefense { get => physicalDefense; set => physicalDefense = value; }
    public int ElementalDefense { get => elementalDefense; set => elementalDefense = value; }
    public int Weight { get => weight; set => weight = value; }
    public Element.EnumElement Element { get => element; set => element = value; }
}
