using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectState { FULL, ALIVE, DEAD }

public abstract class ObjectData : MonoBehaviour
{
    private int currentHP;

    private int maxHP;

    private ObjectState objectState;

    public int CurrentHP { get => currentHP; }

    public int MaxHP { get => maxHP; }

    protected void StartHP(int maxHP)
    {
        this.currentHP = this.maxHP = maxHP;
        this.objectState = ObjectState.FULL;
    }

    protected void TakeDamage(int damage)
    {
        if (damage >= 0)
        {
            this.currentHP = Mathf.Max(this.currentHP - damage, 0);

            if (this.currentHP <= 0)
            {
                this.objectState = ObjectState.DEAD;
                this.Die();
            }
            else if (this.currentHP < this.maxHP)
            {
                this.objectState = ObjectState.ALIVE;
            }
        }
        else
        {
            Debug.Log("Invalid damage value!");
        }
    }

    public void TakeDamage(int damage, Element.EnumElement element)
    {
        TakeDamage(damage);
    }

    public bool IsDead() { return this.objectState == ObjectState.DEAD; }

    public bool IsAlive() { return !this.IsDead(); }

    public abstract void Die();
}
