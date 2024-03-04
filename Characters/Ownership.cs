using System;
using System.Collections.Generic;

public class Ownership
{
    private string owner;
    private bool isStolen;
    private List<Dictionary<string, object>> ownershipHistory;
    private List<IOwnershipSubscriber> eventSubscribers;

    public Ownership(string owner)
    {
        this.owner = owner;
        this.isStolen = false;
        this.ownershipHistory = new List<Dictionary<string, object>>();
        this.ownershipHistory.Add(new Dictionary<string, object>() { { "owner", owner }, { "timestamp", DateTime.Now } });
        this.eventSubscribers = new List<IOwnershipSubscriber>();
    }

    public void TransferOwnership(string newOwner, string transferReason = "")
    {
        if (this.owner == newOwner)
        {
            Console.WriteLine($"Ownership is already with {newOwner}.");
            return;
        }

        this.ownershipHistory.Add(new Dictionary<string, object>() { { "owner", newOwner }, { "timestamp", DateTime.Now } });
        this.owner = newOwner;
        Console.WriteLine($"Ownership transferred to {newOwner}. Reason: {transferReason}");

        TriggerOwnershipEvent("transfer", newOwner, new Dictionary<string, object>() { { "reason", transferReason } });
    }

    public bool IsOwnedBy(string ownerToCheck)
    {
        return this.owner == ownerToCheck;
    }

    public void StealObject(string thief)
    {
        if (!IsOwnedBy(thief))
        {
            this.owner = thief;
            this.isStolen = true;
            this.ownershipHistory.Add(new Dictionary<string, object>() { { "owner", thief }, { "timestamp", DateTime.Now } });
            Console.WriteLine($"{thief} successfully stole the object.");

            TriggerOwnershipEvent("theft", thief);
        }
        else
        {
            Console.WriteLine($"{thief} already owns the object.");
        }
    }

    public void ReclaimObject(string originalOwner)
    {
        if (this.isStolen && IsOwnedBy(originalOwner))
        {
            this.isStolen = false;
            this.ownershipHistory.Add(new Dictionary<string, object>() { { "owner", originalOwner }, { "timestamp", DateTime.Now } });
            Console.WriteLine($"{originalOwner} reclaimed the stolen object.");

            TriggerOwnershipEvent("reclaim", originalOwner);
        }
        else
        {
            Console.WriteLine($"{originalOwner} cannot reclaim the object.");
        }
    }

    public List<Dictionary<string, object>> GetOwnershipHistory()
    {
        return this.ownershipHistory;
    }

    private void TriggerOwnershipEvent(string eventType, string participant, Dictionary<string, object> eventData)
    {
        Console.WriteLine($"Ownership event triggered: {eventType} by {participant}");
        foreach (var subscriber in this.eventSubscribers)
        {
            subscriber.OnOwnershipEvent(eventType, this, participant, eventData);
        }
    }

    public void SubscribeToOwnershipEvents(IOwnershipSubscriber subscriber)
    {
        this.eventSubscribers.Add(subscriber);
    }

    public void UnsubscribeFromOwnershipEvents(IOwnershipSubscriber subscriber)
    {
        this.eventSubscribers.RemoveAll(sub => sub == subscriber);
    }
}

public interface IOwnershipSubscriber
{
    void OnOwnershipEvent(string eventType, Ownership ownership, string participant, Dictionary<string, object> eventData);
}

// Example usage:
// Ownership ownership = new Ownership("Initial Owner");
// ownership.TransferOwnership("New Owner", "Change of hands");
// ownership.StealObject("Thief");
// ownership.ReclaimObject("Original Owner");
