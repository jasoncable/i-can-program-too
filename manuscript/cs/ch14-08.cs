public IEnumerator<ITreeNode<T>> GetEnumerator()
{
    yield return this;
    foreach (var node in this.SelectRecursive((arg) => arg.Children))
        yield return node;
}

IEnumerator IEnumerable.GetEnumerator()
{
    return this.GetEnumerator();
}
// ---------- //
public static class TreeRecursor
{
    // breadth-first search...
    // courtesy of: Stack Overflow user Jon Skeet
    // license: CC-BY-SA
    // https://stackoverflow.com/questions/2012274/how-to-unroll-a-recursive-structure
    public static IEnumerable<T> SelectRecursive<T>(
        this IEnumerable<T> subjects,
        Func<T, IEnumerable<T>> selector)
    {
        if (subjects == null)
        {
            yield break;
        }

        Queue<T> stillToProcess = new Queue<T>(subjects);

        while (stillToProcess.Count > 0)
        {
            T item = stillToProcess.Dequeue();
            yield return item;
            foreach (T child in selector(item))
            {
                stillToProcess.Enqueue(child);
            }
        }
    }
}