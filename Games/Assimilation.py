# File = robjam1990/Psychosis/Gameplay/Games/Assimilation.py
from functools import lru_cache
from typing import DefaultDict

class Tavern:
    def __init__(self):
        self.assimilation_game = AssimilationGame()

    def play_assimilation_game(self, player_n_score, player_i_score):
        return self.assimilation_game.play(player_n_score, player_i_score)

class AssimilationGame:
    def __init__(self):
        pass
    
    def validate_scores(self, player_n, player_i):
        """
        Validate player scores for a game (specifically for assimilation).
    
        Args:
            player_n (int): Score of Player 'n'.
            player_i (int): Score of Player 'i'.
    
        Raises:
            ValueError: If scores are not non-negative integers or greater than 40.
        """
        if not (0 <= player_n <= 40 and 0 <= player_i <= 40):
            raise ValueError("Scores must be non-negative integers no greater than 40.")
    
    @lru_cache(maxsize=None)
    def game_logic(self, player_n, player_i):
        """
        Compare scores of two players and determine the game outcome.
    
        Args:
            player_n (int): Score of Player 'n'.
            player_i (int): Score of Player 'i'.
    
        Returns:
            str: Result message indicating the outcome of the game.
        """
        # Additional input validation
        self.validate_scores(player_n, player_i)
    
        # Using defaultdict for outcomes
        outcomes = DefaultDict(
            lambda: "Invalid outcome",
            {
                "n_wins": f"Player 'i' becomes Player 'n', Player 'n' wins with scores {player_n}-{player_i}",
                "i_wins": f"Player 'n' becomes Player 'i', Player 'i' wins with scores {player_n}-{player_i}",
                "draw": f"Both Players have the same score: {player_n}-{player_i}",
            }
        )
    
        # Determine the outcome
        if player_n < player_i:
            result = outcomes["i_wins"]
        elif player_n > player_i:
            result = outcomes["n_wins"]
        else:
            result = outcomes["draw"]
    
        return result

    def play(self, player_n_score, player_i_score):
        """
        Play the assimilation game with given scores for players 'n' and 'i'.
        
        Args:
            player_n_score (int): Score of Player 'n'.
            player_i_score (int): Score of Player 'i'.
        
        Returns:
            str: Result message indicating the outcome of the game.
        """
        return self.game_logic(player_n_score, player_i_score)

# Example usage:
tavern = Tavern()
player_n_score = 5
player_i_score = 7
result = tavern.play_assimilation_game(player_n_score, player_i_score)
print(f"Result: {result}")
