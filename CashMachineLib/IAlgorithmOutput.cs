namespace CashMachineLib
{
    public interface IAlgorithmOutput
    {
        public string Output { get; set; }

        double Balance { get; set; }
    }
}