# TP_Battleship

### Description

Battleship board game simulator with Blazor WebAssembly UI.
App randomly places ships on two boards of size 10x10 and simulates gameplay between 2 players.

After each round a hit probability of each field is calculated (IHitPropabilityCalculator) and field with highest hit propability is marked.
Current implementation assumes random marking of fields on boards. Position of occupied fields is not taken into account in the calculations.