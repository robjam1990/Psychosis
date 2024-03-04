//File = robjam1990/Psychosis/Gameplay/Characters/Ownership.js
class Ownership {
    constructor(owner) {
        this.owner = owner;
        this.isStolen = false;
        this.ownershipHistory = [{ owner: owner, timestamp: Date.now() }]; // Track ownership history with timestamps
        this.eventSubscribers = []; // List of subscribers for ownership events
    }

    // Transfer ownership of the object to a new owner
    transferOwnership(newOwner, transferReason = "") {
        // Implement ownership transfer restrictions or conditions here
        if (this.owner === newOwner) {
            console.log(`Ownership is already with ${newOwner}.`);
            return;
        }

        this.ownershipHistory.push({ owner: newOwner, timestamp: Date.now() });
        this.owner = newOwner;
        console.log(`Ownership transferred to ${newOwner}. Reason: ${transferReason}`);

        // Trigger ownership transfer event
        this.triggerOwnershipEvent('transfer', newOwner, { reason: transferReason });
    }

    // Check if the object is owned by a specific owner
    isOwnedBy(ownerToCheck) {
        return this.owner === ownerToCheck;
    }

    // Steal the object
    stealObject(thief) {
        if (!this.isOwnedBy(thief)) {
            this.owner = thief;
            this.isStolen = true;
            this.ownershipHistory.push({ owner: thief, timestamp: Date.now() });
            console.log(`${thief} successfully stole the object.`);

            // Trigger object theft event
            this.triggerOwnershipEvent('theft', thief);
        } else {
            console.log(`${thief} already owns the object.`);
        }
    }

    // Reclaim a stolen object
    reclaimObject(originalOwner) {
        if (this.isStolen && this.isOwnedBy(originalOwner)) {
            this.isStolen = false;
            this.ownershipHistory.push({ owner: originalOwner, timestamp: Date.now() });
            console.log(`${originalOwner} reclaimed the stolen object.`);

            // Trigger object reclaim event
            this.triggerOwnershipEvent('reclaim', originalOwner);
        } else {
            console.log(`${originalOwner} cannot reclaim the object.`);
        }
    }

    // Get the ownership history of the object
    getOwnershipHistory() {
        return this.ownershipHistory;
    }

    // Trigger an ownership event
    triggerOwnershipEvent(eventType, participant, eventData = {}) {
        // Implement event handling logic here
        console.log(`Ownership event triggered: ${eventType} by ${participant}`);
        // Notify subscribers of the event
        this.eventSubscribers.forEach(subscriber => {
            subscriber.onOwnershipEvent(eventType, this, participant, eventData);
        });
    }

    // Subscribe to ownership events
    subscribeToOwnershipEvents(subscriber) {
        this.eventSubscribers.push(subscriber);
    }

    // Unsubscribe from ownership events
    unsubscribeFromOwnershipEvents(subscriber) {
        this.eventSubscribers = this.eventSubscribers.filter(sub => sub !== subscriber);
    }
}

module.exports = Ownership;
