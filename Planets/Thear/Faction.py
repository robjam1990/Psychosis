class Faction:
    def __init__(self, name):
        self.name = name
        self.sub_factions = []

    def add_sub_faction(self, sub_faction):
        if sub_faction not in self.sub_factions:
            self.sub_factions.append(sub_faction)
        else:
            print(f"{sub_faction.name} already exists in {self.name}.")

    def remove_sub_faction(self, sub_faction):
        if sub_faction in self.sub_factions:
            self.sub_factions.remove(sub_faction)
        else:
            print(f"{sub_faction.name} does not exist in {self.name}.")


class FactionHierarchy:
    def __init__(self):
        self.thear = Faction("Thear")
        self.initialize_factions()

    def initialize_factions(self):
        bractalia = Faction("Bractalia")
        lochtou = Faction("Lochtou")
        kinderyarn = Faction("Kinderyarn")
        nymenada = Faction("Nymenada")
        wolk = Faction("Wolk")
        varthek = Faction("Varthek")
        jight = Faction("Jight")
        slake = Faction("Slake")
        thipse = Faction("Thipse")

        self.thear.sub_factions.extend([bractalia, lochtou, kinderyarn, nymenada, wolk, varthek, jight, slake, thipse])

    def create_faction_with_sub_factions(self, name, parent, sub_faction_names):
        faction = Faction(name)
        for sub_faction_name in sub_faction_names:
            sub_faction = Faction(sub_faction_name)
            if sub_faction not in faction.sub_factions:
                faction.add_sub_faction(sub_faction)
            else:
                print(f"{sub_faction.name} already exists in {faction.name}.")
        parent.add_sub_faction(faction)


# Example usage
faction_hierarchy = FactionHierarchy()
print("Faction hierarchy created successfully.")
