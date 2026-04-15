using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeteriaInventario
{
    public partial class frmInventario : Form
    {
        public frmInventario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && txtPrecio.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            double valor;

            if (double.TryParse(txtPrecio.Text, out valor))
            {
                // Formatear como moneda
                txtPrecio.Text = valor.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
            }
            else
            {
                MessageBox.Show("Borre el contenido del texto e ingrese un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string producto = txtProducto.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();

            if (string.IsNullOrEmpty(producto))
            {
                MessageBox.Show("El campo Producto no puede estar vacío", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProducto.Focus();
                return;
            }

            if (producto.Length <= 10)
            {
                MessageBox.Show("El texto debe tener más de 10 caracteres", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProducto.Focus();
                return;
            }

            if (string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("El campo Descripción no puede estar vacío", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }

            if (descripcion.Length <= 10)
            {
                MessageBox.Show("El texto debe tener más de 10 caracteres", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }

            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una opción", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
            }

            MessageBox.Show("Producto agregado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            // Limpiar TextBox
            txtProducto.Clear();
            txtPrecio.Clear();
            txtDescripcion.Clear();

            // Limpiar ComboBox
            cmbCategoria.SelectedIndex = -1;

            // Regresar foco al primer campo
            txtProducto.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}
