using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing; //Traz classes graficas
using System.Drawing.Drawing2D; //Recursos graficos melhores

namespace Bibliteca
{
    internal class DesignAjustes
    {
        public static void ArredondarBotao(Button botao, int raio) //Recebe um botão
        {
            GraphicsPath pasta = new GraphicsPath(); //Cria um caminho gráfico que armazenará o formato do botão

            //Arredondando os cantos
            pasta.AddArc(0, 0, raio, raio, 180, 90);
            pasta.AddArc(botao.Width - raio, 0, raio, raio, 270, 90);
            pasta.AddArc(botao.Width - raio, botao.Height - raio, raio, raio, 0, 90);
            pasta.AddArc(0, botao.Height - raio, raio, raio, 90, 90);

            pasta.CloseFigure();

            botao.Region = new Region(pasta); //Aplicando o formato do botão
        }
    }
}
