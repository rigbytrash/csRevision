using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compSciRevisionTool
{
    class labelDesign : Label
    {
        string type;
        public labelDesign(string _type = "regular")
        {
            type = _type;
            setDesign(this, type);
        }

        private void setDesign(Label theLabel, string type)
        {

            switch (type)
            {
                case ("title"):
                    this.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    break;
                default:
                    this.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    break;
            }

            this.ForeColor = Color.Black;
            this.MaximumSize = new Size(900, 0);
            this.AutoSize = true;
        }
    }
}
