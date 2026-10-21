namespace Pas2.EditDistance;

public static class EditDistance
{
    public static int Between(string left, string right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);
        if (left.Length < right.Length)
            (left, right) = (right, left);
        if (right.Length == 0)
            return left.Length;
        int[] previous = Enumerable.Range(0, right.Length + 1).ToArray(),
            current = new int[right.Length + 1];
        for (int i = 1; i <= left.Length; i++)
        {
            current[0] = i;
            for (int j = 1; j <= right.Length; j++)
                current[j] = Math.Min(
                    Math.Min(current[j - 1] + 1, previous[j] + 1),
                    previous[j - 1] + (left[i - 1] == right[j - 1] ? 0 : 1)
                );
            (previous, current) = (current, previous);
        }
        return previous[right.Length];
    }
}
