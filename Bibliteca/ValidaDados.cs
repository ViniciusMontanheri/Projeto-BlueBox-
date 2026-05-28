using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBox
{
    internal class ValidaDados
    {
        //Validar CPF
        public static bool ValidarCPF(string cpf)
        {
            // Remove caracteres especiais do CPF
            // Exemplo: 123.456.789-10 -> 12345678910
            cpf = cpf.Replace(".", "")
                     .Replace("-", "")
                     .Trim();

            // Verifica se o CPF possui 11 números
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os números são iguais
            // Exemplo: 11111111111 ou 99999999999
            // Esses CPFs são considerados inválidos
            if (cpf.All(c => c == cpf[0]))
                return false;

            // Multiplicadores usados no cálculo do primeiro dígito verificador
            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Multiplicadores usados no cálculo do segundo dígito verificador
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;

            int soma;
            int resto;

            // Pega apenas os 9 primeiros números do CPF
            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            // ==========================
            // CÁLCULO DO PRIMEIRO DÍGITO
            // ==========================
            // Cada número do CPF é multiplicado por um valor do array multiplicador1
            // Exemplo:
            // CPF: 123456789
            // 1x10 + 2x9 + 3x8 ...
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            // Pega o resto da divisão da soma por 11
            resto = soma % 11;

            // Regra do CPF:
            // Se o resto for menor que 2, o dígito é 0
            // Senão, o dígito será 11 - resto
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            // Converte o primeiro dígito para string
            digito = resto.ToString();

            // Adiciona o primeiro dígito aos 9 números iniciais
            tempCpf += digito;

            soma = 0;

            // ==========================
            // CÁLCULO DO SEGUNDO DÍGITO
            // ==========================
            // Agora o cálculo usa os 10 números
            // (os 9 originais + o primeiro dígito)
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            // Novamente pega o resto da divisão por 11
            resto = soma % 11;

            // Aplica a mesma regra do CPF
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            // Junta os dois dígitos verificadores
            digito += resto.ToString();

            // Verifica se os dígitos calculados
            // são iguais aos do CPF informado
            return cpf.EndsWith(digito);


        }
            
        //Validar CNH
        public static bool ValidarCNH(string cnh)
        {
            // Remove pontos da CNH
            cnh = cnh.Replace(".", "")

                     // Remove traços da CNH
                     .Replace("-", "")

                     // Remove espaços no começo e fim
                     .Trim();

            // Verifica se todos os números são iguais
            // Exemplo inválido: 11111111111
            if (cnh.All(c => c == cnh[0]))
                return false;

            // Se passou por todas as verificações
            // a CNH é considerada válida
            return true;
        }
    }
}