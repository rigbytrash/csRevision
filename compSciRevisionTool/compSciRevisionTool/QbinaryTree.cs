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
    public partial class QbinaryTree : formDesign
    {
        Graphics g;
        Point testPoint = new Point(0, 10);
        List<List<Point>> pointPairs = new List<List<Point>>();
        BinaryTree bt;

        public QbinaryTree()
        {
            InitializeComponent();
            theProgressBar.Hide();
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

            //PictureBox circle = new PictureBox();
            //circle.BackColor = Color.Transparent;
            //ResourceManager tempResourceManager = all_Images.ResourceManager; // new resource manager to grab images from resX file
            //var image = (Bitmap)tempResourceManager.GetObject("circle2"); // gets the correct image by removing the first letter from the filepath as it is a space
            //circle.Image = utils.ScaleImage(image, 60, 60);
            //circle.SizeMode = PictureBoxSizeMode.AutoSize;
            //circle.Location = new Point(staringPoint.X - 10, staringPoint.Y - 20);
            //this.Controls.Add(circle);
            //circle.Show();

            int stretchX = 105;
            if (!isRoot)
            {
                stretchX = 65;
            }


            Debug.WriteLine("NOW PRINTING: " + label.Text);
            if (node.LeftNode != null)
            {
                Point temp = new Point(staringPoint.X - stretchX, staringPoint.Y + 70);
                List<Point> tempList = new List<Point> { staringPoint, temp };
                pointPairs.Add(tempList);
                display(node.LeftNode,temp, false);
            }
            if (node.RightNode != null)
            {
                Point temp2 = new Point(staringPoint.X + stretchX, staringPoint.Y + 70);
                List<Point> tempList = new List<Point> { staringPoint, temp2 };
                pointPairs.Add(tempList);
                display(node.RightNode,temp2, false);
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
            public Node LeftNode;
            public Node RightNode;
            public int Data;
        }

        class BinaryTree
        {
            public Node Root;
            List<int> toReturn = new List<int>();

            public bool Add(int value)
            {
                Node before = null, after = this.Root;

                while (after != null)
                {
                    before = after;
                    if (value < after.Data) //Is new node in left tree? 
                        after = after.LeftNode;
                    else if (value > after.Data) //Is new node in right tree?
                        after = after.RightNode;
                    else
                    {
                        //Exist same value
                        return false;
                    }
                }

                Node newNode = new Node();
                newNode.Data = value;

                if (this.Root == null)//Tree ise empty
                    this.Root = newNode;
                else
                {
                    if (value < before.Data)
                        before.LeftNode = newNode;
                    else
                        before.RightNode = newNode;
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
                if (parent == null) return parent;

                if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
                else if (key > parent.Data)
                    parent.RightNode = Remove(parent.RightNode, key);

                // if value is same as parent's value, then this is the node to be deleted  
                else
                {
                    // node with only one child or no child  
                    if (parent.LeftNode == null)
                        return parent.RightNode;
                    else if (parent.RightNode == null)
                        return parent.LeftNode;

                    // node with two children: Get the inorder successor (smallest in the right subtree)  
                    parent.Data = MinValue(parent.RightNode);

                    // Delete the inorder successor  
                    parent.RightNode = Remove(parent.RightNode, parent.Data);
                }

                return parent;
            }

            private int MinValue(Node node)
            {
                int minv = node.Data;

                while (node.LeftNode != null)
                {
                    minv = node.LeftNode.Data;
                    node = node.LeftNode;
                }

                return minv;
            }

            private Node Find(int value, Node parent)
            {
                if (parent != null)
                {
                    if (value == parent.Data) return parent;
                    if (value < parent.Data)
                        return Find(value, parent.LeftNode);
                    else
                        return Find(value, parent.RightNode);
                }

                return null;
            }

            public int GetTreeDepth()
            {
                return this.GetTreeDepth(this.Root);
            }

            private int GetTreeDepth(Node parent)
            {
                return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
            }

            private List<int> TraversePreOrder(Node parent)
            {
                if (parent != null)
                {
                    toReturn.Add(parent.Data);
                    TraversePreOrder(parent.LeftNode);
                    TraversePreOrder(parent.RightNode);
                }
                return toReturn;
            }

            private List<int> TraverseInOrder(Node parent)
            {
                if (parent != null)
                {
                    TraverseInOrder(parent.LeftNode);
                    toReturn.Add(parent.Data);
                    TraverseInOrder(parent.RightNode);
                }
                return toReturn;
            }

            private List<int> TraversePostOrder(Node parent)
            {
                if (parent != null)
                {
                    TraversePostOrder(parent.LeftNode);
                    TraversePostOrder(parent.RightNode);
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
