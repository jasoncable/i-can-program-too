public ITreeNode<T> Parent { get; set; }
public T Value { get; private set; }
public ICollection<ITreeNode<T>> Children { get; private set; } 
    = new List<ITreeNode<T>>();
public void AddChild(ITreeNode<T> treeNode)
{
    treeNode.Parent = this;
    Children.Add(treeNode);
}