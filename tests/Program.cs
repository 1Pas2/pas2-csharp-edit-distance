using Pas2.EditDistance;

static void Check(bool condition, string message)
{
    if (!condition)
        throw new Exception(message);
}
static void Fails(Action action)
{
    try
    {
        action();
    }
    catch (Exception)
    {
        return;
    }
    throw new Exception("Expected failure");
}
Check(EditDistance.Between("kitten", "sitting") == 3, "known vector");
Check(EditDistance.Between("", "abc") == 3, "empty");
Check(EditDistance.Between("same", "same") == 0, "identity");
Check(EditDistance.Between("ab", "ba") == 2, "no transposition");
Check(EditDistance.Between("🙂", "") == 2, "UTF16 documented");
Fails(() => EditDistance.Between(null!, "x"));
Console.WriteLine("All checks passed");
