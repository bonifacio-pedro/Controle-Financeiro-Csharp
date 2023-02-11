using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Controle_Financeiro
{
    public class Serializador
    {
        public static void EncheLista(ref List<Entradas> entradas, string caminho, DataGridView table)
        {
            if (File.Exists(caminho))
            {
                XmlSerializer leitor = new XmlSerializer(typeof(List<Entradas>));
                FileStream fs = File.Open(caminho, FileMode.Open);
                List<Entradas> temp = (List<Entradas>)leitor.Deserialize(fs);
                fs.Close();
                entradas = temp;

                foreach (Entradas entrada in entradas)
                {
                    string[] entradaS = { entrada.descEntrada, entrada.valorEntrada.ToString("C") };
                    table.Rows.Add(entradaS);
                }
            }
            else
            {
                entradas = new List<Entradas>();
            }
        }
        public static void EncheLista(ref List<Saidas> saidas, string caminho, DataGridView table)
        {
            if (File.Exists(caminho))
            {
                XmlSerializer leitor = new XmlSerializer(typeof(List<Saidas>));
                FileStream fs = File.Open(caminho, FileMode.Open);
                List<Saidas> temp = (List<Saidas>)leitor.Deserialize(fs);
                fs.Close();
                saidas = temp;

                foreach (Saidas saida in saidas)
                {
                    string[] saidasS = { saida.descSaida, saida.valSaida.ToString("C"), saida.dataSaida.ToString("dd/MM/yyyy") };
                    table.Rows.Add(saidasS);
                }
            }
            else
            {
                saidas = new List<Saidas>();
            }
        }
        public static void EncheCarteira(ref double carteira, string caminho)
        {
            try
            {
                if (File.Exists(caminho))
                {
                    XmlSerializer leitor = new XmlSerializer(typeof(double));
                    FileStream fs = File.Open(caminho, FileMode.Open);
                    carteira = (double)leitor.Deserialize(fs);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EX: " + ex.Message);
            }
        }
        public static void EncheRecebidos(ref double total, string caminho)
        {
            if (File.Exists(caminho))
            {
                XmlSerializer leitor = new XmlSerializer(typeof(List<Entradas>));
                FileStream fs = File.Open(caminho, FileMode.Open);
                List<Entradas> temp = (List<Entradas>)leitor.Deserialize(fs);
                fs.Close();

                double valorTemp = 0;

                foreach (Entradas entrada in temp)
                {
                    valorTemp += entrada.valorEntrada;
                }

                total = valorTemp;
            }
        }
        public static void EncheSaidas(ref double total, string caminho)
        {
            if (File.Exists(caminho))
            {
                XmlSerializer leitor = new XmlSerializer(typeof(List<Saidas>));
                FileStream fs = File.Open(caminho, FileMode.Open);
                List<Saidas> temp = (List<Saidas>)leitor.Deserialize(fs);
                fs.Close();

                double valorTemp = 0;

                foreach (Saidas saida in temp)
                {
                    valorTemp += saida.valSaida;
                }

                total = valorTemp;
            }
        }
        public static void Serializa(double carteira, string caminho)
        {
            XmlSerializer escritor = new XmlSerializer(typeof(double));
            FileStream fs = File.Create(caminho);
            escritor.Serialize(fs, carteira);
            fs.Close();
        }
        public static void Serializa(List<Entradas> entradas, string caminho)
        {
            XmlSerializer escritor = new XmlSerializer(typeof(List<Entradas>));
            if (File.Exists(caminho))
            {
                FileStream fs = File.Open(caminho, FileMode.Open);
                escritor.Serialize(fs, entradas);
                fs.Close();
            }
            else
            {
                FileStream fs = File.Create(caminho);
                escritor.Serialize(fs, entradas);
                fs.Close();
            }
        }
        public static void Serializa(List<Saidas> saidas, string caminho)
        {
            XmlSerializer escritor = new XmlSerializer(typeof(List<Saidas>));
            if (File.Exists(caminho))
            {
                FileStream fs = File.Open(caminho, FileMode.Open);
                escritor.Serialize(fs, saidas);
                fs.Close();
            }
            else
            {
                FileStream fs = File.Create(caminho);
                escritor.Serialize(fs, saidas);
                fs.Close();
            }
        }
    }
}
