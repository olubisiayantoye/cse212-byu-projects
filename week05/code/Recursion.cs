using System.Collections;
using System.Diagnostics;

public static class Recursion
{
    // Problem 1
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    // Problem 2
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        foreach (char c in letters)
        {
            string remaining = letters.Replace(c.ToString(), "");
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    // Problem 3
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (remember.ContainsKey(s))
            return remember[s];

        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    // Problem 4
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int idx = pattern.IndexOf('*');
        if (idx == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern[..idx] + "0" + pattern[(idx + 1)..], results);
        WildcardBinary(pattern[..idx] + "1" + pattern[(idx + 1)..], results);
    }

    // Problem 5
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // If move invalid, stop
        if (!maze.IsValidMove(currPath, x, y))
            return;

        // Add current position
        currPath.Add((x, y));

        // If end reached, record path
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Explore neighbors
        SolveMaze(results, maze, x + 1, y, new List<ValueTuple<int, int>>(currPath)); // Right
        SolveMaze(results, maze, x - 1, y, new List<ValueTuple<int, int>>(currPath)); // Left
        SolveMaze(results, maze, x, y + 1, new List<ValueTuple<int, int>>(currPath)); // Down
        SolveMaze(results, maze, x, y - 1, new List<ValueTuple<int, int>>(currPath)); // Up
    }
}
