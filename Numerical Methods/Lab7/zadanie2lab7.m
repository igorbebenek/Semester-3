clc;
clear;
close all;

sinFunction = @(x) sin(x);
startPoint = -pi;
endPoint = pi;
stepSizes = [0.1, 0.05, 0.025, 0.0125];

shotCounts = [100, 500, 1000, 5000];

for stepSize = stepSizes
    xValues = startPoint:stepSize:endPoint;
    yValues = sinFunction(xValues);
    trapezoidalApprox = stepSize * (sum(yValues) - 0.5 * (yValues(1) + yValues(end)));

    disp(['Metoda Trapezów (krok = ', num2str(stepSize), '):']);
    disp(['Przybliżenie całki: ', num2str(trapezoidalApprox)]);
    disp(' ');
end

for shots = shotCounts
    randomPoints = (endPoint - startPoint) * rand(1, shots) + startPoint;
    randomValues = sinFunction(randomPoints);
    monteCarloApprox = (endPoint - startPoint) * mean(randomValues);

    disp(['Metoda Monte Carlo (strzały = ', num2str(shots), '):']);
    disp(['Przybliżenie całki: ', num2str(monteCarloApprox)]);
    disp(' ');
end

