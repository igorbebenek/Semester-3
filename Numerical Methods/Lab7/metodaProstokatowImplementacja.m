clc;
clear;
close all;
x = 0.5:16.5;
y = [4, 5.3, 6, 6.5, 6.8, 7, 7, 7, 7.5, 6.5, 5.6, 5.2, 4.8, 4.6, 4.8, 6.5, 4];
y1 = [4, 3, 2.6, 1.5, 1, 1.9, 1.8, 1.8, 1.9, 2, 2.2, 2.5, 3, 3.5, 3.4, 2, 4];
xInterp = 0.5:0.1:16.5;
interp1_y = interp1(x, y, xInterp, 'linear');
interp1_y1 = interp1(x, y1, xInterp, 'linear');

figure;
plot(xInterp, interp1_y, 'b');
hold on;
plot(xInterp, interp1_y1, 'r');

xSteps = 1:10:length(xInterp); 
for i = 1:length(xSteps)
    line([xInterp(xSteps(i)), xInterp(xSteps(i))], [0, interp1_y(xSteps(i))], 'Color', 'blue');
    line([xInterp(xSteps(i)), xInterp(xSteps(i))], [0, interp1_y1(xSteps(i))], 'Color', 'blue');
end
scatter(xInterp(xSteps), interp1_y(xSteps), 'filled', 'g');
scatter(xInterp(xSteps), interp1_y1(xSteps), 'filled', 'g');
title('Metoda Prostokątów - krok = 10');
xlabel('x');
ylabel('y');

figure;
plot(xInterp, interp1_y, 'b');
hold on;
plot(xInterp, interp1_y1, 'r');

for i = 1:length(xInterp)
    line([xInterp(i), xInterp(i)], [0, interp1_y(i)], 'Color', 'blue');
    line([xInterp(i), xInterp(i)], [0, interp1_y1(i)], 'Color', 'blue');
end
scatter(xInterp, interp1_y, 'filled', 'g');
scatter(xInterp, interp1_y1, 'filled', 'g');
title('Metoda Prostokątów - krok = 1');
xlabel('x');
ylabel('y');

dx = xInterp(2) - xInterp(1); 
poleKrok10 = metodaProstokatow(xInterp(xSteps), interp1_y(xSteps), dx);
poleKrok1 = metodaProstokatow(xInterp, interp1_y, dx);
fprintf('Pole dla metody prostokątów z krokiem 10: %f\n', poleKrok10);
fprintf('Pole dla metody prostokątów z krokiem 1: %f\n', poleKrok1);

