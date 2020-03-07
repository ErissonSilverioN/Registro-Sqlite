using RegistroConSqlite.BLL;
using RegistroConSqlite.DAL;
using RegistroConSqlite.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistroConSqlite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            idTextBox1.Text = "0";
        }

        private void Limpiar()
        {
            
            nombreTextBox.Text = string.Empty;
            fechaDatePicker.SelectedDate = DateTime.Now;
            idTextBox1.Text = "0";



        }

        private Personas LlenaClase()
        {
            Personas personas = new Personas();
            personas.PersonaId = Convert.ToInt32(idTextBox1.Text);
            personas.Nombre = nombreTextBox.Text;
            personas.Fecha = fechaDatePicker.DisplayDate;

            return personas;


        }


        private void LlenaCampo(Personas personas)
        {
            idTextBox1.Text = Convert.ToString(personas.PersonaId);
            nombreTextBox.Text = personas.Nombre;
            fechaDatePicker.SelectedDate = personas.Fecha;

        }

        private bool ExixteEnLaBaseDeDatos()
        {
            Personas persona = PersonaBLL.Buscar((int)Convert.ToInt32(idTextBox1.Text));
            return (persona != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (nombreTextBox.Text == " ")
            {
                MessageBox.Show(" Llenar Campo!!");
                paso = false;
            }

            return paso;
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {

            Personas personas;
            bool paso = false;

            if (!Validar())
                return;

            personas = LlenaClase();

            if (idTextBox1.Text == "0")
                paso = PersonaBLL.Guardar(personas);

            else
            {
                if (!ExixteEnLaBaseDeDatos())
                {
                    MessageBox.Show("Persona No Existe!!!");
                    return;
                }

                paso = PersonaBLL.Modificar(personas);
            }

            if (paso)
            {
                MessageBox.Show("Se ha Guardado!!");
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se ha Guardado!!");
            }
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;

            int.TryParse(idTextBox1.Text, out id);
            Personas personas = new Personas();

            personas = PersonaBLL.Buscar(id);

            if (personas != null)
            {
                
                LlenaCampo(personas);
            }
            else
            {
                MessageBox.Show("No Se Encontro!!!");
            }
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;

            int.TryParse(idTextBox1.Text, out id);

            if (PersonaBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!!");
                Limpiar();

            }
            else
            {
                MessageBox.Show("No Se Elimino");
            }
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void idTextBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void nombreTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }

        }
    }
}
