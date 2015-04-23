using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3
{
    public partial class Form1 : Form
    {
        List<Animal> list = new List<Animal>();
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
              if (MessageBox.Show("Do you want to close", "SocOpros", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            { Application.Exit();}
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            animadd anim = new animadd();
            anim.ShowDialog();
            if (anim.spc != "") { 
                String s = "Вид: " + anim.spc + "| " + "Класс: " + anim.kls + "| " + "Вес: " + anim.wdh + "| " + "Места обитания: " + anim.plc;
            animlist.Items.Add(s);
                Animal ob = new Animal(anim.spc, anim.kls, anim.wdh, anim.plc);
            list.Add(ob);
            }
            else
            {
                MessageBox.Show("Введите данные", "Zoo Administration", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            animlist.Items.Clear();
            if (list == null) { return; }
            foreach (Animal animal in list)
            {
                // строка для записи в элемент ListBox  hotellist  
                String spc = animal.species.Trim();
                String kls = animal.klass.Trim();
                String wdh = animal.weight.ToString();
                String plc = animal.places.Trim();
                String str = "Вид: " + spc + "| " + "Класс: " + kls + "| " + "Вес: " + wdh + "| " + "Места обитания: " + plc;
                animlist.Items.Add(str);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            animadd anim = new animadd();
            Animal m = list[animlist.SelectedIndex];
            anim.spc = m.species;
            anim.kls = m.klass;
            anim.wdh = m.weight;
            anim.plc = m.places;
            anim.ShowDialog();
            if (anim.spc != "")
            {
                Animal ob = new Animal(anim.spc, anim.kls, anim.wdh, anim.plc);
                list[animlist.SelectedIndex] = ob;
                animlist.Items[animlist.SelectedIndex] = "Вид: " + anim.spc + "| " + "Класс: " + anim.kls + "| " + "Вес: " + anim.wdh + "| " + "Места обитания: " + anim.plc; 
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int index = animlist.SelectedIndex;
          
        }

        private void animlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
