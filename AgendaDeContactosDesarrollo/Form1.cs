namespace AgendaDeContactosDesarrollo
{
    public partial class Form1 : Form
    {
        private bool adding = false;
       List<Contacto> Contactos = new List<Contacto>();
        public Form1()
        {
            InitializeComponent();
            HabilitarControles(false);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            EmptyControls();
            HabilitarControles(true);
            adding = true;

            btnCreate.Enabled = false;
            btnRead.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void EmptyControls()
        {
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtCorreo.Text = String.Empty;
            txtId.Text = Guid.NewGuid().ToString();
            txtTelefono.Text = String.Empty;
            txtEstado.Text = String.Empty;
            txtCiudad.Text = String.Empty;
            txtDireccion.Text = String.Empty;
        }

        private void HabilitarControles(bool enabled)
        {
            txtNombre.Enabled = enabled;
            txtApellido.Enabled = enabled;
            txtCorreo.Enabled = enabled;
            txtId.Enabled = enabled;
            txtTelefono.Enabled = enabled;
            txtEstado.Enabled = enabled;
            txtCiudad.Enabled = enabled;
            txtDireccion.Enabled = enabled;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            if (adding == true)
            {
                var contacto = new Contacto
                {
                    Id = txtId.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Direccion = txtDireccion.Text,
                    Estado = txtEstado.Text,
                    Ciudad = txtCiudad.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    CreatedDate = DateTime.Now
                };

                Contactos.Add(contacto);
                MessageBox.Show("Contacto agregado con éxito");
                EmptyControls();
                HabilitarControles(false);

                btnCreate.Enabled = true;
                btnRead.Enabled = true;
                btnDelete.Enabled = true;

                GetContactos();
            }
            else
            {

            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            GetContactos();
        }

        private void GetContactos()
        {
            dgDatos.DataSource = Contactos;
        }
    }

    public class Contacto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
        public string Correo { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}