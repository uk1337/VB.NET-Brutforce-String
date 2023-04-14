# BruteforceString
This is a console application that generates all possible combinations of characters of a given length using brute force approach, and finds a specific combination if it exists. The program uses a recursive approach and can leverage multiple threads to speed up the process.


## Usage
1. Clone or download the repository to your local machine.
2. Open the solution in Visual Studio.
3. Build and run the program.
4. Modify the **Combination2Find** variable to the combination you wish to find.


## How It Works
The program generates all possible combinations of characters of a given length by recursively generating combinations of length-1 and appending each character to the prefix. The prefix is initially an empty string, and characters are selected from a predefined set of characters defined in the **myString** constant.

If the desired combination is found, the program sets a flag (**isFound**) and displays a message indicating that the combination has been found along with the time taken to find it.

The program can also use multiple threads to speed up the process. It splits the set of characters into chunks based on the number of processors available and starts a new task to generate combinations for each chunk. The tasks run in parallel, and the program waits for all tasks to complete before continuing.


## Features
- Generates all possible combinations of characters of a given length using a brute force approach.
- Can leverage multiple threads to speed up the process.
- Stops generating combinations when the desired combination is found.
- Displays progress updates every 100,000 combinations generated.
- Can handle a wide range of characters (letters, numbers, and special characters).


## Dependencies
The program does not have any external dependencies.


## Note
This code is for educational purposes only and should not be used in a real-world scenario. It is designed to demonstrate the concept of generating combinations using brute force, and is not optimized for performance or efficiency. Please use caution and proper ethical considerations when implementing similar techniques in practical applications.


## Contributing
Contributions are welcome! Feel free to open an issue or submit a pull request.


## License
This project is licensed under the MIT License.
