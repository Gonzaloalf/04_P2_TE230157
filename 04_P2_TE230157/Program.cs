Console.WriteLine("CARGA DE UNA BATERÍA");
Console.WriteLine();

// Crear un objeto de la clase Bateria
Bateria bateria1 = new Bateria();

// Capturar la información del objeto
Console.Write("Ingrese el voltaje inicial (V): ");
bateria1.VoltajeActual = Convert.ToDecimal(Console.ReadLine());
while (bateria1.VoltajeActual < 0)
{
    Console.Write("El voltaje no puede ser negativo. Ingrese de nuevo (V): ");
    bateria1.VoltajeActual = Convert.ToDecimal(Console.ReadLine());
}

Console.Write("Ingrese el incremento de voltaje por ciclo (V): ");
bateria1.Incremento = Convert.ToDecimal(Console.ReadLine());
while (bateria1.Incremento <= 0)
{
    // un incremento menor o igual que 0 produciría un ciclo infinito
    Console.Write("El incremento debe ser mayor que 0. Ingrese de nuevo (V): ");
    bateria1.Incremento = Convert.ToDecimal(Console.ReadLine());
}

Console.WriteLine();

// Mientras el voltaje sea menor que 12.6 V, el objeto aumenta su voltaje
while (bateria1.VoltajeActual < Bateria.VoltajeMaximo)
{
    bateria1.AumentarVoltaje();
    Console.WriteLine($"Ciclo {bateria1.Ciclos}: {bateria1.VoltajeActual:F2} V");
}

// Mostrar resultados
Console.WriteLine();
Console.WriteLine($"Ciclos realizados: {bateria1.Ciclos}");
Console.WriteLine($"Voltaje final: {bateria1.VoltajeActual:F2} V");


// Definición de la clase
class Bateria
{
    // Constante: voltaje máximo de carga
    public const decimal VoltajeMaximo = 12.6m;   // V

    // Propiedades
    public decimal VoltajeActual { get; set; }    // V

    public decimal Incremento { get; set; }       // V por ciclo

    public int Ciclos { get; set; }


    // Método para aumentar el voltaje un ciclo
    public void AumentarVoltaje()
    {
        VoltajeActual = VoltajeActual + Incremento;
        Ciclos = Ciclos + 1;

        // Si el último incremento supera el límite, se ajusta a 12.6 V
        if (VoltajeActual > VoltajeMaximo)
        {
            VoltajeActual = VoltajeMaximo;
        }
    }
}