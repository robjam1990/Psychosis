# File = robjam1990/Psychosis/Gameplay/Systems/GNA.jl
import random
import math

# Define the GNA source code
Source = '<({["G\'N\'A"]})>'

class GeneticNeuralAlgorithm:
    @staticmethod
    def parallel_fitness(population, target):
        return max(map(lambda individual: GeneticNeuralAlgorithm.fitness(individual, target), population))

    @staticmethod
    def selection(population, target, tournament_size):
        selected = []
        for _ in range(2):
            tournament = random.sample(population, tournament_size)
            winner = max(tournament, key=lambda individual: GeneticNeuralAlgorithm.fitness(individual, target))
            selected.append(winner)
        return selected

    @staticmethod
    def mutation(individual, p):
        if random.random() < p:
            point = random.randint(0, len(individual) - 1)
            mutated = list(individual)
            mutated[point] = '0' if mutated[point] == '1' else '1'
            return ''.join(mutated)
        else:
            point1 = random.randint(0, len(individual) - 1)
            point2 = random.randint(0, len(individual) - 1)
            mutated = list(individual)
            mutated[point1], mutated[point2] = mutated[point2], mutated[point1]
            return ''.join(mutated)

    @staticmethod
    def calculate_dynamic_population_size(initial_size, generation, max_generations):
        factor = 0.5 + 0.5 * math.cos(math.pi * generation / max_generations)
        return int(initial_size * factor)

    @staticmethod
    def run(target, initial_population_size, num_generations, crossover_probability, initial_mutation_probability,
            final_mutation_probability, mutation_decrease_rate, tournament_size):
        population_size = initial_population_size
        population = GeneticNeuralAlgorithm.initialize_population(population_size, len(target))
        mutation_probability = initial_mutation_probability
        for generation in range(num_generations):
            parents = GeneticNeuralAlgorithm.selection(population, target, tournament_size)
            offspring = []
            for parent in parents:
                offspring.append(GeneticNeuralAlgorithm.mutation(parent, mutation_probability))
            population += offspring
            population.sort(key=lambda individual: GeneticNeuralAlgorithm.parallel_fitness(individual, target),
                            reverse=True)
            population_size = GeneticNeuralAlgorithm.calculate_dynamic_population_size(initial_population_size,
                                                                                        generation, num_generations)
            population = population[:population_size]
            mutation_probability = max(initial_mutation_probability * (mutation_decrease_rate ** (generation + 1)),
                                       final_mutation_probability)
        print(population[0])

    @staticmethod
    def initialize_population(population_size, target_length):
        population = []
        for _ in range(population_size):
            individual = ''.join(random.choice('01') for _ in range(target_length))
            population.append(individual)
        return population

    @staticmethod
    def fitness(individual, target):
        return sum(1 for ind, tar in zip(individual, target) if ind == tar)

def main():
    target = "11110000"
    population_size = 10
    num_generations = 100
    crossover_probability = 0.8
    initial_mutation_probability = 0.5
    final_mutation_probability = 0.1
    mutation_decrease_rate = 0.9
    tournament_size = 3

    GeneticNeuralAlgorithm.run(target, population_size, num_generations, crossover_probability,
                               initial_mutation_probability, final_mutation_probability, mutation_decrease_rate,
                               tournament_size)

if __name__ == "__main__":
    main()
