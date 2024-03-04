# Enums
from enum import Enum

class Aim(Enum):
    Dyslexic = 0
    Horrible = 1
    Poor = 2
    Fair = 3
    Good = 4
    Great = 5
    Excellent = 6
    Perfect = 7

class LimbStatus(Enum):
    Usable = 0
    Bruised = 1
    Dislocated = 2
    Fractured = 3
    Broken = 4
    Unusable = 5
    Removed = 6

# Class for Object Durability
class ObjectDurability:
    def __init__(self, max_durability):
        self.durability_points = max_durability
        self.max_durability = max_durability

    def degrade(self, amount):
        self.durability_points -= amount
        if self.durability_points < 0:
            self.durability_points = 0

# Class for Combatant
class Combatant:
    def __init__(self, name, health, weapon_durability):
        self.name = name
        self.health = health
        self.conscious = True
        self.attacker_aim = Aim.Good
        self.weapon_durability = ObjectDurability(weapon_durability)
        self.right_arm_status = LimbStatus.Usable
        self.left_arm_status = LimbStatus.Usable
        self.right_leg_status = LimbStatus.Usable
        self.left_leg_status = LimbStatus.Usable
        self.experience = 0
        self.level = 1
        self.damage_bonus = 0
        self.defense_bonus = 0

    def take_damage(self, damage):
        self.health -= damage
        if self.health <= 0:
            self.health = 0
            self.conscious = False

    def gain_experience(self, experience):
        self.experience += experience
        if self.experience >= 100:
            self.level_up()

    def level_up(self):
        self.level += 1
        self.experience = 0
        self.health += 10
        self.damage_bonus += 5
        self.defense_bonus += 3
        print(f"{self.name} has leveled up to level {self.level}!")

    # Method to simulate limb removal
    def remove_limb(self, limb):
        if limb == 'rightArm':
            self.right_arm_status = LimbStatus.Removed
        elif limb == 'leftArm':
            self.left_arm_status = LimbStatus.Removed
        elif limb == 'rightLeg':
            self.right_leg_status = LimbStatus.Removed
        elif limb == 'leftLeg':
            self.left_leg_status = LimbStatus.Removed

# Usage example:
# Create a combatant
player = Combatant("Player", 100, 50)

# Simulate taking damage
player.take_damage(20)
print(player.health)  # Output: 80

# Gain experience
player.gain_experience(50)
print(player.level)  # Output: 1 (since experience < 100)

player.gain_experience(60)
print(player.level)  # Output: 2 (since experience >= 100, level up occurred)
