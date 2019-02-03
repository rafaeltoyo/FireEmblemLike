using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Element
{
    public enum EnumElement {
        NEUTRAL,
        FIRE,
        ICE,
        EARTH
    }

    public static readonly Dictionary<EnumElement, Dictionary<EnumElement, float>> table = new Dictionary<EnumElement, Dictionary<EnumElement, float>>
    {
        {EnumElement.NEUTRAL, new Dictionary<EnumElement, float>{
            {EnumElement.NEUTRAL, 1.0f},
            {EnumElement.FIRE, 1.0f},
            {EnumElement.ICE, 1.0f},
            {EnumElement.EARTH, 1.0f}
        }},
        {EnumElement.FIRE, new Dictionary<EnumElement, float>{
            {EnumElement.NEUTRAL, 1.0f},
            {EnumElement.FIRE, 1.0f},
            {EnumElement.ICE, 1.2f},
            {EnumElement.EARTH, 0.8f}
        }},
        {EnumElement.ICE, new Dictionary<EnumElement, float>{
            {EnumElement.NEUTRAL, 1.0f},
            {EnumElement.FIRE, 0.8f},
            {EnumElement.ICE, 1.0f},
            {EnumElement.EARTH, 1.2f}
        }},
        {EnumElement.EARTH, new Dictionary<EnumElement, float>{
            {EnumElement.NEUTRAL, 1.0f},
            {EnumElement.FIRE, 1.2f},
            {EnumElement.ICE, 0.8f},
            {EnumElement.EARTH, 1.0f}
        }}
    };

    public static float Multiply(EnumElement attacker, EnumElement target)
    {
        return table[attacker][target];
    }

    public static bool IsPhysical(EnumElement element)
    {
        return element == EnumElement.NEUTRAL;
    }

    public static bool IsElemental(EnumElement element)
    {
        return element != EnumElement.NEUTRAL;
    }
}
