% metody c i d
clc;
close all;
f1 = @(x) x.^3 - x - 2;
f2 = @(x) sin(x) - 0.5;

a1 = -2; b1 = 2; %przedział
a2 = 0; b2 = 2;

tol = 1e-5;
ftol = 1e-4;

[x_s1, n_s1, czas_s1] = sieczne(f1, a1, b1, ftol, tol);
[x_n1, n_n1, czas_n1] = newton(f1, a1, b1, tol, ftol);
[x_s2, n_s2, czas_s2] = sieczne(f2, a2, b2, ftol, tol);
[x_n2, n_n2, czas_n2] = newton(f2, a2, b2, tol, ftol);

% output
fprintf('Funkcja f1(x):\n');
fprintf('Metoda siecznych: x = %.6f, iteracje = %d, czas = %.6fs\n', x_s1, n_s1, czas_s1);
fprintf('Metoda Newtona: x = %.6f, iteracje = %d, czas = %.6fs\n', x_n1, n_n1, czas_n1);
fprintf('\nFunkcja f2(x):\n');
fprintf('Metoda siecznych: x = %.6f, iteracje = %d, czas = %.6fs\n', x_s2, n_s2, czas_s2);
fprintf('Metoda Newtona: x = %.6f, iteracje = %d, czas = %.6fs\n', x_n2, n_n2, czas_n2);
% wykresy
x_range = linspace(-3, 3, 400);
plot(x_range, f1(x_range));
hold on;
scatter(x_s1, f1(x_s1), 'r');
scatter(x_n1, f1(x_n1), 'g');
title('Wykres funkcji f1(x)');
xlabel('x'); ylabel('f1(x)');
legend('f1(x)', 'Sieczne', 'Newton');
hold off;

figure;
x_range2 = linspace(-2, 4, 400);
plot(x_range2, f2(x_range2));
hold on;
scatter(x_s2, f2(x_s2), 'r');
scatter(x_n2, f2(x_n2), 'g');
title('Wykres funkcji f2(x)');
xlabel('x'); ylabel('f2(x)');
legend('f2(x)', 'Sieczne', 'Newton');
hold off;
