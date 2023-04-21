using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reproductor
{
    public partial class Reproductor : Form
    {

        List<Cancion> _cancion;
        public Reproductor()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                AgregarALista(dialog.SafeFileNames.ToList(), dialog.FileNames.ToList());

            }
        }

        private void AgregarALista(List<string> nombres,List<string> rutas)
            { 
                if(_cancion == null)
                    _cancion = new List<Cancion>();

                foreach (var item in nombres)
                {
                    if (!ExistsOnList(item))
                    {
                    _cancion.Add(new Cancion(item, GetRuta(item, rutas)));
                    }
                }

                RefrescarLista();
        }

        private bool ExistsOnList(string cancion)
        { 
            bool exists =  false;
            foreach (var item in _cancion)
            {
                if (item.Nombre == cancion)
                    exists = true;
            }

            return exists;
        }

        private string GetRuta(string fileNombre, List<string> cancionesRuta = null)
        {
            string actualRuta = string.Empty;

            if (cancionesRuta == null)
            {
                foreach (var cancion in _cancion)
                {
                    if (cancion.Nombre == fileNombre)
                    {
                        actualRuta = cancion.Ruta;
                    }
                }
            }
            else
            {
                foreach (var ruta in cancionesRuta)
                {
                    if (ruta.Contains(fileNombre))
                    {
                        actualRuta = ruta;
                    }
                }
            }

            return actualRuta;

        }

        private void listaCanciones_DoubleClick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = GetRuta(listaCanciones.Text);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Cancion cancionBorrar = null;

            foreach (var cancion in _cancion)
            {
                if (cancion.Nombre == listaCanciones.Text)
                {
                    cancionBorrar = cancion;
                }
            }

            if (cancionBorrar != null)
            {
                _cancion.Remove(cancionBorrar);
            }

            RefrescarLista();
        }
        private void RefrescarLista()
        {
            List<string> cancionNombre = new List<string>();

            foreach (var item in _cancion)
            {
                cancionNombre.Add(item.Nombre);
            }
            listaCanciones.DataSource = null;
            listaCanciones.DataSource = cancionNombre;
        }
    }
}
