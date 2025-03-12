using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace rezervacije
{
    public partial class Form1 : Form
    {
        private List<rezklasa> rezervacije = new List<rezklasa>();
        private string filePath = "rezervacije.txt";

        public Form1()
        {
            InitializeComponent();
            LoadRezervacije();
        }

        private void LoadRezervacije()
        {
            if (File.Exists(filePath))
            {
                rezervacije = File.ReadAllLines(filePath)
                    .Select(line => rezklasa.FromCsv(line))
                    .ToList();
            }
            RefreshGrid();
        }

        private void SaveRezervacije()
        {
            File.WriteAllLines(filePath, rezervacije.Select(r => r.ToCsv()));
        }


     

        private void button1_Click(object sender, EventArgs e)
        {
            int klijentID, uslugaID;

          
            if (!int.TryParse(textBox1.Text, out klijentID))
            {
                MessageBox.Show("Molimo unesite ispravan Klijent ID (broj).", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (!int.TryParse(textBox2.Text, out uslugaID))
            {
                MessageBox.Show("Molimo unesite ispravan Usluga ID (broj).", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

       
            var novaRezervacija = new rezklasa(
                rezervacije.Count + 1,
                klijentID,
                uslugaID,
                dateTimePicker1.Value,
                dateTimePicker2.Value.TimeOfDay);

            rezervacije.Add(novaRezervacija);
            SaveRezervacije();
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = rezervacije;
        }

       
    }
}
