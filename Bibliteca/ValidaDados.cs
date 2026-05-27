using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBox
{
    internal class ValidaDados
    {
        public static bool ValidarCPF(string cpf)
        {
            // Remove caracteres especiais
            cpf = cpf.Replace(".", "")
                     .Replace("-", "")
                     .Trim();

            // Verifica tamanho
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os números são iguais
            if (cpf.All(c => c == cpf[0]))
                return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;

            int soma;
            int resto;

            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf += digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
