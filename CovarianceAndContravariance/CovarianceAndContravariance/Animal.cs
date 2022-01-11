namespace CovarianceAndContravariance
{
    internal class Animal
    {
        public Animal(string name)
        {
            Name = name;
        }

        public string Name { get ; set ; }

        public virtual void SayName()
        {
            System.Console.WriteLine($"my name is {Name}");
        }
    }
}