using System;
using System.IO;
using System.Threading.Tasks;

namespace ManosalvasFlyoutTab.NewFolder
{
    public class ManejoArchivosRepository
    {
        private readonly string path;

        public ManejoArchivosRepository()
        {
            path = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
        }

        public async Task<bool> GuardarArchivo(string texto)
        {
            try
            {
                await File.WriteAllTextAsync(path, texto);

                return File.Exists(path);
            }
            catch (Exception)
            {
                // Aquí puedes loggear el error si quieres
                return false;
            }
        }

        public async Task<string> ObtenerInformacionArchivo()
        {
            if (File.Exists(path))
            {
                string texto = await File.ReadAllTextAsync(path);
                return texto;
            }

            return "No encontré nada";
        }
    }
}
