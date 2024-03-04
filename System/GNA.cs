using System;
using System.Collections.Generic;
using System.Linq;

public class GeneticNeuralAlgorithm
{
    static Random random = new Random();

    public static int ParallelFitness(List<string> population, string target)
    {
        return population.Max(individual => Fitness(individual, target));
    }

    public static List<string> Selection(List<string> population, string target, int tournamentSize)
    {
        List<string> selected = new List<string>();
        for (int i = 0; i < 2; i++)
        {
            List<string> tournament = population.OrderBy(x => random.Next()).Take(tournamentSize).ToList();
            string winner = tournament.OrderByDescending(individual => Fitness(individual, target)).First();
            selected.Add(winner);
        }
        return selected;
    }

    public static string Mutation(string individual, double p)
    {
        if (random.NextDouble() < p)
        {
            int point = random.Next(individual.Length);
            char[] mutated = individual.ToCharArray();
            mutated[point] = (mutated[point] == '1') ? '0' : '1';
            return new string(mutated);
        }
        else
        {
            int point1 = random.Next(individual.Length);
            int point2 = random.Next(individual.Length);
            char[] mutated = individual.ToCharArray();
            (mutated[point1], mutated[point2]) = (mutated[point2], mutated[point1]);
            return new string(mutated);
        }
    }

    public static int CalculateDynamicPopulationSize(int initialSize, int generation, int maxGenerations)
    {
        double factor = 0.5 + 0.5 * Math.Cos(Math.PI * generation / maxGenerations);
        return (int)Math.Floor(initialSize * factor);
    }

    public static void Run(string target, int initialPopulationSize, int numGenerations, double crossoverProbability,
                           double initialMutationProbability, double finalMutationProbability, double mutationDecreaseRate,
                           int tournamentSize)
    {
        int populationSize = initialPopulationSize;
        List<string> population = InitializePopulation(populationSize, target.Length);
        double mutationProbability = initialMutationProbability;
        for (int generation = 0; generation < numGenerations; generation++)
        {
            List<string> parents = Selection(population, target, tournamentSize);
            List<string> offspring = new List<string>();
            foreach (string parent in parents)
            {
                offspring.Add(Mutation(parent, mutationProbability));
            }
            population.AddRange(offspring);
            population = population.OrderByDescending(individual => ParallelFitness(population, target)).Take(populationSize).ToList();
            populationSize = CalculateDynamicPopulationSize(initialPopulationSize, generation, numGenerations);
            mutationProbability = Math.Max(initialMutationProbability * Math.Pow(mutationDecreaseRate, generation + 1),
                                           finalMutationProbability);
        }
        Console.WriteLine(population[0]);
    }

    public static List<string> InitializePopulation(int populationSize, int targetLength)
    {
        List<string> population = new List<string>();
        for (int i = 0; i < populationSize; i++)
        {
            string individual = new string(Enumerable.Repeat("01", targetLength).Select(s => s[random.Next(s.Length)]).ToArray());
            population.Add(individual);
        }
        return population;
    }

    public static int Fitness(string individual, string target)
    {
        return individual.Zip(target, (ind, tar) => ind == tar ? 1 : 0).Sum();
    }

    public static void Main(string[] args)
    {
        string target = "11110000";
        int populationSize = 10;
        int numGenerations = 100;
        double crossoverProbability = 0.8;
        double initialMutationProbability = 0.5;
        double finalMutationProbability = 0.1;
        double mutationDecreaseRate = 0.9;
        int tournamentSize = 3;

        Run(target, populationSize, numGenerations, crossoverProbability,
            initialMutationProbability, finalMutationProbability, mutationDecreaseRate,
            tournamentSize);
    }

    // Define the GNA source code
    static string Source = "<({[\"G'N'A\"]})>";
}
