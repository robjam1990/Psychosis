// Enums
const Aim = {
    Dyslexic: 0,
    Horrible: 1,
    Poor: 2,
    Fair: 3,
    Good: 4,
    Great: 5,
    Excellent: 6,
    Perfect: 7
};

const LimbStatus = {
    Usable: 0,
    Bruised: 1,
    Dislocated: 2,
    Fractured: 3,
    Broken: 4,
    Unusable: 5,
    Removed: 6
};

// Class for Object Durability
class ObjectDurability {
    constructor(maxDurability) {
        this.durabilityPoints = maxDurability;
        this.maxDurability = maxDurability;
    }

    degrade(amount) {
        this.durabilityPoints -= amount;
        if (this.durabilityPoints < 0) {
            this.durabilityPoints = 0;
        }
    }
}

// Class for Combatant
class Combatant {
    constructor(name, health, weaponDurability) {
        this.name = name;
        this.health = health;
        this.conscious = true;
        this.attackerAim = Aim.Good;
        this.weaponDurability = new ObjectDurability(weaponDurability);
        this.rightArmStatus = LimbStatus.Usable;
        this.leftArmStatus = LimbStatus.Usable;
        this.rightLegStatus = LimbStatus.Usable;
        this.leftLegStatus = LimbStatus.Usable;
        this.experience = 0;
        this.level = 1;
        this.damageBonus = 0;
        this.defenseBonus = 0;
    }

    takeDamage(damage) {
        this.health -= damage;
        if (this.health <= 0) {
            this.health = 0;
            this.conscious = false;
        }
    }

    gainExperience(experience) {
        this.experience += experience;
        if (this.experience >= 100) {
            this.levelUp();
        }
    }

    levelUp() {
        this.level++;
        this.experience = 0;
        this.health += 10;
        this.damageBonus += 5;
        this.defenseBonus += 3;
        console.log(`${this.name} has leveled up to level ${this.level}!`);
    }

    // Method to simulate limb removal
    removeLimb(limb) {
        switch (limb) {
            case 'rightArm':
                this.rightArmStatus = LimbStatus.Removed;
                break;
            case 'leftArm':
                this.leftArmStatus = LimbStatus.Removed;
                break;
            case 'rightLeg':
                this.rightLegStatus = LimbStatus.Removed;
                break;
            case 'leftLeg':
                this.leftLegStatus = LimbStatus.Removed;
                break;
            default:
                break;
        }
    }
}

module.exports = Combatant;
