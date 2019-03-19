public IEnumerator<ITreeNode<T>> GetEnumerator()
{
    return RecurseNodes(this).GetEnumerator();
}

IEnumerator IEnumerable.GetEnumerator()
{
    return this.GetEnumerator();
}

private IEnumerable<ITreeNode<T>> RecurseNodes(ITreeNode<T> node)
{
    yield return node;

    foreach(var child in node.Children)
    {
        foreach (var childNode in RecurseNodes(child))
        {
            yield return childNode;
        }
    }
}