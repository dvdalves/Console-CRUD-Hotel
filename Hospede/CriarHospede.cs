using CrudHotel;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CrudHotel
{
    public partial class CrudHotel
    {
        static void CriarHospede()
        {
            DBContext _context = new DBContext();
            Console.Clear();
            Console.WriteLine("Registrando hóspede. Aperte 0 para retornar.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Nome e Sobrenome:");
            Console.ResetColor();

            string name = Console.ReadLine();

            while (true)
            {
                if (name == "0")
                {
                    Console.Clear();
                    ShowMenuHospede();
                }

                if (Regex.IsMatch(name, @"^[a-zA-Z\s]+$") && name.Length >= 6 && name.Length <= 50)
                {
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nome inválido. Por favor, insira um nome válido somente com letras e com pelo menos 6 caracteres. Aperte uma tecla para tentar novamente ou 0 para retornar.");
                Console.ResetColor();

                string input = Console.ReadLine();
                if (input == "0")
                {
                    Console.Clear();
                    ShowMenuHospede();
                }

                name = input.Length > 50 ? input.Substring(0, 50) : input;
                Console.Clear();
                Console.WriteLine("Registrando hóspede. Aperte 0 para retornar.");
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Nome e Sobrenome:");
                Console.ResetColor();
                Console.WriteLine(name);
            }
            cpf:
            Console.Clear();
            Console.WriteLine("Se desejar cancelar seu registro, digite 0 para retornar ao menu anterior.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CPF:");
            Console.ResetColor();
            string cpf = Console.ReadLine();
            var verificacaoCpf = _context.hospedes.Any(x => x.CPF == cpf);
            if (verificacaoCpf)
            {
                Console.Clear();
                Console.WriteLine("Esse CPF já foi registrado. Aperte ENTER para voltar ");
                Console.ReadLine();
                goto cpf;
            }

            while (cpf.Length != 11 || !long.TryParse(cpf, out _))
            {
                if (cpf == "0")
                {
                    Console.Clear();
                    ShowMenuHospede();
                }

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF inválido. Por favor, insira um CPF válido com 11 dígitos ou digite 0 para voltar ao menu anterior.");
                Console.ResetColor();
                cpf = Console.ReadLine();
            }

            email:
            Console.WriteLine("Se desejar cancelar seu registro, digite 0 para retornar ao menu anterior.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("E-mail:");
            Console.ResetColor();
            string email = Console.ReadLine();
            var verificacaoEmail = _context.hospedes.Any(x => x.Email == email);
            if (verificacaoEmail)
            {
                Console.Clear();
                Console.WriteLine("Esse Email já foi registrado. Aperte ENTER para voltar.");
                goto email;
            }

            while (true)
            {
                if (email == "0")
                {
                    Console.Clear();
                    ShowMenuHospede();
                }

                if (Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z.]{2,}$"))
                {
                    break;
                }

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("E-mail inválido. Por favor, insira um e-mail válido com o formato nome@dominio.com.");
                Console.ResetColor();
                email = Console.ReadLine();
            }

            Console.WriteLine("Se desejar cancelar seu registro, digite 0 para retornar ao menu anterior.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Telefone com DDD:");
            Console.ResetColor();
            string phone = Console.ReadLine();

            if (phone == "0")
            {
                Console.Clear();
                ShowMenuHospede();
            }

            while (!Regex.IsMatch(phone, @"^(\(\d{2,3}\))?[\d]{7,14}$"))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Telefone inválido. Por favor, insira um número de telefone com pelo menos 11 dígitos.");
                Console.ResetColor();
                phone = Console.ReadLine();
            };
            Hospede hos = new Hospede { Name = name, CPF = cpf, Email = email, Phone = phone };
            hospede.Add(hos);

            _context.hospedes.Add(hos);
            _context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hóspede criado com sucesso! Aperte qualquer tecla para retornar ao menu principal.");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            ShowMenuHospede();
        }
    }
}