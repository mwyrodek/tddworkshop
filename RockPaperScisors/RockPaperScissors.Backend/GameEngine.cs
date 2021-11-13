﻿using RockPaperScissors.Backend.Models;
using RockPaperScissors.Backend.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("RockPaperScissors.Backend.Tests")]
namespace RockPaperScissors.Backend
{

    public class GameEngine
    {
        private GameOptions Options;
        private IUserInterface ui;
        internal protected GameResult GameResult;

        public GameEngine(IUserInterface Ui)
        {
            this.ui = Ui;
            this.GameResult = new GameResult();
            this.Options = new GameOptions();
        }

        public void RunGame()
        {
            SetupGame();
            while (!this.GameResult.Finshed)
            {
                var Actions = new PlayerActions();
                Actions.PlayerOneMove = ui.GetPlayerAction(1);
                Actions.PlayerTwoMove = ui.GetPlayerAction(2);

                var result = PlayTurn(Actions);

                ui.DisplayReults(result);
            }
        }

        protected void SetupGame()
        {
            this.Options = ui.SetupGame();
            if (this.Options.MaxWins < 1) throw new ArgumentOutOfRangeException($"Values {this.Options.MaxWins} is Smaller than minimal allowed number of wins: 1");
            this.GameResult = new GameResult();
        }

        protected GameResult PlayTurn(PlayerActions playersActions)
        {
            if (this.GameResult.Finshed) throw new InvalidOperationException("Game should be finished");
            this.GameResult.TurnsFinished++;

            var result = MoveFactory.GetMove(playersActions.PlayerOneMove).IsWinning(playersActions.PlayerTwoMove);
            switch (result)
            {
                case TurnResult.WIN:
                    this.GameResult.RoundWonByPlayer = 1;
                    this.GameResult.PlayerOneScore++;

                    break;
                case TurnResult.LOSE:
                    this.GameResult.RoundWonByPlayer = 2;
                    this.GameResult.PlayerTwoScore++;
                    break;
                case TurnResult.TIE:
                    this.GameResult.RoundWonByPlayer = 0;
                    break;
            }
            if ((this.GameResult.PlayerTwoScore >= this.Options.MaxWins) || (this.GameResult.PlayerOneScore >= this.Options.MaxWins))
            {
                this.GameResult.Finshed = true;
            }

            return GameResult;
        }
    }
}
