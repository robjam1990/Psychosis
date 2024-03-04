# file = robjam1990/psychosis/gameplay/management/formations.py

class Formation:
    def __init__(self, name, description, members=[]):
        self.name = name
        self.description = description
        self.members = members

    def add_member(self, character):
        if character not in self.members:
            self.members.append(character)
            print(f"{character} added to {self.name}.")

    def remove_member(self, character):
        if character in self.members:
            self.members.remove(character)
            print(f"{character} removed from {self.name}.")

    def display_members(self):
        print(f"Members of {self.name}:")
        for member in self.members:
            print(f"- {member}")

    def move_member(self, character, destination):
        if character in self.members:
            print(f"{character} moved to {destination} in formation {self.name}.")
            # Add logic to move character to specified position in formation

    def rotate_formation(self, direction):
        print(f"Formation {self.name} rotated {direction}.")
        # Add logic to rotate the formation clockwise or counterclockwise

    def disband(self):
        print(f"Formation {self.name} disbanded.")
        self.members = []

    def get_leader(self):
        # Add logic to retrieve the leader of the formation
        pass

    def set_leader(self, character):
        # Add logic to set a new leader for the formation
        pass

    def get_member_count(self):
        return len(self.members)

    def is_full(self):
        # Add logic to check if the formation is full
        pass

    def is_empty(self):
        return len(self.members) == 0
