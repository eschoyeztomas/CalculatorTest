using System;

namespace TestCalculator
{
    public class UnitTest1
    {
        [Fact]

        public void StringVacioRetornaCero()
        {
            //Arrange
            var calculadora = new Calculator();
            var numbers = "";

            //Act
            var resultado = calculadora.Add(numbers);

            //Assert
            Assert.Equal(0, resultado);
        }


        [Theory]

        [InlineData("5,6", 11)]
        [InlineData("1,25", 26)]

        public void DosNumerosSeparadosPorComaSeSuman(string numbers, int esperado)
        {
            //Arrange
            var calculadora = new Calculator();

            //Act
            var resultado = calculadora.Add(numbers);

            //Assert
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [InlineData("10,10,10,10", 40)]
        [InlineData("1,9,10,60", 80)]
        [InlineData("10,20,30,100,120", 280)]


        public void NumerosSeparadosPorComaSeSuman(string numbers, int esperado)
        {
            //Arrange
            var calculadora = new Calculator();

            //Act
            var resultado = calculadora.Add(numbers);

            //Assert
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [InlineData("8;4:2", 14)]
        [InlineData("500|100|900;100", 1600)]
        [InlineData("7,3,5;5:5", 25)]


        public void NumerosSeparadosPorCualquierDelimitadorSeSuman(string numbers, int esperado)
        {
            //Arrange
            var calculadora = new Calculator();

            //Act
            var resultado = calculadora.Add(numbers);

            //Assert
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [InlineData("-4,8,-9,-1")]
        [InlineData("1,-6,-5,-3,-101")]


        public void LosNumerosNegativosLanzanExcepcion(string numbers)
        {
            var calculadora = new Calculator();
            Exception exception = null;

            try
            {
                calculadora.Add(numbers);
            }
            catch (ArgumentException ex)
            {
                exception = ex;
            }

            Assert.Contains("No se pueden utilizar numeros negativos", exception.Message);

        }
        [Theory]
        [InlineData("a,b,c,d,1,2,3,4")]
        [InlineData("9,10,1,c,z")]

        public void CaracteresInvalidosLanzaExcepcion(string numbers)
        {
            var calculadora = new Calculator();
            Exception exception = null;

            try
            {
                calculadora.Add(numbers);
            }
            catch (ArgumentException ex)
            {
                exception = ex;
            }

            Assert.Contains("Caracteres invalidos", exception.Message);
        }
    }
}