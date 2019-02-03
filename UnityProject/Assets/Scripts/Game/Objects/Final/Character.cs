using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class Character : DestroyableObject
{
    [SerializeField]
    private BaseStatus status;
    
    void Start()
    {
        this.StartHP(this.status.HealthPoints);
    }
    
    void Update()
    {
        
    }

    public new void TakeDamage(int damage)
    {
        TakeDamage((int) Mathf.Max(this.status.PhysicalDefense - damage, 1));
    }

    public void TakeDamage(int damage, Element element)
    {
        if (element == Element.NEUTRAL)
        {
            // Physical damage
            TakeDamage((int)Mathf.Max(damage - this.status.PhysicalDefense, 1));
        }
        else
        {
            TakeDamage((int)Mathf.Max(damage * CalculateMultiply(element) - this.status.ElementalDefense, 1));
        }
    }

    protected float CalculateMultiply(Element element)
    {
        if (this.status.Element == Element.NEUTRAL || element == Element.NEUTRAL || this.status.Element == element)
        {
            return 1.0f;
        }
        else if (this.status.Element == Element.FIRE && element == Element.ICE ||
                this.status.Element == Element.EARTH && element == Element.FIRE ||
                this.status.Element == Element.ICE && element == Element.EARTH)
        {
            return 1.2f;
        }
        return 0.8f;
    }

    public override void Die()
    {
        // Morrer
        Destroy(this.gameObject);
    }
}
