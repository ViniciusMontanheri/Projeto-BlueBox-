using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//Importar a biblioteca


namespace Bibliteca
{
    internal class Program
    {
        //Definir o ponto de entrada do software
        [STAThread] 
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }//fim do método main
    }//fim da classe
}//fim do projeto
