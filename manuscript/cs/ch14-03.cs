public interface ITreeNode<T> : IEnumerable<ITreeNode<T>>, IEnumerable
{
    T Value { get; }
    ITreeNode<T> Parent { get; set; }
    ICollection<ITreeNode<T>> Children { get; }
    void AddChild(ITreeNode<T> treeNode);
    void RecurseAndPerformAction(Action<T> action);
}