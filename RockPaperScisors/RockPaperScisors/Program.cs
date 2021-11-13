// See https://aka.ms/new-console-template for more information
using RockPaperScisors;
using RockPaperScissors.Backend;
using System;


//setup game
iTerminal terminal = new ComandLineTerminal();
iUserInterface ui = new UserInterface(terminal);
GameEngine gameEnigne = new GameEngine(ui);
//start game
gameEnigne.RunGame();
//handle quit

//handle rules
//Console.WriteLine("[C]o-op [E]asy [Medium] [Hard] [Q]uit");


Console.WriteLine("result");


