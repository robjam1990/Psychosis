# File: robjam1990/Psychosis/Gameplay/System/Disease.py

class Symptom:
    """
    Define the Symptom class to handle symptoms of diseases.
    """

    def __init__(self, name, severity, duration):
        """
        Creates a new Symptom instance.
        :param name: The name of the symptom.
        :param severity: The severity level of the symptom.
        :param duration: The duration of the symptom.
        """
        self.name = name
        self.severity = severity
        self.duration = duration


class Disease:
    """
    Define the Disease class to handle diseases in the game.
    """

    def __init__(self, name, symptoms, transmission_rate, cure_rate, base_duration):
        """
        Creates a new Disease instance.
        :param name: The name of the disease.
        :param symptoms: List of Symptom objects associated with the disease.
        :param transmission_rate: Rate of transmission of the disease.
        :param cure_rate: Rate at which the disease can be cured.
        :param base_duration: Base duration of the disease if untreated.
        """
        self.name = name
        self.symptoms = symptoms
        self.transmission_rate = transmission_rate
        self.cure_rate = cure_rate
        self.base_duration = base_duration
        self.infected_characters = []

    def spread(self, character):
        """
        Spread the disease to a character.
        :param character: The character to spread the disease to.
        """
        import random

        if random.random() < self.transmission_rate:
            self.infected_characters.append(character)
            print(f"{self.name} has spread to {character.name}")

    def progress(self):
        """
        Progress the disease in all infected characters.
        """
        for character in self.infected_characters:
            character.progress_disease(self)
            print(f"{self.name} is progressing in {character.name}")

    def cure(self, character):
        """
        Cure the disease in a character.
        :param character: The character to cure the disease in.
        """
        import random

        if random.random() < self.cure_rate:
            if character in self.infected_characters:
                self.infected_characters.remove(character)
                print(f"{character.name} has been cured of {self.name}")


class Character:
    """
    Define the Character class to represent characters in the game.
    """

    def __init__(self, name, immunity):
        """
        Creates a new Character instance.
        :param name: The name of the character.
        :param immunity: The immunity level of the character.
        """
        self.name = name
        self.immunity = immunity
        self.diseases = []

    def contract_disease(self, disease):
        """
        Contract a disease.
        :param disease: The disease to contract.
        """
        if self.immunity.get(disease.name):
            print(f"{self.name} is immune to {disease.name}")
            return

        if disease in self.diseases:
            print(f"{self.name} is already infected with {disease.name}")
            return

        self.diseases.append(disease)
        print(f"{self.name} has contracted {disease.name}")

    def progress_disease(self, disease):
        """
        Progress a disease in the character.
        :param disease: The disease to progress.
        """
        for symptom in disease.symptoms:
            print(f"{self.name} experiences {symptom.name}")

    def recover_from_disease(self, disease):
        """
        Recover from a disease.
        :param disease: The disease to recover from.
        """
        if disease in self.diseases:
            self.diseases.remove(disease)
            print(f"{self.name} has recovered from {disease.name}")


# Export the Disease class for external use
if __name__ == "__main__":
    import sys
    sys.path.append('..')  # Include parent directory in the search path
    from Symptom import Symptom  # Importing Symptom class from the parent directory

    __all__ = ["Disease", "Character", "Symptom"]
