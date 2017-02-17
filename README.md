# How to run
Binaries are included in `./binaries.zip` file.

Please unzip and run the `BV` application, refer also to the `./Images` folder.

# How to run tests
Visual studio test runner, please refer also to the `./Images` folder.

# Where are the main source files
The console app is in `./Program.cs`.

The cache itself is in a separate library `./BV.Library/LRUCache.cs`.

The tests are in a specific test library `./BVC.Library.Test/LRU.Cache.Test.cs`.

# Architecture - what's inside the box

## Console app
Consumes the cache, deals with I/O and logic that pertains to the I/O. 

E.g. the cache simply return null if an element does not exist or it has been deleted.
It is the I/O's responsiblity to display the appropriate message.

## Library
Contains the LRU cache class.

The cache is composed by
* A dictionary, that contains k,v pairs.
* A doubly linked list, containing the history of the keys.
* Counter of how many elements are present in the cache.
* Size of the cache.
* Dictionary for key/node. See below in assumption for the reason behind this choice.

## Test library
Tests to document the LRU cache API.

# Assumptions
* Reduce time complexity is more important than space complexity.
* For this reason a dictionary is kept for the history of the keys, in order to provide constant time access in case of getting / setting of an element (rather than traversing the whole linked list and find where a node is).
* If an element is (gotten), it should be moved to the top of the history, like happens for setting.
* Assumed keys are small, and values will be big.
* For this reason, the history for the values is kept in a linked list, but the linked list only contains the keys, not the values.
* The values are only present in the cache dictionary.


#Time taken
~ 2 h for coding (1h 20m for tests and cache, 30 mis for console app) + 30 mins for Readme and packaging.


# prompt received

Design and implement an LRU (Least Recently Used) cache. This is a cache with fixed size in terms of the number of items it holds (supplied at instantiation).  For this exercise, we won’t worry about the number of bytes. Your program can treat the keys and values as strings.  You don’t need to support keys or values that contain spaces.  The cache must allow client code to get items from the cache and set items to the cache. Once the cache is full, when the client wants to store a new item in the cache, an old item must be overwritten or
removed to make room. The item we will remove is the Least Recently Used (LRU) item.  Note that your cache does not need persistence across sessions.

Please read input from stdin and print output to stdout and support the following format (please DO NOT print any kind of a prompt or extra line breaks).
All inputs and outputs exist on their own line:

The first input line should set the max number of items for the cache using the keyword SIZE.  The program should respond with ‘SIZE OK’. This must only occur as the first operation.

Set items with a line giving the key and value, separated by a space, 
your program should respond with 'SET OK'.

Get items with a line giving the key requested, your program should respond with the previously stored value, for example “GOT foo”. If the the key is not in the cache, it should reply with “NOTFOUND”.

‘EXIT’ should cause your program to exit.

If the input is invalid, your program should respond with ‘ERROR’

Sample Input
SIZE 3
GET foo
SET foo 1
GET foo
SET foo 1.1
GET foo
SET spam 2
GET spam
SET ham third
SET parrot four
GET foo
GET spam
GET ham
GET ham parrot
GET parrot
EXIT

Expected Output
SIZE OK
NOTFOUND
SET OK
GOT 1
SET OK
GOT 1.1
SET OK
GOT 2
SET OK
SET OK
NOTFOUND
GOT 2
GOT third
ERROR
GOT four