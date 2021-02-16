using System.Collections.Generic;
using System.Windows.Forms;

namespace FromTund
{
    public class ShowFullData
    {
        SQLConnection conn = new SQLConnection();
        public List<string[]> show()
        {
            conn.open();
            string fulldata = "SELECT tooded.ID,tooded.Nimetus,tooded.Kogus,tooded.Hind,tooded.Pilt,kategoria.kat_nimi FROM tooded INNER JOIN kategoria ON tooded.kategoria_id = kategoria.kategoria_id";
            List<string[]> data = conn.Select(fulldata);
            conn.close();
            return data;
        }
    }
}