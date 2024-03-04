from enum import Enum
import random

# Enums
class Tactic(Enum):
    Default = 0
    Custom = 1
    Panic = 2
    Defensive = 3
    Aggressive = 4
    Combo = 5

# Class for Combat System
class CombatSystem:
    def __init__(self):
        pass

    def initiate(self, attacker, defender, tactic):
        if tactic == Tactic.Custom:
            self.attack(attacker, defender)
        elif tactic == Tactic.Panic:
            self.handle_panic(defender)
        elif tactic == Tactic.Defensive:
            self.defensive_attack(attacker, defender)
        elif tactic == Tactic.Aggressive:
            self.aggressive_attack(attacker, defender)
        elif tactic == Tactic.Combo:
            self.combo_attack(attacker, defender)

    def attack(self, attacker, defender):
        print(f"{attacker.name} attacks {defender.name}.")
        base_damage = random.randint(10, 20)  # Random base damage between 10 and 20
        total_damage = base_damage + attacker.damage_bonus  # Add attacker's damage bonus
        defender.take_damage(total_damage)
        print(f"{defender.name} takes {total_damage} damage. Current health: {defender.health}")

        # Additional logic for gaining experience upon successful attack
        attacker.gain_experience(20)  # Example: Gain 20 experience points per successful attack

    # Defensive tactic: Focus on blocking and counter-attacks
    def defensive_attack(self, attacker, defender):
        print(f"{attacker.name} takes a defensive stance.")
        # Add logic here for defensive actions such as blocking or counter-attacks

    # Aggressive tactic: Focus on overwhelming the opponent with relentless attacks
    def aggressive_attack(self, attacker, defender):
        print(f"{attacker.name} goes on the offensive!")
        # Add logic here for aggressive attacks, possibly with increased damage but higher risk

    # Combo tactic: Execute a series of coordinated attacks for increased damage
    def combo_attack(self, attacker, defender):
        print(f"{attacker.name} unleashes a devastating combo!")
        # Add logic here for executing combo attacks, possibly requiring specific conditions to trigger

    def handle_panic(self, combatant):
        if combatant.health < 35:
            print(f"{combatant.name} is panicking!")
            combatant.conscious = False

# Example usage:
# combat_system = CombatSystem()
# tactic = Tactic.Custom
# attacker = ...
# defender = ...
# combat_system.initiate(attacker, defender, tactic)
