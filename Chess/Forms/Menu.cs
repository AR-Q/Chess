using System;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "game" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss") + ".txt";
            using (FileStream fs = File.Create(@"../../../Logs/" + path));
            Main main = new Main(this,path);
            main.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Load load = new Load();
            load.Show();
        }
    }
}
