'Xavier Hoskins
'RCET 0265
'Fall 2022
'Roll of the Dice
'http://www.github.com/hoskxavi/RollOfTheDice


Option Explicit On
Option Strict On
Imports System

Module DiceRoll
    Sub Main()
        Dim userInput As String
        Console.WriteLine("Welcome to Roll Of The Dice! Press ENTER to roll the dice 1000 times.")
        Console.WriteLine("Enter Q at any time to quit.")

        'loop until user exits the program
        Do
            userInput = Console.ReadLine()
            If userInput = "Q" Or userInput = "q" Then
                Exit Sub
            Else
                Rolls()
            End If
        Loop

    End Sub

    'Method to roll the dice 1000 times
    Sub Rolls()
        Dim numberOfColumns As Integer = 11
        Dim rolls(numberOfColumns + 1) As Integer
        Dim header(numberOfColumns + 1) As Integer
        Dim columnWidth As Integer = 8
        Dim columnSeparator As String = " |"
        Dim horizontalSeparator As String = "-"
        'roll the dice 1000 times
        For i = 0 To 1000
            rolls(DiceRoll()) += 1
        Next

        'build the header with the possible outcomes of the dice roll
        For i = LBound(header) To UBound(header)
            header(i) = i
        Next

        Console.WriteLine(("Roll of the Dice").PadLeft(56))
        'call the funtions to format the arrays
        Console.WriteLine(FormatArray(header, columnWidth, columnSeparator))
        Console.WriteLine(StrDup(columnWidth * numberOfColumns, horizontalSeparator))
        Console.WriteLine(FormatArray(rolls, columnWidth, columnSeparator))

    End Sub

    'function to roll the dice
    Function DiceRoll() As Integer
        Dim diceOne As Integer
        Dim diceTwo As Integer
        Dim diceTotal As Integer
        'begin the random number generator
        Randomize()
        diceOne = CInt(Int((6 * Rnd()) + 1))
        diceTwo = CInt(Int((6 * Rnd()) + 1))
        diceTotal = diceOne + diceTwo
        Return (diceTotal)
    End Function

    'function to format the arrays
    Function FormatArray(columns() As Integer, columnWidth As Integer, columnSeparator As String) As String
        Dim _row As String
        Dim temp As String
        For i = (LBound(columns) + 2) To UBound(columns)
            temp = columns(i) & columnSeparator
            temp = temp.PadLeft(columnWidth)
            _row &= temp
        Next
        Return _row
    End Function

End Module
