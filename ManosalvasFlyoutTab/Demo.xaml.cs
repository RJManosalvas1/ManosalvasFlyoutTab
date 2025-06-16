using ManosalvasFlyoutTab.NewFolder;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace ManosalvasFlyoutTab;

public partial class Demo : ContentPage
{
    private ManejoArchivosRepository _repo;
    public Demo()
    {
        InitializeComponent();
        _repo = new ManejoArchivosRepository();
        ObtenerInformacionArchivo();

	}
    private async void ObtenerInformacionArchivo()
    {
        TextoArchivo.Text = await _repo.ObtenerInformacionArchivo();
    }

    private async void BotonGuardar_Clicked(object sender, EventArgs e)
    {
        string texto = Texto1.Text;
        bool guardar = await _repo.GuardarArchivo(texto);
        if (!guardar)
        {
            throw new Exception("No se pudo guardar el archivo");
        }
    }
}