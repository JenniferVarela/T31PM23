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
    public partial class ListarAlumnosView : ContentPage
    {
        ListarEmpleadosViewModel listarAlumnosViewModel;
        public ListarAlumnosView()
        {
            InitializeComponent();
            listarAlumnosViewModel = new ListarEmpleadosViewModel();
            BindingContext = listarAlumnosViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listarAlumnosViewModel.CargarDatos();
        }
    }
}