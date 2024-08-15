using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Gestión_de_Eventos_Deportivos.Controllers;
using Sistema_de_Gestión_de_Eventos_Deportivos.Modelos;

namespace Sistema_de_Gestión_de_Eventos_Deportivos.Views
{
    public partial class frm_Eventos : Form
    {
        EventosController eventosController = new EventosController();
        EventosModel eventoModel = new EventosModel();
        public int codigoEvento = 0;

        public frm_Eventos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void frm_Eventos_Load(object sender, EventArgs e)
        {
            cargarLista();

        }

        public void cargarLista()
        {
            lst_eventos.Items.Clear();
            lst_eventos.DataSource = eventosController.todos();
            lst_eventos.DisplayMember = "Nombre";
            lst_eventos.ValueMember = "evento_id";        

        }

        private void lst_eventos_SelectedIndexChanged(object sender, EventArgs e)
        {
           // codigoEvento = Convert.ToInt32(lst_eventos.SelectedValue.ToString());
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            codigoEvento = 0;
            this.Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_Detalle.Text = "";
            lst_eventos.SelectedIndex = -1;
            codigoEvento = 0;
        }

        private void txt_Detalle_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            string respuesta = " ";
            EventosModel evento = new EventosModel
            {
                evento_id = codigoEvento,
                Nombre = txt_Detalle.Text
            };
            try
            {
                if (codigoEvento == 0)
                {
                    respuesta = eventosController.insertar(evento);
                }
                else
                {
                    respuesta = eventosController.actualizar(evento);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            MessageBox.Show("Se guardo con exito");
            codigoEvento = 0;
            txt_Detalle.Enabled = false;
            txt_Detalle.Text = "";

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            EventosModel evento  = new EventosModel { evento_id = codigoEvento};
            DialogResult result = MessageBox.Show("Desea eliminar el evento", "Formulario de eventos", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (eventosController.eliminar(evento) == "ok") 
                {
                    MessageBox.Show("Se elimino con exito");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al eliminar   ");
                }

            }
            else
            {
                MessageBox.Show("El usuario cancelo la eliminacion");
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            txt_Detalle.Enabled = true;
            codigoEvento = Convert.ToInt16(lst_eventos.SelectedValue);

        }

        private void lst_eventos_DoubleClick(object sender, EventArgs e)
        {
            codigoEvento = Convert.ToInt16(lst_eventos.SelectedValue);
            txt_Detalle.Text = lst_eventos.GetItemText(lst_eventos.SelectedItem);
        }
    }
}
