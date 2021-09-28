using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptSharp;

namespace net_car_ASPNETCORE.Controllers
{
    public static class Util
    {
        public static string Codifica(string senha)
        {
            return Crypter.MD5.Crypt(senha);
        }

        public static bool Compara(string senhaDigitada, string senha)
        {
            return Crypter.CheckPassword(senhaDigitada, senha);
        }

        public static string formatCnpj(string cnpj)
        {
            if (cnpj.Length > 14)
            {
                throw new Exception("CNPJ invalido");
            }
            while(cnpj.Length < 14)
            {
                cnpj = '0' + cnpj;
            }
            cnpj = cnpj.Substring(0, 2) + "." + cnpj.Substring(2, 3) + "." + 
                cnpj.Substring(5, 3) + "/" + cnpj.Substring(8, 4) + "-" + cnpj.Substring(12, 2);
            return cnpj;
        }

        public static string formatCpf(string cpf)
        {
            if (cpf.Length > 11)
            {
                throw new Exception("CPF invalido");
            }
            while(cpf.Length < 11)
            {
                cpf = '0' + cpf;
            }
            cpf = cpf.Substring(0, 3) + "." + cpf.Substring(3, 3) + "." +
                cpf.Substring(6, 3) + "-" + cpf.Substring(9, 2);
            return cpf;
        }

        public static string formatPlaca(string placa)
        {
            if ((placa.Length != 8 && !Regex.IsMatch(placa, "-")))
                if(placa.Length != 7)
                   throw new Exception("Placa inválida");
            if(placa.Length == 7)
            {
                placa = placa.Substring(0, 3) + "-" + placa.Substring(3);
            }
            
            return placa.ToUpper();
        }
        public static float formatValueToFloat(string value)
        {
            value = value.Replace(',', '.');
            return float.Parse(value);
        }

    }
}
