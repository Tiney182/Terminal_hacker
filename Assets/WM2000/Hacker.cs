using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    enum State { MainMenu, Password, Win };

    State currentState = State.MainMenu;
    string Password;
    int level;
    void Start()
    {
        Terminal.ClearScreen();
        ShowMainMenu("Andy");
    }

    void ShowMainMenu(string username)
    {
        currentState = State.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + username);
        Terminal.WriteLine("You can type menu at any time to return to the menu");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the stupid murderer");
        Terminal.WriteLine("Press 2 for the smart murderer");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Andy");
        }
        else if (currentState == State.MainMenu)
        {
            level = int.Parse(input);
            StartGame(level);
        }
        else if (currentState == State.Password)
        {
            CheckPassword(input);
        }
    }

    private void CheckPassword(string input)
    {
        if (input == Password)
        {
            CorrectPassword();
        }
        else
        {
            IncorrectPassword();
        }
    }

    private static void CorrectPassword()
    {
        Terminal.WriteLine("Contratulations");
    }

    private static void IncorrectPassword()
    {
        Terminal.WriteLine("Incorrect password try again!");
    }

    void StartGame(int level)
    {
        if (level.Equals(1))
        {
            currentState = State.Password;
            Password = GetRandomPassword(levelOnePasswords);
            Terminal.ClearScreen();
            Terminal.WriteLine("This murderer is pretty dumb you should be able to guess these annograms quickly");
        }
        else if (level.Equals(2))
        {
            currentState = State.Password;
            Password = GetRandomPassword(levelTwoPasswords);
            Terminal.ClearScreen();
            Terminal.WriteLine("This murderer is smart you might take a while cracking his clues");
        }
        else
        {
            Error();
        }
    }

    void Error()
    {
        Terminal.WriteLine("Invalid input");
    }

    // Game configuration
    string[] levelOnePasswords = { "murder", "pants" };
    string[] levelTwoPasswords = { "hannibal", "gacey" };

    string GetRandomPassword(string[] passwords)
    {
        System.Random r = new System.Random();
        int rInt = r.Next(0, passwords.Length);
        return passwords[rInt];
    }
}
