using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Reflection;
using System.Diagnostics;
using System.Resources;
using System.Data.SqlClient;

namespace compSciRevisionTool
{
    public partial class formDesign : Form
    {
        public string subColour = "1";
        public string colPassed = "";
        public int userID = 1;

        public formDesign()
        {
            InitializeComponent();
            this.Size = new Size(1029, 574);
        }

        private void formDesign_Load(object sender, EventArgs e)
        {
            userID = getUserID();
        }

        public void hideAllLabels() // this will hide all labels on load
        {
            foreach (Label labels in this.Controls.OfType<Label>())
            {
                labels.Hide();
            }
        }

        public void setDesign(string _subColour) // makes all the features have a uniform design
        {
            subColour = _subColour;
            this.BackColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(subColour), +0.4f); // sets bg colour

            foreach (Button butt in this.Controls.OfType<Button>()) // sets button appearence
            {
                if (butt.GetType() == typeof(Button))
                {
                    butt.BackColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(subColour), +0.8f);
                    butt.FlatStyle = FlatStyle.Flat;
                    butt.FlatAppearance.BorderSize = 0;
                    butt.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }

            foreach (Button butt in this.Controls.OfType<IconButton>()) // button appearence again but for icon buttons
            {
                if (butt.GetType() == typeof(IconButton))
                {
                    butt.BackColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(subColour), +0.8f);
                    butt.FlatStyle = FlatStyle.Flat;
                    butt.FlatAppearance.BorderSize = 0;
                    butt.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }


            foreach (TextBox textboxes in this.Controls.OfType<TextBox>()) // sets textbox appearence
            {
                textboxes.BorderStyle = BorderStyle.None;
                textboxes.BackColor = programColoursClass.ChangeColorBrightness(programColoursClass.getcolour(subColour), +0.9f);

            }
        }

        private static int getUserID()
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Documents\RevisionStorageDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
            string SQLquery = "Select * from currentUserTable where Id= 1";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            int toReturn = Convert.ToInt32(dr["userID"]);

            return toReturn;
        }
    }
}
