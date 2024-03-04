# Save Name = Rock, Paper Scissors, Save Type = .py, Current File Location = robjam1990/Psychosis/Gameplay/Game
import random

class Game:
    Rock = "r"
    Paper = "p"
    Scissors = "s"

    @staticmethod
    def main():
        print("Welcome to the World of Psychosis!")
        print("You find yourself in the Main Hall of the Tavern in the Town of Nexus.")
        print("As you look around, you notice a group of travelers engaged in a game of Rock, Paper, Scissors.")
        print("Would you like to join them?")

        while True:
            user_choice = input("Enter 'join' to play or 'exit' to leave: ").lower()

            if user_choice == 'join':
                Game.play_round()
            elif user_choice == 'exit':
                print("You decide to leave the game.")
                print("You can always come back later if you change your mind.")
                break
            else:
                print("Invalid choice. Please enter 'join' to play or 'exit' to leave.")

    @staticmethod
    def play_round():
        print("\nYou join the game of Rock, Paper, Scissors.")
        user_choice = Game.get_user_choice()
        computer_choice = Game.get_computer_choice()

        Game.display_choices(user_choice, computer_choice)

        result = Game.determine_winner(user_choice, computer_choice)
        Game.display_result(result)

    @staticmethod
    def get_user_choice():
        while True:
            choice = input("Choose rock (r), paper (p), or scissors (s): ").lower()
            if Game.is_valid_choice(choice):
                return choice
            else:
                print("Invalid choice. Please choose again.")

    @staticmethod
    def is_valid_choice(choice):
        return choice == Game.Rock or choice == Game.Paper or choice == Game.Scissors

    @staticmethod
    def get_computer_choice():
        choices = [Game.Rock, Game.Paper, Game.Scissors]
        index = random.randint(0, len(choices) - 1)
        return choices[index]

    @staticmethod
    def determine_winner(user_choice, computer_choice):
        if user_choice == computer_choice:
            return "It's a tie!"
        elif (user_choice == Game.Rock and computer_choice == Game.Scissors) or \
             (user_choice == Game.Paper and computer_choice == Game.Rock) or \
             (user_choice == Game.Scissors and computer_choice == Game.Paper):
            return "You win!"
        else:
            return "Computer wins!"

    @staticmethod
    def display_choices(user_choice, computer_choice):
        print(f"\nYou chose: {user_choice}")
        print(f"The computer chose: {computer_choice}")

    @staticmethod
    def display_result(result):
        print(result)

if __name__ == "__main__":
    Game.main()
