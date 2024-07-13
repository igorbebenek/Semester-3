clc
clear
clear all

tic

f = @(x1, x2) 2*x1.^2 + 4*x2.^2 - 2*x1.*x2 + 4*x1 + 2*x2 - 6;

x1Range = [-8, 6];
x2Range = [-6, 5];

xStart = [-4, 0];

disp(['Zakres x1: ', num2str(x1Range)]);
disp(['Zakres x2: ', num2str(x2Range)]);
disp(['Punkt startowy: [', num2str(xStart(1)), ', ', num2str(xStart(2)), ']']);

a = 1; 
aDecay = 0.9; 
aIncrease = 1.1; 

ftol = 0.01;
maxIterations = 1000;

xMin = xStart;
iter = 0;
prevFuncValue = f(xStart(1), xStart(2));  

figure;
[X1, X2] = meshgrid(x1Range(1):0.1:x1Range(2), x2Range(1):0.1:x2Range(2));
Z = f(X1, X2);
surf(X1, X2, Z);
hold on;
scatter3(xStart(1), xStart(2), f(xStart(1), xStart(2)), 'r', 'filled');

figure;
contour(X1, X2, Z, 50);
hold on;
scatter(xStart(1), xStart(2), 'r', 'filled', 'DisplayName', 'start');

while true
    gradient = [4*xMin(1) - 2*xMin(2) + 4; 8*xMin(2) - 2*xMin(1) + 2];

    krokNormalizacji = gradient / norm(gradient);
    antyGradient = xMin - a * krokNormalizacji';

    funcValue = f(antyGradient(1), antyGradient(2));
    if funcValue < prevFuncValue
        prevFuncValue = funcValue;
        xMin = antyGradient;
        a = a * aIncrease;  % zwieksz alfa
    else
        a = a * aDecay;  % zmniejsz alfa
    end

    scatter(xMin(1), xMin(2), 'b');

    if norm(gradient) < ftol || iter >= maxIterations
        break;
    end

    iter = iter + 1;
end

scatter(xMin(1), xMin(2), 'g', 'filled', 'DisplayName', 'end');
scatter3(xMin(1), xMin(2), f(xMin(1), xMin(2)), 'g', 'filled', 'DisplayName', 'End');

title(['Wartosc: ' num2str(prevFuncValue)]);
xlabel('x1');
ylabel('x2');
zlabel('f(x1, x2)');
legend('Start', 'Path', 'Minimum');

czas = toc;

disp(['Punkt minimum: [', num2str(xMin(1)), ', ', num2str(xMin(2)), ']']);
disp(['f(Pmin): ', num2str(prevFuncValue)]);
disp(['Liczba iteracji: ', num2str(iter)]);
disp(['Czas wykonania: ', num2str(czas), ' sekund']);
