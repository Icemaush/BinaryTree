using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class Balance
    {
        // Methods to balance tree after insert and delete
        public Node BalanceTree(Node current)
        {
            int bfactor = BalanceFactor(current);
            if (bfactor > 1)
            {
                if (BalanceFactor(current.left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (bfactor < -1)
            {
                if (BalanceFactor(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }

        public int BalanceFactor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int bfactor = l - r;
            return bfactor;
        }

        public Node RotateRR(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }

        public Node RotateLL(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }

        public Node RotateLR(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }

        public Node RotateRL(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }

        public int Max(int l, int r)
        {
            return l > r ? l : r;
        }

        public int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = Max(l, r);
                height = m + 1;
            }
            return height;
        }

    }
}
