﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.Forms
{
    public partial class End : Form
    {
        public End(Classes.Color color)
        {
            InitializeComponent();
            if (color == Classes.Color.White)
            {
                label1.Text = "White Win";
            }
            else
            {
                label1.Text = "Black Win";
            }
        }
        
    }
}
