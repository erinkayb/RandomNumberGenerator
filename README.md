# RandomNumberGenerator

## Installation

Clone the repo


## Run

Start the project within Visual Studio

## Challenge instructions

Write a program that generates a list of 10,000 numbers in random order each time it is
run. Each number in the list must be unique and be between 1 and 10,000 (inclusive).

## Research 

https://www.dotnetperls.com/fisher-yates-shuffle
https://docs.microsoft.com/en-us/dotnet/api/system.random?view=net-5.0
https://www.dotnetperls.com/orderby
https://www.dotnetperls.com/random -One instance meaning truly random

Shuffle using Key Value
This shuffle performs all randomize operations together instead of one after the other.
It utilizes the built in KeyValuePair and allocates a list.
It associates a random number to the original number and then sorts the list based on that random number.
This means it randomizes all at once.
This method, however, is not the best performance wise.

Shuffle using Fisher-Yates
This shuffle does not allocate any resources which makes it faster than the other Shuffle method.
In this shuffle it randomized the index, sets the list to each index, and double checks that we are not going over the list size.

