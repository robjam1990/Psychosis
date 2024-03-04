# File: robjam1990/Psychosis/Gameplay/System/Mutation.py

# Define the initial state
INITIAL_STATE = "O"
Self = INITIAL_STATE
history = []

# Mutation process based on input
def mutate(input):
    # Validate input
    if not isinstance(input, int) or input < 1 or input > 3:
        print("Invalid input for mutation. Please provide a valid integer between 1 and 3.")
        return

    mutationResult = Self  # Initialize mutation result with the current state

    if input == 1:
        # Mutation 1
        mutationResult = "-o"
        history.append("Mutation 1: Changed to -o")
    elif input == 2:
        # Mutation 2
        mutationResult = "1.O"
        history.append("Mutation 2: Changed to 1.O")
    elif input == 3:
        # Mutation 3
        mutationResult = "0.1:I.O"
        history.append("Mutation 3: Changed to 0.1:I.O")
    else:
        # Should not reach here due to input validation, but handling just in case
        print("Unknown input for mutation")
        return

    # Update Self with the mutation result
    global Self
    Self = mutationResult

    # Log input and history
    print("Input: " + str(input))
    print("History: " + ", ".join(history))

# Example usage of the mutate function
input_value = 1
mutate(input_value)
