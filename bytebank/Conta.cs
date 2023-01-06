using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace bytebank.Contas
{
    public class Conta
    {
        private string titular;
        public string Titular { get; private set; }
        public string Cpf { get; private set; }
        public string Senha { get; private set; }
        public double Saldo { get; private set; }

        public bool check;

        public Conta(string titular, string cpf, string senha)
        {
            this.Titular = titular;
            this.Cpf = cpf;
            this.Senha = senha;
            check = true;
        }

        public static bool ValidarTitular(string titular)
        {
            if ((Regex.IsMatch(titular, @"^\d+$") == true) || (titular.Length < 3))
            {
                Console.WriteLine();
                Console.WriteLine("Titular inexistente");
                Console.WriteLine();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidarCpf(string cpf)
        {
            var regexCPF = new Regex(@"^[0-9]+$");
            bool teste = regexCPF.IsMatch(cpf);
            if ((cpf.Length < 11) || (teste == false))
            {

                Console.WriteLine();
                Console.WriteLine("CPF não cadastrado");
                Console.WriteLine();
                return false;

            }
            else
            {
                return true;
            }

        }

        public static bool ValidarSenha(string senha)
        {
            if (senha.Length < 8)
            {
                Console.WriteLine();
                Console.WriteLine("A senha deve ter no mínimo 8 dígitos");
                Console.WriteLine();
                return false;

            }
            else
            {
                return true;
            }
        }


        public void Depositar(double valor)
        {
            if (valor >= 0)
            {
                this.Saldo += valor;
                Console.WriteLine("O deposito foi realizado com sucesso");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Valores rejeitados");
                Console.WriteLine();
            }

        }

        public void Sacar(double valor)
        {
            if (valor >= 0)
            {
                if (this.Saldo >= valor)
                {
                    this.Saldo -= valor;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Saldo insuficiente ");
                    Console.WriteLine();
                    return;
                }

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Valores rejeitados ");
                Console.WriteLine();
                return;
            }


        }

    }
}