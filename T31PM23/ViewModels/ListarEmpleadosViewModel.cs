using T31PM23.Models;
using T31PM23.Controller;
using T31PM23.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace T31PM23.ViewModels
{
    public class ListarEmpleadosViewModel : BaseViewModels
    {

        private List<Empleado> _ListaPersonas;
        EmpleadoCtrl personaCtrl;

        public List<Empleado> ListaPersonas
        {
            get { return _ListaPersonas; }
            set { 
                _ListaPersonas = value; 
                OnPropertyChanged(); 
            }
        }

        public ListarEmpleadosViewModel() {
            personaCtrl = new EmpleadoCtrl();

            EditarPersonaCommand = new Command<Empleado>(async (Persona) => await EditarPersona(Persona));
            EliminarPersonaCommand = new Command<Empleado>(async (Persona) => await EliminarPersona(Persona));
        }

        private async Task EliminarPersona(Empleado persona)
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert("Advertencia", "¿Esta seguro de eliminar a " + persona.Nombre + "?", "Si", "No");

            if (confirm)
            {
                bool response = await personaCtrl.EliminarEmpleado(persona.Key);
                if (response)
                {
                    await Application.Current.MainPage.DisplayAlert("Advertencia", "Empleado Eliminado Correctamente", "Ok");
                    CargarDatos();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Advertencia", "Se produjo un error al eliminar la persona", "Ok");
                }
            }
        }

        private async Task EditarPersona(Empleado persona)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new AgregarAlumnoView("Editar", persona));
        }

        public async void CargarDatos()
        {
            ListaPersonas = await personaCtrl.ListarEmpleados();
            if (ListaPersonas.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Advertencia", "No hay personas registradas", "Ok");
            }
        }

        public ICommand EditarPersonaCommand { get; set; }
        public ICommand EliminarPersonaCommand { get; set; }
    }
}
