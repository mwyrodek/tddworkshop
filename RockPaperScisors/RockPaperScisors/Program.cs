// See https://aka.ms/new-console-template for more information
using RockPaperScisors;
using RockPaperScissors.Backend;


//setup game
ITerminal terminal = new ComandLineTerminal();
IUserInterface ui = new UserInterface(terminal);
GameEngine gameEnigne = new GameEngine(ui);
//start game
gameEnigne.RunGame();

