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
        List<List<Point>> pointPairs = new List<List<Point>>(); // used to describe where to draw edges between two nodes
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

            display(bt.Root, new Point(515, 30)); // the point at which the graph should start on the screen
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
            label.Text = node.Value.ToString();
            label.AutoSize = true;
            label.Location = staringPoint;
            label.ForeColor = Color.Black;
            label.BackColor = Color.Transparent;
            label.BringToFront();
            label.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.Controls.Add(label);
            label.Show();

            int stretchX = 105; // used to determine how far apart the nodes should be (to prevent overlap)
            if (!isRoot)
            {
                stretchX = 65;
            }

            Debug.WriteLine("NOW PRINTING: " + label.Text);
            if (node.leftChildNode != null) // if a left child node exists, then display it to screen
            {
                Point temp = new Point(staringPoint.X - stretchX, staringPoint.Y + 70); // sets the location to below the parent node and shifting by the stretch factor
                List<Point> tempList = new List<Point> { staringPoint, temp }; 
                pointPairs.Add(tempList); // stores the location of the parent and the new child (to draw a line, later)
                display(node.leftChildNode,temp, false); // recursively call upon the same subroutine to display all of the child node's nodes
            }
            if (node.rightChildNode != null)
            {
                Point temp2 = new Point(staringPoint.X + stretchX, staringPoint.Y + 70);
                List<Point> tempList = new List<Point> { staringPoint, temp2 };
                pointPairs.Add(tempList);
                display(node.rightChildNode,temp2, false);
            }
        }

        private BinaryTree genTree(int size)
        {
            Random rnd = new Random();
            BinaryTree binaryTree = new BinaryTree();
            for (int i = 0; i < size; i = i + 1)
            {
                binaryTree.add(rnd.Next(0,20));
            }
            return binaryTree;
        }

        class Node
        {
            public Node leftChildNode;
            public Node rightChildNode;
            public int Value;
        }

        class BinaryTree
        {
            public Node Root;
            List<int> toReturn = new List<int>();
             
            public bool add(int value)
            {
                Node previous = null;
                Node after = this.Root;

                while (after != null) // until the bottom of the tree has been reached
                {
                    previous = after; // previous becomes the prev iteration's after (or root)
                    if (value < after.Value) // if the new value should be on the left side
                    {
                        after = after.leftChildNode; // after is the node to the left
                    }
                    else if (value > after.Value) /// if the new value should be on the right side
                    {
                        after = after.rightChildNode; // after is the node to the right
                    }
                    else
                    {
                        return false; //value exists
                    }
                }

                Node tempNode = new Node(); tempNode.Value = value;

                if (this.Root == null) // if the tree is unpopulated
                {
                    this.Root = tempNode;
                }
                else
                {
                    if (value < previous.Value) // if the new data is smaller than the bottom item's data then create a new left node
                    {
                        previous.leftChildNode = tempNode;
                    }
                    else
                    {
                        previous.rightChildNode = tempNode; // otherwise create a new right node
                    }
                }
                return true;
            }

            private List<int> TraversePreOrder(Node parent)
            {
                if (parent != null)
                {
                    toReturn.Add(parent.Value);
                    TraversePreOrder(parent.leftChildNode);
                    TraversePreOrder(parent.rightChildNode);
                }
                return toReturn;
            }

            private List<int> TraverseInOrder(Node parent)
            {
                if (parent != null)
                {
                    TraverseInOrder(parent.leftChildNode);
                    toReturn.Add(parent.Value);
                    TraverseInOrder(parent.rightChildNode);
                }
                return toReturn;
            }

            private List<int> TraversePostOrder(Node parent)
            {
                if (parent != null)
                {
                    TraversePostOrder(parent.leftChildNode);
                    TraversePostOrder(parent.rightChildNode);
                    toReturn.Add(parent.Value);
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
