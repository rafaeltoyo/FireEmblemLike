using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class CharacterData : ObjectData
{
    [SerializeField]
    private string nickname;

    [SerializeField]
    private BaseStatus status;

    public string Nickname { get => nickname; }
    public BaseStatus Status { get => status; }

    void Start()
    {
        StartHP(Status.HealthPoints);
    }
    
    void Update()
    {
        
    }

    public new void TakeDamage(int damage, Element.EnumElement element)
    {
        int defense = Element.IsPhysical(element) ? Status.PhysicalDefense : Status.ElementalDefense;
        damage = (int) Mathf.Max(damage * Element.Multiply(element, Status.Element) - defense, 0);
        TakeDamage(damage);
    }

    public override void Die()
    {
        // Morrer
        Destroy(gameObject);
    }
}
