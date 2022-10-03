using Bogus;
using System;
using Xunit;
using Xunit.Abstractions;

namespace TestProjectCurso
{
    public class CursoTest: IDisposable
    {
        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;
        private readonly string _descricao;
        private readonly ITestOutputHelper _output;

        public CursoTest(ITestOutputHelper output)
        {
            _output = output;
            Faker fake = new Faker();

            _nome = fake.Random.Word();
            _cargaHoraria = fake.Random.Double(1.100);
            _publicoAlvo = PublicoAlvo.Universitario;
            _valor = fake.Random.Double(1, 100);
            _descricao = fake.Lorem.Paragraph();

            output.WriteLine($"Double : {_valor}");
            output.WriteLine($"string : {_descricao}");
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeVazio(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                new Curso(nomeInvalido, _cargaHoraria, _publicoAlvo, _valor, _descricao));
        }
    }
    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor, string descricao)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException();

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
            Descricao = descricao;
        }
        public string Nome { get; set; }
        public double CargaHoraria { get; set; }
        public double Valor { get; set; }
        public PublicoAlvo PublicoAlvo { get; set; }
        public string Descricao { get; set; }

    }
}