
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearchTreeImplementation
{
    internal class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }
        public class BinarySearchTree
        {
            public Node Root { get; set; }
            public BinarySearchTree()
            {
            }

            public void Add(int value)
            {
                var newNode = new Node(value);
                if(Root == null)
                {
                    Root = newNode;
                } else
                {
                    var current = Root;
                    while(true)
                    {
                        if (newNode.Value < current.Value)
                        {
                            if(current.Left == null)
                            {
                                current.Left = newNode;
                                break;
                            }
                            current = current.Left;
                        } else
                        {
                            if(current.Right == null)
                            {
                                current.Right = newNode;
                                break;
                            }
                            current = current.Right;
                        }
                    }
                    
                }

            }

            public void Find(int value)
            {
                if (Root == null)
                {
                    Console.WriteLine("This tree does'n contain anything");
                    return;
                } else
                {
                    var current = Root;
                    while(current != null)
                    {
                        if (current.Value < value)
                        {
                            current = current.Left;
                        }
                        else if(current.Value > value)
                        {
                            current = current.Right;
                        } 
                        else if(current.Value == value)
                        {
                            Console.WriteLine("Finally found the value at tree: " + value.ToString());
                            break;
                        }
                    }
                    
                }
            }

            public void Remove(int value)
            {
                if(Root == null)
                {
                    Console.WriteLine("There is nothing to remove.");
                    return;
                }
                else
                {
                    var current = Root;
                    Node father = null;
                    while (current != null)
                    {
                        if (current.Value < value)
                        {
                            father = current;
                            current = current.Left;
                        }
                        else if (current.Value > value)
                        {
                            father = current;
                            current = current.Right;
                        }
                        else if (current.Value == value)
                        {
                            if(current.Right == null)
                            {
                                if(father == null)
                                {
                                    Root = current.Left;
                                }
                                else
                                {
                                    if(current.Value < father.Value)
                                    {
                                        father.Left = current.Left;
                                    }
                                    else if (current.Value > father.Value)
                                    {
                                        father.Right = current.Left;
                                    }
                                }
                            } else if (current.Right.Left == null)
                            {
                                current.Right.Left = current.Left;
                                if (father == null)
                                {
                                    Root = current.Right;
                                }
                                else
                                {
                                    if (current.Value < father.Value)
                                    {
                                        father.Left = current.Right;
                                    }
                                    else if (current.Value > father.Value)
                                    {
                                        father.Right = current.Right;
                                    }
                                }
                            } 
                            else
                            {
                                var leftmost = current.Right.Left;
                                var leftmostParent = current.Right;
                                while (leftmost.Left != null)
                                {
                                    leftmostParent = leftmost;
                                    leftmost = leftmost.Left;
                                }                                
                                leftmostParent.Left = leftmost.Right;
                                leftmost.Left = current.Left;
                                leftmost.Right = current.Right;

                                if (father == null)
                                {
                                    Root = leftmost;
                                }
                                else
                                {
                                    if (current.Value < father.Value)
                                    {
                                        father.Left = leftmost;
                                    }
                                    else if (current.Value > father.Value)
                                    {
                                        father.Right = leftmost;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            public void BreadthFirstSearch()
            {
                if (Root == null)
                    return;
                var current = Root;
                List<Node> queue = new List<Node>();
                queue.Add(current);
                while(queue.Count > 0)
                {
                    Console.WriteLine(queue.FirstOrDefault().Value.ToString());
                    current = queue.FirstOrDefault();
                    queue.RemoveAt(0);
                    if (current.Left != null)
                        queue.Add(current.Left);
                    if (current.Right != null)
                        queue.Add(current.Right);
                }                
            }

            public void DFTPreOrder()
            {
                RecursivePreOrder(Root);
            }

            public void DFTInOrder()
            {
                RecursiveInOrder(Root);
            }

            public void DFTPostOrder()
            {
                RecursivePostOrder(Root);
            }

            private void RecursivePreOrder(Node node)
            {
                Console.WriteLine(node.Value.ToString());
                if(node.Left != null)
                    RecursivePreOrder(node.Left);
                if (node.Right != null)
                    RecursivePreOrder(node.Right);
            }

            private void RecursiveInOrder(Node node)
            {                
                if (node.Left != null)
                    RecursivePreOrder(node.Left);
                Console.WriteLine(node.Value.ToString());
                if (node.Right != null)
                    RecursivePreOrder(node.Right);
            }

            private void RecursivePostOrder(Node node)
            {
                if (node.Left != null)
                    RecursivePreOrder(node.Left);                
                if (node.Right != null)
                    RecursivePreOrder(node.Right);
                Console.WriteLine(node.Value.ToString());
            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}
