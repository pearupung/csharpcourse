# C# 2019 Fall Homework

Connect 4  - student code ending 0-4
MineSweeper - student code ending 5-9

## In progress

## Done
**CON4-001** Move the menu system to a stack based structure
**CON4-002** Make a modifiable menu UI MVP implementation
**CON4-003** Copy all useful structure from already made menusystem

## Leg1 
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

# Priorities

- CON4-001 Move the menu system to a stack based structure

# Backlogi
- **CON4-004** Delete the old menusystem
- **CON4-005** Complete the menu structure as much as you can w/o gameplay in mind
- **CON4-006** Clean up and reorganise the menusystem of unnecessary fields
- **CON4-007** Move menusystem UI outside of the menu system
- **CON4-008** Implement gameplay/gameflow using the new menusystem, keep UI separate
- think about separating the menusystem and menu UI
- think about separating the gameboard and the game UI
- think about having a win/lose window
- think about generalising the menu/menuitem components and behaviour 
    - having a property on menu items that specify on which levels they appear (strategy pattern?)
    - handling the toggle functionality more elegantly
    - pulling the menu structure from JSON or DB

# Thought catalog
- maybe let's just not touch what ain't broken?
- let's prioritize leg2 ATM?
- let's go to bed and get some sleep?
- there is a bug in the level <2 menus: while pressing p or m the menu still exits. This is apparent
    in Käver's repository as well, I believe, we need another way to handle the menu. Let's continue refactoring
    at the moment, let's see where this will take us. Could be fixed by simply modifying the exit condition.
    
    This is maybe solved by having a stack of menus. A solution could also include a string independent solution.
    I would like to have a loop in the main program - yes, that seems simple, the same loop that simply runs the
    same UI print function. But in that function I'd like to have the systems state to change - that should drive 
    the UI. Well, let's see.
    We do not need to have UI in the Menu itself, right? Maybe use signals or enums instead of strings to communicate
    with the menu. The menu still has the right to have some logic in it. MVC might be the solution, let's think 
    about this, let's not rule that out. gn sleep tight atm. 
- Ideally we want to split the menu, the menuview (that keeps track which menu are we on) and the way we want
	to pick the menuItem from that menu. MenuView should not know how the menuItem is chosen, it simply 
	has a function to choose one.
- The menu stack is an interesting idea. When the user wishes to quit, the only logical condition would be that
	the stack is empty. I'm wary of that option - it seems ingenious but I'm afraid it will bite me in the 
	hand someday or sometime in the future I won't like it. Let's implement it anyhow.
- Absolutely astonishing is the fear of thinking how to store the menus. Is recursive the best or is there a better
	way that is more flat and useful? Let's use the current solution for now, the fear seems baseless.
- Would want to make the menu so that the menu command strings are not tied to the menuItems themselves, at least
	right now. I know it is maybe better to have a dictionary instead of a list, but I'd rather have the 
	dictionary somewhere else along with the arbitrary command keys we use. It is a hell to refactor this, but
	I guess this is a good exercise for thought.
