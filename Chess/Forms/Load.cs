using Chess.Classes;
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
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
            List<FilePath> list = new List<FilePath>();
            try
            {
                // Only get files that begin with the letter "c".
                string[] dirs = Directory.GetFiles(@"../../../Logs/","game*");
                int x = 1;
                foreach (string dir in dirs)
                {
                    list.Add(new FilePath()
                    {
                        Id = x,
                        Path = dir.Split("/").Last().ToString()
                    });
                    x++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            dataGridView.DataSource = list.Select(x => new
            {
                Id = x.Id,
                Name = x.Path
            }).ToList();

            dataGridView.Columns[1].Width = 500;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selected = dataGridView.SelectedRows[0].Cells[1].Value.ToString();

            Main main = new Main(selected);
            main.Show();
        }
    }
}
