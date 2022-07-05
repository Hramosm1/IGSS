using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultaSalud
{
    public partial class loading : Form
    {
        private List<PersonaViewModel> Persona = new List<PersonaViewModel>();
        BdComun conexion = new BdComun();
        public List<PersonaViewModel> Person
        {
            get
            {
                return this.Persona;
            }
        }
        public loading()
        {
            InitializeComponent();
        }

        private void loading_Load(object sender, EventArgs e)
        {
          //  MiLoading.Load("loader.gif");
            //MiLoading.Location = new Point(this.Width/2-MiLoading.Width/2,
            //    this.Height / 2 - MiLoading.Height / 2);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtDPI.Text.Length > 0)
            {
                PersonaViewModel per = new PersonaViewModel();
                per = conexion.BuscarP(Convert.ToInt64(txtDPI.Text));
                if (per.dpi != 0)
                {
                    Persona.Add(per);
                }
                else
                {
                    alerta.ErrorMensaje("Persona No encontrada");
                }
            }
            else
            {
                alerta.ErrorMensaje("Debe de Ingresar el DPI");
            }
            this.Close();
        }
    }
}
