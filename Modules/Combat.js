// Enums
const Tactic = {
    Default: 0,
    Custom: 1,
    Panic: 2,
    Defensive: 3,
    Aggressive: 4,
    Combo: 5,
};

// Class for Combat System
class CombatSystem {
    constructor() { }

    initiate(attacker, defender, tactic) {
        switch (tactic) {
            case Tactic.Custom:
                this.attack(attacker, defender);
                break;
            case Tactic.Panic:
                this.handlePanic(defender);
                break;
            case Tactic.Defensive:
                this.defensiveAttack(attacker, defender);
                break;
            case Tactic.Aggressive:
                this.aggressiveAttack(attacker, defender);
                break;
            case Tactic.Combo:
                this.comboAttack(attacker, defender);
                break;
            default:
                break;
        }
    }

    attack(attacker, defender) {
        console.log(`${attacker.name} attacks ${defender.name}.`);
        const baseDamage = Math.floor(Math.random() * (20 - 10 + 1)) + 10; // Random base damage between 10 and 20
        const totalDamage = baseDamage + attacker.damageBonus; // Add attacker's damage bonus
        defender.takeDamage(totalDamage);
        console.log(`${defender.name} takes ${totalDamage} damage. Current health: ${defender.health}`);

        // Additional logic for gaining experience upon successful attack
        attacker.gainExperience(20); // Example: Gain 20 experience points per successful attack
    }

    // Defensive tactic: Focus on blocking and counter-attacks
    defensiveAttack(attacker, defender) {
        console.log(`${attacker.name} takes a defensive stance.`);
        // Add logic here for defensive actions such as blocking or counter-attacks
    }

    // Aggressive tactic: Focus on overwhelming the opponent with relentless attacks
    aggressiveAttack(attacker, defender) {
        console.log(`${attacker.name} goes on the offensive!`);
        // Add logic here for aggressive attacks, possibly with increased damage but higher risk
    }

    // Combo tactic: Execute a series of coordinated attacks for increased damage
    comboAttack(attacker, defender) {
        console.log(`${attacker.name} unleashes a devastating combo!`);
        // Add logic here for executing combo attacks, possibly requiring specific conditions to trigger
    }

    handlePanic(combatant) {
        if (combatant.health < 35) {
            console.log(`${combatant.name} is panicking!`);
            combatant.conscious = false;
        }
    }
}

module.exports = CombatSystem;
