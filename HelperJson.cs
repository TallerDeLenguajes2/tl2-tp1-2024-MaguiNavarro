public class HelperJson
{
    public string AbrirArchivo(string ruta)
    {
        string linea;
        using (FileStream archivo = new FileStream(ruta, FileMode.Open))
        {
            using (StreamReader sr = new StreamReader(archivo))
            {
                linea = sr.ReadToEnd();
                sr.Close();
            }
        }
        return linea;
    }
}