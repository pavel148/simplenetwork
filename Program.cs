using System;

class Program
{
    public class Neuron
    {
        private decimal weight = 0.5m;
        public decimal LastError { get; private set; }

        public decimal Smoothing { get; set; } = 0.00001m;
        public decimal ProcessInputData(decimal input)
        {
            return weight * input;
        }
        public decimal RestoreInputData(decimal output)
        {
            return output / weight;
        }

        public void Train(decimal input, decimal expectedResult)
        {
            var actaulResult = weight * input;
            LastError = expectedResult - actaulResult;
            var correction = (LastError / actaulResult)*Smoothing;
            weight += correction;
        }
    }
    static void Main(string[] args)
    {
        decimal usd = 1;
        decimal rub = 74.09m;
        Neuron neuron = new Neuron();

        int i = 0;

        do
        {
            i++;
            neuron.Train(usd, rub);
            if(i%199999==0)
            Console.WriteLine($"Итерация: {i}\tОшибка:\t{neuron.LastError}");
        } while (neuron.LastError > neuron.Smoothing || neuron.LastError < - neuron.Smoothing);

        Console.WriteLine("Обучение завершино");


        Console.WriteLine($"{neuron.ProcessInputData(usd)} руб. в {100} долара");

        Console.WriteLine($"{neuron.ProcessInputData(541)} руб. в {541} доларах");
    }
}
