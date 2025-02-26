class Calculator
{
    /// Converts a string of digits into corresponding letters.
    public static string OldPhonePad(string input)
    {
      string result = "";

      if (input.Length == 0) {
        return result;
      }

      char currentChar = input[0];
      int currentCharIndex = 0;

      for (int i = 1; i < input.Length; i++)
      {
        char c = input[i];

        if (char.IsDigit(c) && currentChar == c) {
          currentCharIndex++;
        } else {
          // Add new alphabetical letter when previous character is number
          if (char.IsDigit(currentChar)) {
            result = $"{result}{GetOldPhonePadAlphabeticalLetter(currentChar, currentCharIndex)}";
          }

          // Remove last text
          if (c == '*') {
            result = result[..^1];
          }

          currentCharIndex = 0;
        }

        currentChar = c;
      }

      return result;
    }

    /// Maps a phone number digit to its corresponding alphabetical character.
    private static char GetOldPhonePadAlphabeticalLetter(char numberChar, int length)
    {
      string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      int alphabeticalIndex = (int.Parse(numberChar.ToString()) - 2) * 3 + length;

      return alphabet[alphabeticalIndex];
    }

    /// Validates the input string for an old phone pad format (numbers[2-9], spaces, '*', and ending with '#').
    public static bool ValidateOldPhonePadInput(string input)
    {
      if (input.Length < 2 || input[^1] != '#' || !char.IsDigit(input[0])) {
        return false;
      }

      for (int i = 0; i < input.Length; i++)
      {
        char c = input[i];

        if ((c >= '2' && c <= '9') || c == ' ' || c == '*') {
          continue;
        } else if (c == '#' && i == input.Length - 1) {
          continue;
        }

        return false;
      }

      return true;
    }
}