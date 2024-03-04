//Save Name = Rock, Paper Scissors, Save Type = .js, Current File Location = robjam1990/Psychosis/Gameplay/Game
// Rock, Paper, Scissors game class
class RockPaperScissors {
    constructor(player1, player2) {
        this.players = [player1, player2];
        this.choices = ["rock", "paper", "scissors"];
    }

    // Method to start the game
    play() {
        console.log("Welcome to Rock, Paper, Scissors!");
        const mode = this.chooseMode();
        if (mode === "ai") {
            this.playAgainstAI();
        } else if (mode === "multiplayer") {
            this.playMultiplayer();
        } else {
            console.log("Invalid mode. Please choose again.");
            this.play();
        }
    }

    // Method to choose game mode
    chooseMode() {
        return prompt("Choose mode: 'ai' for single-player against AI, 'multiplayer' for multiplayer: ").toLowerCase();
    }

    // Method to play against AI
    playAgainstAI() {
        const playerName = prompt("Enter your name: ");
        console.log(`Welcome, ${playerName}, to Single-player Rock, Paper, Scissors against AI!`);

        while (true) {
            const playerChoice = this.getPlayerChoice(playerName);
            const computerChoice = this.getComputerChoice();

            this.displayChoices(playerChoice, "Computer");

            const result = this.determineWinner(playerChoice, computerChoice);
            this.displayResult(result);

            if (!this.playAgain()) {
                console.log("Thanks for playing Single-player Rock, Paper, Scissors against AI! Goodbye!");
                break;
            }
        }
    }

    // Method to play multiplayer
    playMultiplayer() {
        const player1Name = prompt("Enter Player 1's name: ");
        const player2Name = prompt("Enter Player 2's name: ");
        console.log(`Welcome, ${player1Name} and ${player2Name}, to Multiplayer Rock, Paper, Scissors!`);

        while (true) {
            const player1Choice = this.getPlayerChoice(player1Name);
            const player2Choice = this.getPlayerChoice(player2Name);

            this.displayChoices(player1Choice, player2Choice);

            const result = this.determineWinner(player1Choice, player2Choice);
            this.displayResult(result);

            if (!this.playAgain()) {
                console.log("Thanks for playing Multiplayer Rock, Paper, Scissors! Goodbye!");
                break;
            }
        }
    }

    // Method to get player's choice
    getPlayerChoice(playerName) {
        let choice;
        while (true) {
            choice = prompt(`${playerName}, choose rock, paper, or scissors: `).toLowerCase();
            if (this.isValidChoice(choice)) {
                break;
            } else {
                console.log("Invalid choice. Please choose again.");
            }
        }
        return choice;
    }

    // Method to validate choice
    isValidChoice(choice) {
        return this.choices.includes(choice);
    }

    // Method to get AI's choice
    getComputerChoice() {
        const index = Math.floor(Math.random() * this.choices.length);
        return this.choices[index];
    }

    // Method to determine the winner
    determineWinner(playerChoice, opponentChoice) {
        if (playerChoice === opponentChoice) {
            return "It's a tie!";
        } else if ((playerChoice === "rock" && opponentChoice === "scissors") ||
            (playerChoice === "paper" && opponentChoice === "rock") ||
            (playerChoice === "scissors" && opponentChoice === "paper")) {
            return "You win!";
        } else {
            return "You lose!";
        }
    }

    // Method to display choices
    displayChoices(playerChoice, opponentChoice) {
        console.log(`You chose: ${playerChoice}`);
        console.log(`Opponent chose: ${opponentChoice}`);
    }

    // Method to display result
    displayResult(result) {
        console.log(result);
        console.log("------------------------------");
    }

    // Method to ask if the player wants to play again
    playAgain() {
        while (true) {
            const choice = prompt("Do you want to play again? (yes/no): ").toLowerCase();
            if (choice === "yes" || choice === "y") {
                return true;
            } else if (choice === "no" || choice === "n") {
                return false;
            } else {
                console.log("Invalid choice. Please choose again.");
            }
        }
    }
}

// Start the game
const playerName = prompt("Enter your name: ");
const game = new RockPaperScissors(playerName, "Computer");
game.play();
