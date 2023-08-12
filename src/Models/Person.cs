using System.Collections.Generic;

namespace src.Models;

public class Person
{
    public Person()
    {
        this.Nome = "John";
        this.Idade = 0;
        this.ListaContrato = new List<Contract>();
        this.Ativo = true;
    }
    public Person(string Nome, int Idade, string Cpf)
    {
        this.Nome = Nome;
        this.Idade = Idade;
        this.Cpf = Cpf;
        this.ListaContrato = new List<Contract>();
        this.Ativo = true;
    }
    public int Id {get; set;}
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string? Cpf { get; set; }
    public bool Ativo { get; set; }
    public List<Contract> ListaContrato { get; set; }
}