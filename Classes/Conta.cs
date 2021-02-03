namespace DIO.Bank
{
    public class Conta
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }     
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque) {
            if (this.Saldo + this.Credito < valorSaque) {
                System.Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            
            this.Saldo -= valorSaque;
            MostrarSaldo();
            return true;    
        }

        public void Depositar(double valorDeposito) {
            this.Saldo += valorDeposito;
            MostrarSaldo();
        }

        public void Transferir(double valorTransferencia, Conta contaDestino) {
            if (this.Sacar(valorTransferencia)) 
            {
                contaDestino.Depositar(valorTransferencia);
                MostrarSaldo();
            }
        }
    
        private void MostrarSaldo() {
        System.Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Credito: " + this.Credito + " | ";
            retorno += "Nome: " + this.Nome;
            return retorno;
        }
    }
}