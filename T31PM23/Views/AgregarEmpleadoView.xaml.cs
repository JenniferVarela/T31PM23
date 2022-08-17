using T31PM23.Models;
using T31PM23.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace T31PM23.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarAlumnoView : ContentPage
    {
        public AgregarAlumnoView(string opcion = "Guardar", Empleado persona = null)
        {
            InitializeComponent();
            if (opcion.Equals("Guardar"))
            {
                BindingContext = new AgregarEmpleadoViewModel(imagePersona, opcion, persona);
            }
            else
            {
                BindingContext = new AgregarEmpleadoViewModel(imagePersona2, opcion, persona);
            }
        }
    }
}