// File: robjam1990/Psychosis/Gameplay/Games/Assimilation.cs
using System;
using System.Collections.Generic;

public class AssimilationGame
{
    public void ValidateScores(int playerN, int playerI)
    {
        /**
         * Validate player scores for a game (specifically for assimilation).
         *
         * @param {int} playerN - Score of Player 'N'.
         * @param {int} playerI - Score of Player 'I'.
         *
         * @throws {Exception} If scores are not non-negative integers or greater than 40.
         */
        if (!(playerN >= 0 && playerN <= 40 && playerI >= 0 && playerI <= 40))
        {
            throw new Exception("Scores must be non-negative integers no greater than 40.");
        }
    }

    public string GameLogic(int playerN, int playerI)
    {
        /**
         * Compare scores of two players and determine the game outcome.
         *
         * @param {int} playerN - Score of Player 'N'.
         * @param {int} playerI - Score of Player 'I'.
         *
         * @returns {string} Result message indicating the outcome of the game.
         */
        // Additional input validation
        ValidateScores(playerN, playerI);

        // Using a dictionary for outcomes
        Dictionary<string, string> outcomes = new Dictionary<string, string>
        {
            {"n_wins", $"Player 'I' becomes Player 'N', Player 'N' wins with scores {playerN}-{playerI}"},
            {"i_wins", $"Player 'N' becomes Player 'I', Player 'I' wins with scores {playerN}-{playerI}"},
            {"draw", $"Both Players have the same score: {playerN}-{playerI}"}
        };

        // Determine the outcome
        string result;
        if (playerN < playerI)
        {
            result = outcomes["i_wins"];
        }
        else if (playerN > playerI)
        {
            result = outcomes["n_wins"];
        }
        else
        {
            result = outcomes["draw"];
        }

        return result;
    }

    public string Play(int playerNScore, int playerIScore)
    {
        /**
         * Play the assimilation game with given scores for players 'N' and 'I'.
         *
         * @param {int} playerNScore - Score of Player 'N'.
         * @param {int} playerIScore - Score of Player 'I'.
         *
         * @returns {string} Result message indicating the outcome of the game.
         */
        return GameLogic(playerNScore, playerIScore);
    }
}

public class Tavern
{
    private AssimilationGame assimilationGame;

    public Tavern()
    {
        assimilationGame = new AssimilationGame();
    }

    public string PlayAssimilationGame(int playerNScore, int playerIScore)
    {
        /**
         * Play the assimilation game with given scores for players 'N' and 'I'.
         *
         * @param {int} playerNScore - Score of Player 'N'.
         * @param {int} playerIScore - Score of Player 'I'.
         *
         * @returns {string} Result message indicating the outcome of the game.
         */
        return assimilationGame.Play(playerNScore, playerIScore);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example usage:
        Tavern tavern = new Tavern();
        int playerNScore = 5;
        int playerIScore = 7;
        string result = tavern.PlayAssimilationGame(playerNScore, playerIScore);
        Console.WriteLine($"Result: {result}");
    }
}
