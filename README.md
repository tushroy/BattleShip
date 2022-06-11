# BattleShip
A sample simple battleship game.
## BattleShipClasses
Project contains API Classes for the game
## BattleShip
Contains sample battleship console application 
## webbackend
.Net core 6.0 web backend for the game
## webfrontend
VueJS web frontend for the game

## How to run
Open "BattleShip.sln" in Microsoft Visual Studio 2022 and make sure multiple startup project is selected for "webbackend" and "webfrontend" if you want to run the web application, then start.
the backend application runs on https://localhost:5001  and http://localhost:5003
the frontend application run on https://localhost:5002 
then frontend application proxies api request to 'https://localhost:5001/'