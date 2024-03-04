// File = robjam1990/Psychosis/Gameplay/Characters/Injury.js
class Injury {
    constructor(type, severity, affectedLimb = null) {
        this.type = type; // Type of injury (e.g., "laceration", "fracture", "burn")
        this.severity = severity; // Severity of injury (e.g., "mild", "moderate", "severe")
        this.affectedLimb = affectedLimb; // Limb affected by the injury (e.g., "arm", "leg", "hand", "foot")
    }

    getDescription() {
        // Generate a description of the injury based on type, severity, and affected limb
        switch (this.type) {
            case "laceration":
                return this.getLacerationDescription();
            case "fracture":
                return this.getFractureDescription();
            case "burn":
                return this.getBurnDescription();
            default:
                return "Unknown injury";
        }
    }

    getLacerationDescription() {
        // Generate a description for a laceration injury
        switch (this.severity) {
            case "mild":
                return `You have a shallow cut on your ${this.affectedLimb}.`;
            case "moderate":
                return `You have a deep gash on your ${this.affectedLimb}.`;
            case "severe":
                return `Your ${this.affectedLimb} is torn open from a deep laceration.`;
            default:
                return "Unknown laceration";
        }
    }

    getFractureDescription() {
        // Generate a description for a fracture injury
        switch (this.severity) {
            case "mild":
                return `You have a hairline fracture in your ${this.affectedLimb}.`;
            case "moderate":
                return `You have a broken bone in your ${this.affectedLimb}.`;
            case "severe":
                return `Your ${this.affectedLimb} is shattered from a severe fracture.`;
            default:
                return "Unknown fracture";
        }
    }

    getBurnDescription() {
        // Generate a description for a burn injury
        switch (this.severity) {
            case "mild":
                return `You have a minor burn on your ${this.affectedLimb}.`;
            case "moderate":
                return `You have second-degree burns on your ${this.affectedLimb}.`;
            case "severe":
                return `Your entire body is charred from severe burns.`;
            default:
                return "Unknown burn";
        }
    }
}

// Export the Injury class for use in other modules
module.exports = Injury;
