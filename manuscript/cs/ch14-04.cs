public class TreeNode<T> : ITreeNode<T>, 
    IEnumerable, IEnumerable<ITreeNode<T>>
    where T : class, IIdentifiable, new()
{
}