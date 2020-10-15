using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class BinaryTree
    {
        Node root;
        Balance bal = new Balance();

        // Add value to tree
        public void Add(string value)
        {
            Node newNode = new Node(value);
            if (root == null)
            {
                root = newNode;
            } else
            {
                root = AddRecursive(root, newNode);
            }
        }

        // Cycle through nodes to find empty slot and balance
        private Node AddRecursive(Node current, Node node)
        {
            if (current == null)
            {
                current = node;
                return current;
            } else if (node.value.CompareTo(current.value) < 0)
            {
                current.left = AddRecursive(current.left, node);
                current = bal.BalanceTree(current);
            } else if (node.value.CompareTo(current.value) > 0)
            {
                current.right = AddRecursive(current.right, node);
                current = bal.BalanceTree(current);
            }
            return current;
        }

        // Delete value from tree and balance
        public void Delete(string value)
        {
            root = DeleteNode(root, value);
        }

        private Node DeleteNode(Node current, string value)
        {
            Node parent;
            if (current == null)
            {
                return null;
            } else
            {
                // Left subtree
                if (value.CompareTo(current.value) < 0)
                {
                    current.left = DeleteNode(current.left, value);
                    if (bal.BalanceFactor(current) == -2)
                    {
                        if (bal.BalanceFactor(current.right) <= 0)
                        {
                            current = bal.RotateRR(current);
                        }
                        else
                        {
                            current = bal.RotateRL(current);
                        }
                    }
                }

                // Right subtree
                else if (value.CompareTo(current.value) > 0)
                {
                    current.right = DeleteNode(current.right, value);
                    if (bal.BalanceFactor(current) == 2)
                    {
                        if (bal.BalanceFactor(current.left) >= 0)
                        {
                            current = bal.RotateLL(current);
                        }
                        else
                        {
                            current = bal.RotateLR(current);
                        }
                    }
                }

                // If target is found
                else
                {
                    if (current.right != null)
                    {
                        // Delete in-order successor
                        parent = current.right;

                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }

                        current.value = parent.value;
                        current.right = DeleteNode(current.right, parent.value);

                        // Rebalancing
                        if (bal.BalanceFactor(current) == 2)
                        {
                            if (bal.BalanceFactor(current.left) >= 0)
                            {
                                current = bal.RotateLL(current);
                            }
                            else
                            {
                                current = bal.RotateLR(current);
                            }
                        }
                    } else
                    {
                        return current.left;
                    }
                }
            }

            return current;
        }
    
        // Find value in tree
        public void Find(string value)
        {
            if (FindRecursive(value, root) != null && FindRecursive(value, root).value == value)
            {
                Console.WriteLine("{0} was found!", value);
            } else
            {
                Console.WriteLine("No value found.");
            }
        }

        private Node FindRecursive(string value, Node current)
        {
            if (current.left == null)
            {
                return current;
            }

            if (value.CompareTo(current.value) < 0)
            {
                if (value == current.value)
                {
                    return current;
                } 
                else
                    return FindRecursive(value, current.left);
                
            } else
            {
                if (value.CompareTo(current.value) == 0)
                {
                    return current;
                } else
                    return FindRecursive(value, current.right);
                
            }
        }
        
        // Display all nodes
        public void Display()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty. :(");
                return;
            }

            Console.WriteLine("Root: " + root.value);
            DisplayInOrder(root);
        }

        // Display nodes in specific traversal order
        private void DisplayInOrder(Node current)
        {
            if (current != null)
            {
                //Console.WriteLine("({0})", current.value);
                DisplayInOrder(current.left);
                Console.WriteLine("({0})", current.value);
                DisplayInOrder(current.right);
                //Console.WriteLine("({0})", current.value);
            }
            
        }

    }
}
