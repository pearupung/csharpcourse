# C# 2019 Fall Homework

Connect 4  - student code ending 0-4
MineSweeper - student code ending 5-9

## In progress
- **CON4-007** Move menusystem UI outside of the menu system

## Done
- **CON4-001** Move the menu system to a stack based structure
- **CON4-002** Make a modifiable menu UI MVP implementation
- **CON4-003** Copy all useful structure from already made menusystem
- **CON4-008** Implement gameplay/gameflow using the new menusystem, keep UI separate
- **CON4-009** Implement 2-player gameplay with the new menusystem
- **CON4-004** Delete the old menusystem
- **CON4-005** Complete the menu structure as much as you can w/o gameplay in mind
- **CON4-006** Clean up and reorganise the menusystem of unnecessary fields
- **CON4-010** Make the menu and the menu item dumb

## Leg 1
### Deadline 2019-10-13 23:59:59

Menu system, board drawing, user input validation.
Board size is not fixed! Give user an option to do custom size game.

### Connect 4
Allow only make legal moves, implement 2 player simple gameflow (just check for full board).

### MineSweeper
Initialize board with random mines (look up for classical board sizes/mine counts).
User should be able just open up any square, and discover is there a mine or not (you can always implement more!).

## Leg2
### Deadline 2019-10-27 23:59:59

Implement game settings loading and saving from json file.
Implement game save and load system to/from json (either save after every move, or have a command to save current game state).
Allow multiple save games (ask filename from the user, check for overwriting).
Allow continuing previously saved games (list all possible saved games).

### Implement "(non-) nullable reference types" in all your projects!

All your project files should have this;
    <PropertyGroup>
        <Nullable>enable</Nullable>
    </PropertyGroup>

Solution must rebuild without any warnings!
Implement game settings loading and saving from json file.


##Leg3
###Deadline 2019-11-10 23:59:59

Replace json files with EF based database. Use SQLite.


# Priorities

# Backlogi


# Thought catalog

- Have finally completed the menusystem overhaul somewhat - cannot say if it is better now or not, but its much
	more customisable from the app state perspective. Still need to configure keys to certain actions - 
	this probably means more database tables and generalization. Need to think about the structure once more
	because I am wary of potential pitfalls. 
