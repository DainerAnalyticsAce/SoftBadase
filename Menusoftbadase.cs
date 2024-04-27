using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; // libreria para dejar mover el formulario.
using SoftBadase.Entidades;
using System.Diagnostics;


namespace WindowsFormsApp2
{
    public partial class MenúSoftbadase : Form
    {
        public object TxtCedula { get; private set; }

        public MenúSoftbadase()
        {
            InitializeComponent();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] // Codigo para poder mover el formulario.
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        private void btnslide_Click(object sender, EventArgs e)//Codigo para abrir menu hacia el lado.
        {
            if (MenuVertical.Width == 273)
            {
                MenuVertical.Width = 107;
            }
            else
                MenuVertical.Width = 273;
        }


        private void iconcerrar_Click(object sender, EventArgs e)// Cerrar formulario.
        {
            Application.Exit();
        }

        private void iconmaximizar_Click(object sender, EventArgs e)// maxmimizar formulario.
        {
            this.WindowState = FormWindowState.Maximized;
            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void iconrestaurar_Click(object sender, EventArgs e)//restaurar formulario.
        {
            this.WindowState = FormWindowState.Normal;
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = true;
        }

        private void iconminimizar_Click(object sender, EventArgs e)// minimizar formulario.
        {
            this.WindowState = FormWindowState.Minimized;
        }
     

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e) // Cogigo para poder mover el formulario con el panel de la barra de titulo.
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirBoInicio(object AbrirInicio)                   // Creamos la funcion con un objeto para llamar el Formulario de inicio a el panelcontenedor.
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = AbrirInicio as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void AbrirBoRegistrar(object AbrirRegis)                   // Creamos la funcion con un objeto para llamar el Formulario de registro a el panelcontenedor.
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = AbrirRegis as Form;
            fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
           
        }

        public void AbrirBoMovimiento(object AbrirMovi)                    // Creamos la funcion con un objeto para llamar el Formulario de movimientos a el panelcontenedor.
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = AbrirMovi as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void AbrirBoInfoUsuario(object AbrirInfoUsu)   // Creamos la funcion con un objeto para llamar el Formulario de Informacion del ususario a el panelcontenedor.
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = AbrirInfoUsu as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void AbrirBoContraseña(object AbrirContra) // Creamos la funcion con un objeto para llamar el Formulario de contraseña a el panelcontenedor.
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = AbrirContra as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void AbrirBoInformes(object AbrirInformes) // Creamos la funcion con un objeto para llamar el Formulario de INFORMES a el panelcontenedor.
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = AbrirInformes as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void AbrirBoAcercaDe(object AbrirAcerca) // Creamos la funcion con un objeto para llamar el Formulario de acercade a el panelcontenedor.
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = AbrirAcerca as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }



        private void button3_Click(object sender, EventArgs e) //Codigo para abrir el formulario de registrar
        {
            AbrirBoRegistrar(new FormRegistrar());
        }

        private void button2_Click(object sender, EventArgs e) //Codigo para abrir el formulario de movimiento
        {
           AbrirBoMovimiento(new ForMovimientos());
        }

        private void button5_Click(object sender, EventArgs e) //Codigo para abrir el formulario de Informacion del usuario
        {
            AbrirBoInfoUsuario(new FormInfoUsuario());
            
        }

        private void button7_Click(object sender, EventArgs e) //Codigo para abrir el formulario de contraseña
        {
            AbrirBoContraseña(new FormContraseña());
        }

        private void btnInicio_Click(object sender, EventArgs e) //Codigo para abrir el formulario de inicio
        {
            AbrirBoInicio(new FormInicio());
        }

        private void btniformes_Click(object sender, EventArgs e)
        {
            AbrirBoInformes(new FormInformes());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirBoAcercaDe(new FormAcercaDe());
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
            
        }
        
        

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult rsp = MessageBox.Show("¿Desea cerrar el programa?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsp==DialogResult.Yes)
            {
                Close();
                IngreseUsuario nuevo = new IngreseUsuario();
                nuevo.Show();
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCSjRm6JKJfC5HINAkcD7dRg?view_as=subscriber");
        }
    }
     

    
}
