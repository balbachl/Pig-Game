using System;

namespace Pig.Models
{
    public class Game
    {
        // set up new game in constructor
        public Game()
        {
            NewGame();
        }

        public const int WinningNumber = 20;

        public Player? Player1 { get; set; }
        public Player? Player2 { get; set; }

        public string? CurrentPlayerName { get; set; }
        public int LastRoll { get; set; }
        public int CurrentTurnScore { get; set; }

        public bool IsGameOver { get; set; }

        public void NewGame()
        {
            Player1 = new Player { Name = "Player 1" };
            Player2 = new Player { Name = "Player 2" };
            CurrentPlayerName = Player1.Name;
            CurrentTurnScore = 0;
            LastRoll = 0;
            IsGameOver = false;
        }

        public void Roll()
        {
            Random rand = new Random();
            LastRoll = rand.Next(1, 7);

            if (LastRoll == 1)
            {
                CurrentTurnScore = 0;
                ChangePlayers();
            }
            else
            {
                CurrentTurnScore += LastRoll;
            } 
        }

        public void Hold()
        {
            Player current = (CurrentPlayerName == Player1.Name) ? Player1 : Player2;

            current.Score += CurrentTurnScore;
            if (current.Score >= WinningNumber)
            {
                IsGameOver = true;
            }
            else
            {
                CurrentTurnScore = 0;
                LastRoll = 0;
                ChangePlayers();
            }

        }

        public void ChangePlayers()
        {
            CurrentPlayerName = (CurrentPlayerName == Player1.Name) ? Player2.Name : Player1.Name; 
        }

    }
}
