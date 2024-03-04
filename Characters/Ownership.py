from datetime import datetime

class Ownership:
    def __init__(self, owner):
        self.owner = owner
        self.isStolen = False
        self.ownershipHistory = [{"owner": owner, "timestamp": datetime.now()}]
        self.eventSubscribers = []

    def transferOwnership(self, newOwner, transferReason=""):
        if self.owner == newOwner:
            print(f"Ownership is already with {newOwner}.")
            return

        self.ownershipHistory.append({"owner": newOwner, "timestamp": datetime.now()})
        self.owner = newOwner
        print(f"Ownership transferred to {newOwner}. Reason: {transferReason}")
        self.triggerOwnershipEvent('transfer', newOwner, {"reason": transferReason})

    def isOwnedBy(self, ownerToCheck):
        return self.owner == ownerToCheck

    def stealObject(self, thief):
        if not self.isOwnedBy(thief):
            self.owner = thief
            self.isStolen = True
            self.ownershipHistory.append({"owner": thief, "timestamp": datetime.now()})
            print(f"{thief} successfully stole the object.")
            self.triggerOwnershipEvent('theft', thief)
        else:
            print(f"{thief} already owns the object.")

    def reclaimObject(self, originalOwner):
        if self.isStolen and self.isOwnedBy(originalOwner):
            self.isStolen = False
            self.ownershipHistory.append({"owner": originalOwner, "timestamp": datetime.now()})
            print(f"{originalOwner} reclaimed the stolen object.")
            self.triggerOwnershipEvent('reclaim', originalOwner)
        else:
            print(f"{originalOwner} cannot reclaim the object.")

    def getOwnershipHistory(self):
        return self.ownershipHistory

    def triggerOwnershipEvent(self, eventType, participant, eventData={}):
        print(f"Ownership event triggered: {eventType} by {participant}")
        for subscriber in self.eventSubscribers:
            subscriber.onOwnershipEvent(eventType, self, participant, eventData)

    def subscribeToOwnershipEvents(self, subscriber):
        self.eventSubscribers.append(subscriber)

    def unsubscribeFromOwnershipEvents(self, subscriber):
        self.eventSubscribers = [sub for sub in self.eventSubscribers if sub != subscriber]

# Example usage:
# ownership = Ownership("Initial Owner")
# ownership.transferOwnership("New Owner", "Change of hands")
# ownership.stealObject("Thief")
# ownership.reclaimObject("Original Owner")
