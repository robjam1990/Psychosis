class GeneticNeuralAlgorithm {
    static parallelFitness(population, target) {
        return Math.max(...population.map(individual => GeneticNeuralAlgorithm.fitness(individual, target)));
    }

    static selection(population, target, tournamentSize) {
        let selected = [];
        for (let i = 0; i < 2; i++) {
            let tournament = [];
            for (let j = 0; j < tournamentSize; j++) {
                tournament.push(population[Math.floor(Math.random() * population.length)]);
            }
            let winner = tournament.reduce((a, b) => GeneticNeuralAlgorithm.fitness(a, target) > GeneticNeuralAlgorithm.fitness(b, target) ? a : b);
            selected.push(winner);
        }
        return selected;
    }

    static mutation(individual, p) {
        if (Math.random() < p) {
            let point = Math.floor(Math.random() * individual.length);
            let mutated = individual.split('');
            mutated[point] = (mutated[point] === '1') ? '0' : '1';
            return mutated.join('');
        } else {
            let point1 = Math.floor(Math.random() * individual.length);
            let point2 = Math.floor(Math.random() * individual.length);
            let mutated = individual.split('');
            [mutated[point1], mutated[point2]] = [mutated[point2], mutated[point1]];
            return mutated.join('');
        }
    }

    static calculateDynamicPopulationSize(initialSize, generation, maxGenerations) {
        let factor = 0.5 + 0.5 * Math.cos(Math.PI * generation / maxGenerations);
        return Math.floor(initialSize * factor);
    }

    static run(target, initialPopulationSize, numGenerations, crossoverProbability, initialMutationProbability,
        finalMutationProbability, mutationDecreaseRate, tournamentSize) {
        let populationSize = initialPopulationSize;
        let population = GeneticNeuralAlgorithm.initializePopulation(populationSize, target.length);
        let mutationProbability = initialMutationProbability;
        for (let generation = 0; generation < numGenerations; generation++) {
            let parents = GeneticNeuralAlgorithm.selection(population, target, tournamentSize);
            let offspring = [];
            for (let parent of parents) {
                offspring.push(GeneticNeuralAlgorithm.mutation(parent, mutationProbability));
            }
            population = population.concat(offspring);
            population.sort((a, b) => GeneticNeuralAlgorithm.parallelFitness(b, target) - GeneticNeuralAlgorithm.parallelFitness(a, target));
            populationSize = GeneticNeuralAlgorithm.calculateDynamicPopulationSize(initialPopulationSize,
                generation, numGenerations);
            population = population.slice(0, populationSize);
            mutationProbability = Math.max(initialMutationProbability * (mutationDecreaseRate ** (generation + 1)),
                finalMutationProbability);
        }
        console.log(population[0]);
    }

    static initializePopulation(populationSize, targetLength) {
        let population = [];
        for (let i = 0; i < populationSize; i++) {
            let individual = '';
            for (let j = 0; j < targetLength; j++) {
                individual += (Math.random() < 0.5) ? '0' : '1';
            }
            population.push(individual);
        }
        return population;
    }

    static fitness(individual, target) {
        return individual.split('').reduce((acc, curr, index) => acc + ((curr === target[index]) ? 1 : 0), 0);
    }
}

function main() {
    let target = "11110000";
    let populationSize = 10;
    let numGenerations = 100;
    let crossoverProbability = 0.8;
    let initialMutationProbability = 0.5;
    let finalMutationProbability = 0.1;
    let mutationDecreaseRate = 0.9;
    let tournamentSize = 3;

    GeneticNeuralAlgorithm.run(target, populationSize, numGenerations, crossoverProbability,
        initialMutationProbability, finalMutationProbability, mutationDecreaseRate,
        tournamentSize);
}

main();

// Define the GNA source code
let Source = '<({["G\'N\'A"]})>';
