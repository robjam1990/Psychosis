// File: robjam1990/Psychosis/Gameplay/Games/Assimilation.js

class AssimilationGame {
    constructor() { }

    validateScores(playerN, playerI) {
        /**
         * Validate player scores for a game (specifically for assimilation).
         *
         * @param {number} playerN - Score of Player 'N'.
         * @param {number} playerI - Score of Player 'I'.
         *
         * @throws {Error} If scores are not non-negative integers or greater than 40.
         */
        if (!(playerN >= 0 && playerN <= 40 && playerI >= 0 && playerI <= 40)) {
            throw new Error("Scores must be non-negative integers no greater than 40.");
        }
    }

    gameLogic(playerN, playerI) {
        /**
         * Compare scores of two players and determine the game outcome.
         *
         * @param {number} playerN - Score of Player 'N'.
         * @param {number} playerI - Score of Player 'I'.
         *
         * @returns {string} Result message indicating the outcome of the game.
         */
        // Additional input validation
        this.validateScores(playerN, playerI);

        // Using an object for outcomes
        const outcomes = {
            "n_wins": `Player 'I' becomes Player 'N', Player 'N' wins with scores ${playerN}-${playerI}`,
            "i_wins": `Player 'N' becomes Player 'I', Player 'I' wins with scores ${playerN}-${playerI}`,
            "draw": `Both Players have the same score: ${playerN}-${playerI}`,
        };

        // Determine the outcome
        let result;
        if (playerN < playerI) {
            result = outcomes["i_wins"];
        } else if (playerN > playerI) {
            result = outcomes["n_wins"];
        } else {
            result = outcomes["draw"];
        }

        return result;
    }

    play(playerNScore, playerIScore) {
        /**
         * Play the assimilation game with given scores for players 'N' and 'I'.
         *
         * @param {number} playerNScore - Score of Player 'N'.
         * @param {number} playerIScore - Score of Player 'I'.
         *
         * @returns {string} Result message indicating the outcome of the game.
         */
        return this.gameLogic(playerNScore, playerIScore);
    }
}

class Tavern {
    constructor() {
        this.assimilationGame = new AssimilationGame();
    }

    playAssimilationGame(playerNScore, playerIScore) {
        /**
         * Play the assimilation game with given scores for players 'N' and 'I'.
         *
         * @param {number} playerNScore - Score of Player 'N'.
         * @param {number} playerIScore - Score of Player 'I'.
         *
         * @returns {string} Result message indicating the outcome of the game.
         */
        return this.assimilationGame.play(playerNScore, playerIScore);
    }
}

// Example usage:
const tavern = new Tavern();
const playerNScore = 5;
const playerIScore = 7;
const result = tavern.playAssimilationGame(playerNScore, playerIScore);
console.log(`Result: ${result}`);
