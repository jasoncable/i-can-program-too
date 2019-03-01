using System;
using System.Collections;
using System.Collections.Generic;

namespace SampleConsoleApp.Chapter14
{
    public static class Tester
    {
        public static void RunMe()
        {

        }
    }   

    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-interfaces
    public class Category : IIdentifiable
    {
        public Category() { }
        public Category(string name) : this()
        {
            Name = name;
        }
        public string Name { get; set; }
        public Guid Id { get; private set; } = new Guid();
        public override string ToString()
        {
            return $"Id: {Id} ~ Name: {Name}";
        }
    }

    public class TreeNode<T> : ITreeNode<T>
        where T : class, IIdentifiable, new()
    {
        public TreeNode(T objOfT)
        {
            this.Value = objOfT;
        }

        public ITreeNode<T> Parent { get; set; }
        public T Value { get; private set; }
        public ICollection<ITreeNode<T>> Children { get; private set; } 
            = new List<ITreeNode<T>>();
        public void AddChild(ITreeNode<T> treeNode)
        {
            treeNode.Parent = this;
            Children.Add(treeNode);
        }
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

        public void RecurseAndPerformAction(Action<T> action)
        {
            action(this.Value);
            foreach(var child in Children)
                child.RecurseAndPerformAction(action);
        }
    }

    public interface IIdentifiable
    {
        string Name { get; }
        Guid Id { get; }
    }

    public interface ITreeNode<T> : IEnumerable<ITreeNode<T>>, IEnumerable
    {
        T Value { get; }
        ITreeNode<T> Parent { get; set; }
        ICollection<ITreeNode<T>> Children { get; }
        void AddChild(ITreeNode<T> treeNode);
        void RecurseAndPerformAction(Action<T> action);
    }

    public static class TreeRecursor
    {
        // breadth-first search...
        // courtesy of: Stack Overflow user Jon Skeet
        // license: CC-BY-SA
        // https://stackoverflow.com/questions/2012274/how-to-unroll-a-recursive-structure
        public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> subjects,
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
}
