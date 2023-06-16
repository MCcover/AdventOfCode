namespace AOC.Helpers;

public class MenuHelper {

    private static int _OptionsPerLine { get; set; } = 1;
    private static int _StartX { get; set; } = 0;
    private static int _StartY { get; set; } = 0;

    public static void SetVariables(int optionsPerLine, int startX, int startY) {
        _OptionsPerLine = optionsPerLine;
        _StartX = startX;
        _StartY = startY;
    }

    public static void ResetVariables() {
        _OptionsPerLine = 1;
        _StartX = 0;
        _StartY = 0;
    }

    public static int MultipleChoice(bool canCancel, params string[] options) {
        const int spacingPerLine = 14;

        int currentSelection = 0;

        ConsoleKey key;

        Console.CursorVisible = false;

        do {
            for (int i = 0; i < options.Length; i++) {
                Console.SetCursorPosition(_StartX + i % _OptionsPerLine * spacingPerLine, _StartY + i / _OptionsPerLine);

                if (i == currentSelection)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.Write(options[i]);

                Console.ResetColor();
            }

            key = Console.ReadKey(true).Key;

            switch (key) {
                case ConsoleKey.LeftArrow: {
                        if (currentSelection % _OptionsPerLine > 0)
                            currentSelection--;
                        break;
                    }
                case ConsoleKey.RightArrow: {
                        if (currentSelection % _OptionsPerLine < _OptionsPerLine - 1)
                            currentSelection++;
                        break;
                    }
                case ConsoleKey.UpArrow: {
                        if (currentSelection >= _OptionsPerLine)
                            currentSelection -= _OptionsPerLine;
                        break;
                    }
                case ConsoleKey.DownArrow: {
                        if (currentSelection + _OptionsPerLine < options.Length)
                            currentSelection += _OptionsPerLine;
                        break;
                    }
                case ConsoleKey.Escape: {
                        if (canCancel)
                            return -1;
                        break;
                    }
            }
        } while (key != ConsoleKey.Enter);

        Console.CursorVisible = true;

        return currentSelection;
    }
}