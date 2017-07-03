using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Marvel.Core.Models.PersonajesModel;
using Marvel.Core.Util;
using Marvel.Core.ViewModels.Base;

namespace Marvel.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Personaje> Personajes = new ObservableRangeCollection<Personaje>();

        /// <summary>
        /// Realiza una llamada que devuelve un <see cref="List{T}" /> where <see cref="{T}"/> : <see cref="Personaje"/>
        /// </summary>
        public async Task GetComics()
        {
            try
            {
                IsBusy = true;

                Metodos.Instance.SetQueryString("characters");

                var personajes = await MarvelService.GetPersonajes(Cadenas.Query);

                Personajes.ReplaceRange(personajes);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}
