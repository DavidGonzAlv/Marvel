using System;
using System.Collections.Specialized;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Marvel.Android.Activities.Base;
using Marvel.Core.Models.PersonajesModel;
using Marvel.Core.Util;
using Marvel.Core.ViewModels.Main;
using FFImageLoading;
using FFImageLoading.Views;


namespace Marvel.Android.Activities
{
    [Activity(MainLauncher = false, Theme = "@style/MyTheme.Base", ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustPan)]
    public class MainActivity : BaseActivity<MainViewModel>
    {
        #region Propiedades

        private RecyclerView RecyclerViewComics { get; set; }
        private LinearLayoutManager LinearLayoutManager { get; set; }
        private RecyclerViewAdapterComic RecyclerViewAdapterComic { get; set; }

        #endregion

        #region Metodos

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            RecyclerViewComics = FindViewById<RecyclerView>(Resource.Id.recyclerViewComics);
            RecyclerViewComics.SetLayoutManager(LinearLayoutManager = new LinearLayoutManager(this));
            RecyclerViewComics.SetAdapter(RecyclerViewAdapterComic = new RecyclerViewAdapterComic(ViewModel.Personajes));

            ViewModel.Personajes.CollectionChanged += PersonajesOnCollectionChanged;

        }
        public override void OnTrimMemory([GeneratedEnum] TrimMemory level)
        {
            ImageService.Instance.InvalidateMemoryCache();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            base.OnTrimMemory(level);
        }
        private void PersonajesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            RunOnUiThread(() =>
            {
                RecyclerViewAdapterComic.NotifyDataSetChanged();
            });
        }
        #endregion
    }

    #region RecyclerViewAdapterComic & ViewHolderComic
    public class RecyclerViewAdapterComic : RecyclerView.Adapter
    {
        private readonly ObservableRangeCollection<Personaje> Personajes;

        public RecyclerViewAdapterComic(ObservableRangeCollection<Personaje> personajes)
        {
            this.Personajes = personajes;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var personaje = Personajes[position];
            var personajeHolder = holder as ViewHolderComic;

            if (personajeHolder != null && personaje != null)
            {
                personajeHolder.NombrePersonaje.Text = personaje.name;
                

                ImageService.Instance
                  .LoadUrl(personaje.thumbnail.rutaImagen)
                  .Into(personajeHolder.ImagenPersonaje);
                //personajeHolder.ImagenPersonaje.SetImageBitmap(ImagenService.Instance);

            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var item = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_personaje, parent, false);
            return new ViewHolderComic(item);

        }

        public override int ItemCount => Personajes.Count;
    }

    public class ViewHolderComic : RecyclerView.ViewHolder
    {
        public TextView NombrePersonaje { get; set; }
        public ImageViewAsync ImagenPersonaje { get; set; }
      

        public ViewHolderComic(View itemView) : base(itemView)
        {
            NombrePersonaje = itemView.FindViewById<TextView>(Resource.Id.nombrePersonaje);
            ImagenPersonaje = itemView.FindViewById<ImageViewAsync>(Resource.Id.imagenPersonaje);
           ;
        }
    }
    #endregion
}

