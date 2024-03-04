class Injury:
    def __init__(self, type, severity, affected_limb=None):
        self.type = type  # Type of injury (e.g., "laceration", "fracture", "burn")
        self.severity = severity  # Severity of injury (e.g., "mild", "moderate", "severe")
        self.affected_limb = affected_limb  # Limb affected by the injury (e.g., "arm", "leg", "hand", "foot")

    def get_description(self):
        # Generate a description of the injury based on type, severity, and affected limb
        if self.type == "laceration":
            return self.get_laceration_description()
        elif self.type == "fracture":
            return self.get_fracture_description()
        elif self.type == "burn":
            return self.get_burn_description()
        else:
            return "Unknown injury"

    def get_laceration_description(self):
        # Generate a description for a laceration injury
        if self.severity == "mild":
            return f"You have a shallow cut on your {self.affected_limb}."
        elif self.severity == "moderate":
            return f"You have a deep gash on your {self.affected_limb}."
        elif self.severity == "severe":
            return f"Your {self.affected_limb} is torn open from a deep laceration."
        else:
            return "Unknown laceration"

    def get_fracture_description(self):
        # Generate a description for a fracture injury
        if self.severity == "mild":
            return f"You have a hairline fracture in your {self.affected_limb}."
        elif self.severity == "moderate":
            return f"You have a broken bone in your {self.affected_limb}."
        elif self.severity == "severe":
            return f"Your {self.affected_limb} is shattered from a severe fracture."
        else:
            return "Unknown fracture"

    def get_burn_description(self):
        # Generate a description for a burn injury
        if self.severity == "mild":
            return f"You have a minor burn on your {self.affected_limb}."
        elif self.severity == "moderate":
            return f"You have second-degree burns on your {self.affected_limb}."
        elif self.severity == "severe":
            return "Your entire body is charred from severe burns."
        else:
            return "Unknown burn"
