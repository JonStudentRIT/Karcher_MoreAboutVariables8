using System;

namespace MoreAboutVariables8
{
    /* Author: Jonathan Karhcher
     * Purpose: Replace every instance of the word no in a user endered phrase with the word yes
     * Restrictions: None
     */
    class Program
    {
        /* Method: Main
         * Purpose: Replace every instance on the word no with yes within a phrase
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // store the users input
            string input = "";
            // prompt the user for input
            Console.WriteLine("Please enter a phrase.");
            // store the users input
            input = Console.ReadLine();
            // variable for string manipulation
            string temp = "";
            // variable for char index manipulation
            int tempItterator = 0;
            // what string in split string am i reviewing
            int whatString = 0;
            // seperate the string based on the spaces
            String[] split = input.Split(' ');
            foreach(string s in split)
            {
                // if the string is long enough to contain a no
                if(s.Length == 2)
                {
                    // see if it contains a no
                    if (((s[0] == 'N') || (s[0] == 'n')) && (s[1] == 'o'))
                    {
                        // if it does then replace the word with the correct capitalization
                        if (s[0] == 'N')
                        {
                            split[whatString] = "Yes";
                        }
                        if (s[0] == 'n')
                        {
                            split[whatString] = "yes";
                        }
                    }  
                }
                // if the string is long enough for a no to be preceded by or followed by puctuation
                if (s.Length == 3)
                {
                    // see if the first character is a punctuation mark
                    if (Char.IsPunctuation(s[0]) && ((s[1] == 'N') || (s[1] == 'n')) && (s[2] == 'o'))
                    {
                        // if it is then check for a no after the punctuation and replace the word with the correct capitalization
                        if (s[1] == 'N' && s[2] == 'o')
                        {
                            split[whatString] = s[0] + "Yes";
                        }
                        if (s[1] == 'n' && s[2] == 'o')
                        {
                            split[whatString] = s[0] + "yes";
                        }
                    }
                    // see if the last character is a punctuation mark
                    else if (((s[0] == 'N') || (s[0] == 'n')) && (s[1] == 'o') && Char.IsPunctuation(s[2]))
                    {
                        // see if it contains a no followed by punctuation and replace the word with the correct capitalization
                        if (s[0] == 'N')
                        {
                            split[whatString] = "Yes" + s[2];
                        }
                        if (s[0] == 'n')
                        {
                            split[whatString] = "yes" + s[2];
                        }
                    }
                }
                // if the string is long enough for a no to be preceded and followed by puctuation
                if (s.Length > 3)
                {
                    // search through an unknown amount of punctuation preceding a letter
                    for (int x = 0; x < s.Length; x++)
                    {
                        if (Char.IsPunctuation(s[x]))
                        {
                            for (;tempItterator < s.Length; tempItterator++)
                            {
                                // if it is a puntuation then add it to the temperary string
                                if (Char.IsPunctuation(s[tempItterator]))
                                {
                                    temp = temp + s[tempItterator];
                                }
                                // when we find a letter then exit the loop
                                else
                                {
                                    break;
                                }
                            }
                            // check for a no that is both preceded and followed by punctuation and replace the word with the correct capitalization
                            if (s[tempItterator] == 'N' && s[tempItterator + 1] == 'o' && Char.IsPunctuation(s[tempItterator + 2]))
                            {
                                temp = temp + "Yes";
                                tempItterator += 2;
                            }
                            if (s[tempItterator] == 'n' && s[tempItterator + 1] == 'o' && Char.IsPunctuation(s[tempItterator + 2]))
                            {
                                temp = temp + "yes";
                                tempItterator += 2;
                            }
                            // add all remaining punctuation
                            for (int i = tempItterator; i < s.Length; i++)
                            {
                                temp = temp + s[i];
                            }
                            // assign the temperary string to the current string being reviewed
                            split[whatString] = temp;
                            // exit the x loop
                            break;
                        }
                    }
                }
                // update the string index being refrenced
                whatString++;
                // clear the temperary string
                temp = "";
                // reset the temperary ittereator
                tempItterator = 0;
            }
            // connect all of the strings in split and deisplay them
            Console.WriteLine(string.Join(" ", split));
        }
    }
}
