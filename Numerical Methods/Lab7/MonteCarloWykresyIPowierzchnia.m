clc;
close all;
x = 0.5:16.5;
y = [4, 5.3, 6, 6.5, 6.8, 7, 7, 7, 7.5, 6.5, 5.6, 5.2, 4.8, 4.6, 4.8, 6.5, 4];
y2 = [4, 3, 2.6, 1.5, 1, 1.9, 1.8, 1.8, 1.9, 2, 2.2, 2.5, 3, 3.5, 3.4, 2, 4];

% 100 strzalow
figure;
area_100_shots = monte_carlo_area(x, y, y2, 100);
xlabel('x');
ylabel('y');
title('Metoda Monte Carlo - 100 strzałów');
fprintf('Przybliżone pole powierzchni dla 100 strzałów: %f\n', area_100_shots);

% 500 strzalow
figure;
area_500_shots = monte_carlo_area_dwa(x, y, y2, 500);
xlabel('x');
ylabel('y');
title('Metoda Monte Carlo - 500 strzałów');
fprintf('Przybliżone pole powierzchni dla 500 strzałów: %f\n', area_500_shots);
