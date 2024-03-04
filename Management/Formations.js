// File: robjam1990/psychosis/gameplay/management/formations.js

class Formation {
    constructor(name, description, members = []) {
        this.name = name;
        this.description = description;
        this.members = members;
    }

    addMember(character) {
        if (!this.members.includes(character)) {
            this.members.push(character);
            console.log(`${character} added to ${this.name}.`);
        }
    }

    removeMember(character) {
        const index = this.members.indexOf(character);
        if (index !== -1) {
            this.members.splice(index, 1);
            console.log(`${character} removed from ${this.name}.`);
        }
    }

    displayMembers() {
        console.log(`Members of ${this.name}:`);
        this.members.forEach(member => {
            console.log(`- ${member}`);
        });
    }

    moveMember(character, destination) {
        if (this.members.includes(character)) {
            console.log(`${character} moved to ${destination} in formation ${this.name}.`);
            // Add logic to move character to specified position in formation
        }
    }

    rotateFormation(direction) {
        console.log(`Formation ${this.name} rotated ${direction}.`);
        // Add logic to rotate the formation clockwise or counterclockwise
    }

    disband() {
        console.log(`Formation ${this.name} disbanded.`);
        this.members = [];
    }

    getLeader() {
        // Add logic to retrieve the leader of the formation
    }

    setLeader(character) {
        // Add logic to set a new leader for the formation
    }

    getMemberCount() {
        return this.members.length;
    }

    isFull() {
        // Add logic to check if the formation is full
    }

    isEmpty() {
        return this.members.length === 0;
    }
}
