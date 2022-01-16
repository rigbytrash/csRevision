using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Resources;

namespace compSciRevisionTool
{
    public partial class QbinaryTree : formDesignForQuestionForms
    {
        // acknowledgement that some of this code was insired by http://csharpexamples.com/c-binary-search-tree-implementation/
        // modifications were made but for the most part, not much can be changed

        Graphics g;
        Point testPoint = new Point(0, 10);
        List<List<Point>> pointPairs = new List<List<Point>>();
        BinaryTree bt;

        public QbinaryTree()
        {
            InitializeComponent();
            theProgressBar.Hide();
            diffLabel2.Hide();
            conseqLabel.Hide();
        }
        private void QbinaryTree_Load(object sender, EventArgs e)
        {
            bt = genTree(5);
            List<int> temp = bt.traverseInOrder(bt.Root);
            Debug.WriteLine("In Order:");

            foreach (int i in temp)
            {
                Debug.WriteLine(i);
            }

            display(bt.Root, new Point(515, 30));
            print();
        }

        private void print()
        {
            label4.Text = label5.Text = label6.Text = "";
            label1.Text = "Pre-Order:";
            List<int> temp = bt.traversePreOrder(bt.Root);
            foreach (int i in temp)
            {
                label4.Text += "  " + i;
            }

            label2.Text = "In-Order:";
            temp = bt.traverseInOrder(bt.Root);
            foreach (int i in temp)
            {
                label6.Text += "  " + i;
            }

            label3.Text = "Post-Order:";
            temp = bt.traversePostOrder(bt.Root);
            foreach (int i in temp)
            {
                label5.Text += "  " + i;
            }
        }

        private void display(Node node, Point staringPoint, bool isRoot = true) // must enter the root node when starting
        {
            testPoint = staringPoint;
            //drawLine(staringPoint, new Point(0, 0));
            Label label = new Label();
            label.Text = node.Data.ToString();
            label.AutoSize = true;
            label.Location = staringPoint;
            label.ForeColor = Color.Black;
            label.BackColor = Color.Transparent;
            label.BringToFront();
            label.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.Controls.Add(label);
            label.Show();

            int stretchX = 105;
            if (!isRoot)
            {
                stretchX = 65;
            }

            Debug.WriteLine("NOW PRINTING: " + label.Text);
            if (node.leftNode != null)
            {
                Point temp = new Point(staringPoint.X - stretchX, staringPoint.Y + 70);
                List<Point> tempList = new List<Point> { staringPoint, temp };
                pointPairs.Add(tempList);
                display(node.leftNode,temp, false);
            }
            if (node.rightNode != null)
            {
                Point temp2 = new Point(staringPoint.X + stretchX, staringPoint.Y + 70);
                List<Point> tempList = new List<Point> { staringPoint, temp2 };
                pointPairs.Add(tempList);
                display(node.rightNode,temp2, false);
            }
        }

        private BinaryTree genTree(int size)
        {
            Random rnd = new Random();
            BinaryTree binaryTree = new BinaryTree();
            for (int i = 0; i < size; i = i + 1)
            {
                binaryTree.Add(rnd.Next(0,20));
            }
            return binaryTree;
        }

        class Node
        {
            public Node leftNode;
            public Node rightNode;
            public int Data;
        }

        class BinaryTree
        {
            public Node Root;
            List<int> toReturn = new List<int>();

            public bool Add(int value)
            {
                Node before = null;
                Node after = this.Root;

                while (after != null) // until the bottom of the tree has been reached
                {
                    before = after; // before becomes the prev iteration's after (or root)
                    if (value < after.Data) // if the new value should be on the left side
                    {
                        after = after.leftNode; // after is the node to the left
                    }
                    else if (value > after.Data) /// if the new value should be on the right side
                    {
                        after = after.rightNode; // after is the node to the right
                    }
                    else
                    {
                        return false; //value exists
                    }
                }

                Node newNode = new Node();
                newNode.Data = value;

                if (this.Root == null) // if the tree is unpopulated
                {
                    this.Root = newNode;
                }
                else
                {
                    if (value < before.Data) // if the new data is smaller than the bottom item's data then create a new left node
                    {
                        before.leftNode = newNode;
                    }
                    else
                    {
                        before.rightNode = newNode; // otherwise create a new right node
                    }
                }
                return true;
            }

            public Node Find(int value)
            {
                return this.Find(value, this.Root);
            }

            public void Remove(int value)
            {
                this.Root = Remove(this.Root, value);
            }

            private Node Remove(Node parent, int key)
            {
                if (parent == null) // error handling
                {
                    return parent;
                }

                if (key < parent.Data)
                {
                    parent.leftNode = Remove(parent.leftNode, key);
                }
                else if (key > parent.Data)
                {
                    parent.rightNode = Remove(parent.rightNode, key);
                }

                else // once the key/value is equal to the parent's - it means it is what is wanting deleted
                {
                    
                    if (parent.leftNode == null) // if there is no left node, return the right node and vice verca
                    {
                        return parent.rightNode;
                    }
                    else if (parent.rightNode == null)
                    {
                        return parent.leftNode;
                    }

                    parent.Data = MinValue(parent.rightNode); // if the node has two children, bring up the smallest from the right side and then
                                                               // delete the duplicate (old) value 
                    parent.rightNode = Remove(parent.rightNode, parent.Data);
                }
                return parent;
            }

            private int MinValue(Node node)
            {
                int minv = node.Data;
                while (node.leftNode != null) // keep searching through left nodes, return the leftmost node's value
                {
                    minv = node.leftNode.Data;
                    node = node.leftNode;
                }
                return minv;
            }

            private Node Find(int value, Node parent)
            {
                if (parent != null)
                {
                    if (value == parent.Data)
                    {
                        return parent;
                    }
                    if (value < parent.Data) // if the value is to the left, call the sub again with the left node
                    {
                        return Find(value, parent.leftNode);
                    }
                    else
                    {
                        return Find(value, parent.rightNode);
                    }
                }
                return null; //default case
            }

            public int GetTreeDepth()
            {
                return this.GetTreeDepth(this.Root);
            }

            private int GetTreeDepth(Node parent)
            {
                return parent == null ? 0 : Math.Max(GetTreeDepth(parent.leftNode), GetTreeDepth(parent.rightNode)) + 1;
            }

            private List<int> TraversePreOrder(Node parent)
            {
                if (parent != null)
                {
                    toReturn.Add(parent.Data);
                    TraversePreOrder(parent.leftNode);
                    TraversePreOrder(parent.rightNode);
                }
                return toReturn;
            }

            private List<int> TraverseInOrder(Node parent)
            {
                if (parent != null)
                {
                    TraverseInOrder(parent.leftNode);
                    toReturn.Add(parent.Data);
                    TraverseInOrder(parent.rightNode);
                }
                return toReturn;
            }

            private List<int> TraversePostOrder(Node parent)
            {
                if (parent != null)
                {
                    TraversePostOrder(parent.leftNode);
                    TraversePostOrder(parent.rightNode);
                    toReturn.Add(parent.Data);
                }
                return toReturn;
            }

            public List<int> traversePostOrder(Node parent)
            {
                toReturn.Clear();
                return TraversePostOrder(parent);
            }

            public List<int> traverseInOrder(Node parent)
            {
                toReturn.Clear();
                return TraverseInOrder(parent);
            }

            public List<int> traversePreOrder(Node parent)
            {
                toReturn.Clear();
                return TraversePreOrder(parent);
            }
        }

        public void drawLine(Point point1, Point point2)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            g.DrawLine(blackPen, point1, point2);
        }

        private void genCirlce(Point p)
        {
            PictureBox circle = new PictureBox();
            circle.BackColor = Color.Transparent;
            ResourceManager tempResourceManager = all_Images.ResourceManager; // new resource manager to grab images from resX file
            var image = (Bitmap)tempResourceManager.GetObject("circle2"); // gets the correct image by removing the first letter from the filepath as it is a space
            circle.Image = utils.ScaleImage(image, 60, 60);
            circle.SizeMode = PictureBoxSizeMode.AutoSize;
            circle.Location = new Point(p.X - 10, p.Y - 20);
            this.Controls.Add(circle);
            circle.Show();
        }

        private void bgPanel_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            foreach (List<Point> pointList in pointPairs)
            {
                Point p1 = pointList[0];
                Point p2 = pointList[1];
                p1 = new Point(p1.X + 15, p1.Y + 15);
                p2 = new Point(p2.X + 15, p2.Y + 15);

                drawLine(p1, p2);
            }

            foreach (Control cntrl in this.Controls)
            {
                if (cntrl.GetType() == typeof(Label))
                {
                    genCirlce(cntrl.Location);
                }
            }
            bgPanel.SendToBack();
        }
    }
}
