Imports System.Threading.Tasks

Module BruteforceString

    'Define the set of characters to use in generating combinations
    Private Const myString As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{}\|;':\,.<>/?`~ " & Chr(34)

    'Convert the string of characters into an array of characters
    Private ReadOnly chars() As Char = myString.ToCharArray()

    'A flag indicating whether the desired combination has been found
    Private isFound As Boolean = False

    'The combination we're looking for
    Private Combination2Find As String = ""

    'Count of combinations generated
    Private combinationCount As Integer = 0

    'Stopwatch for timing the process
    Private stopwatch As New Stopwatch()

    Sub Main()
        'Set the combination we're looking for
        Combination2Find = "1234"

        'Start the stopwatch to time the process
        stopwatch.Start()

        'Generate all combinations of the given length
        GenerateCombinations(chars, 1)

        'Stop the stopwatch when the process is complete
        stopwatch.Stop()

        'Display a message indicating that the process is done
        Console.WriteLine("Done!")
    End Sub

    'Recursive function to generate all possible combinations
    Private Sub GenerateCombinations(chars() As Char, length As Integer, Optional prefix As String = "")
        'Exit the function if the desired combination has already been found
        If isFound Then Return

        'If the desired length has been reached
        If length = 0 Then

            'Check if the current combination matches the desired combination
            If prefix = Combination2Find Then
                'Set the flag indicating the desired combination has been found
                isFound = True

                'Display a message indicating that the desired combination has been found and the time it took to find it
                MsgBox("Found combination: " & Combination2Find & vbCrLf & "Time taken: " & stopwatch.Elapsed.ToString())
            Else
                'If the current combination does not match the desired combination
                'Increment the combination count
                combinationCount += 1

                'Display an update every 100,000 combinations
                If combinationCount Mod 100000 = 0 Then
                    Console.Title = "Current combination count: " & combinationCount.ToString() & ", Time elapsed: " & stopwatch.Elapsed.ToString() & ", Working threads: " & Process.GetCurrentProcess().Threads.Count.ToString()
                End If
            End If

        Else

            'If the desired length has not been reached
            Dim tasks As New List(Of Task)
            For i As Integer = 0 To chars.Length - 1 Step chars.Length \ Environment.ProcessorCount
                'Split the character array into chunks based on the number of processors available
                Dim start As Integer = i 'Starting index of the current chunk
                Dim [end] As Integer = Math.Min(i + chars.Length \ Environment.ProcessorCount - 1, chars.Length - 1) 'Ending index of the current chunk

                'Start a new task to generate combinations for the current chunk of characters
                tasks.Add(Task.Run(Sub()
                                       For j As Integer = start To [end] 'Iterate over each character in the current chunk
                                           Dim newPrefix As String = prefix + chars(j) 'Append the current character to the current prefix to generate a new prefix
                                           GenerateCombinations(chars, length - 1, newPrefix) 'Recursively generate combinations of length - 1 using the new prefix
                                       Next
                                   End Sub))
            Next

            'Wait for all the tasks to complete before continuing
            Task.WaitAll(tasks.ToArray())

            'If the desired length has not been reached and the last character in the array is not in the desired combination
            If prefix = "" AndAlso length < chars.Length AndAlso Not Combination2Find.Contains(chars.Last) Then
                GenerateCombinations(chars, length + 1) 'recursively generate
            End If

        End If
    End Sub

End Module
