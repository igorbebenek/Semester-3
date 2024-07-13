clc;
close all;

% Dane
x = 0.5:16.5;
y = [4, 5.3, 6, 6.5, 6.8, 7, 7, 7, 7.5, 6.5, 5.6, 5.2, 4.8, 4.6, 4.8, 6.5, 4];
x2 = 0.5:16.5;
y2 = [4, 3, 2.6, 1.5, 1, 1.9, 1.8, 1.8, 1.9, 2, 2.2, 2.5, 3, 3.5, 3.4, 2, 4];

% Interpolacja liniowa
xInterp = 0.5:0.1:16.5;
interp1_y = interp1(x, y, xInterp, 'linear');
interp1_y2 = interp1(x2, y2, xInterp, 'linear');

% Rysowanie krzywych
plot(xInterp, interp1_y, 'b-', xInterp, interp1_y2, 'g-');
hold on;

% Funkcja na potrzeby obliczenia pola za pomocą metody prostokątów


% Obliczenie i rysowanie dla kroku 1
area_step_1 = rectangle_method(x, y, y2, 1);
fprintf('Pole powierzchni dla kroku 1: %f\n', area_step_1);
% Rysowanie dla kroku 10 w nowym oknie
figure;
plot(xInterp, interp1_y, 'b-', xInterp, interp1_y2, 'g-');
hold on;
area_step_10 = rectangle_method(x, y, y2, 10);
fprintf('Pole powierzchni dla kroku 10: %f\n', area_step_10);

hold off;

% Oznaczenia wykresu
xlabel('x');
ylabel('y');
title('Metoda prostokątów');
legend('Interpolacja y', 'Interpolacja y2', 'Prostokąty');
