//File = robjam1990/Psychosis/Gameplay/System/Genetics.js

// A method to bio-engineer DNA and RNA as well as GNA(Genetic Neural Algorithm).
class Genetics {
    constructor() {
        // Initialize genetic engineering parameters
        this.DNA = [];
        this.RNA = [];
        this.GNA = [];
    }

    // Method to bio-engineer DNA, RNA, and GNA
    bioEngineer(newDNA, newRNA, newGNA) {
        this.DNA.push(newDNA);
        this.RNA.push(newRNA);
        this.GNA.push(newGNA);
        console.log(`DNA successfully engineered: ${newDNA}`);
        console.log(`RNA successfully engineered: ${newRNA}`);
        console.log(`GNA successfully engineered: ${newGNA}`);
    }

    // Method to analyze genetic composition
    analyzeGenetics() {
        console.log("Analyzing genetic composition...");
        console.log(`DNA: ${this.DNA}`);
        console.log(`RNA: ${this.RNA}`);
        console.log(`GNA: ${this.GNA}`);
    }

    // Method to modify existing genetic traits
    modifyGenetics(index, newDNA, newRNA, newGNA) {
        if (index >= 0 && index < this.DNA.length) {
            this.DNA[index] = newDNA;
            this.RNA[index] = newRNA;
            this.GNA[index] = newGNA;
            console.log(`Genetic traits at index ${index} successfully modified.`);
        } else {
            console.log("Invalid index. Unable to modify genetic traits.");
        }
    }

    // Method to remove genetic traits
    removeGenetics(index) {
        if (index >= 0 && index < this.DNA.length) {
            this.DNA.splice(index, 1);
            this.RNA.splice(index, 1);
            this.GNA.splice(index, 1);
            console.log(`Genetic traits at index ${index} successfully removed.`);
        } else {
            console.log("Invalid index. Unable to remove genetic traits.");
        }
    }
}

// Example usage:
const geneticsSystem = new Genetics();
geneticsSystem.bioEngineer("AGCT", "AGCU", "AGCN");
geneticsSystem.analyzeGenetics();
geneticsSystem.modifyGenetics(0, "TGCA", "UGCA", "CGAN");
geneticsSystem.removeGenetics(1);
geneticsSystem.analyzeGenetics();
