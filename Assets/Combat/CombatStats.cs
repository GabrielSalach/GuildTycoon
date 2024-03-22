[System.Serializable]
public class CombatStats {
    public float health;
    public float armor;
    public float magicResist;
    public float attack;
    public float magicAttack;

    public CombatStats(float health, float armor, float magicResist, float attack, float magicAttack) {
        this.health = health;
        this.armor = armor;
        this.magicResist = magicResist;
        this.attack = attack;
        this.magicAttack = magicAttack;
    }

    /// <summary>
    /// Creates a new CombatStats instance and clones the values from this one.
    /// </summary>
    /// <returns>The cloned CombatStats instance</returns>
    public CombatStats CloneStats() {
        CombatStats returnValue = new(health,armor, magicResist,attack, magicAttack);
        return returnValue;
    }
    
    public static CombatStats operator +(CombatStats a, CombatStats b) {
        CombatStats newStats = new(a.health + b.health, a.armor + b.armor, a.magicResist + b.magicResist, a.attack + b.attack, a.magicAttack + b.magicAttack);
        return newStats;
    }

    public override string ToString() {
        return "Health : " + health + ", Armor : " + armor + ", Magic Resist : " + magicResist + ", Attack : " + attack +
               ", Magic Attack : " + magicAttack;
    }
}
