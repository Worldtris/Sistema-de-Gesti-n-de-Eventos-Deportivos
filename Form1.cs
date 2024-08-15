using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Gestión_de_Eventos_Deportivos.Views;

namespace Sistema_de_Gestión_de_Eventos_Deportivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            frm_Eventos frmEventos = new frm_Eventos();
            frmEventos.ShowDialog(); 

        }
    }
}
