% Zad1 Nearest
clc;
close all;

x = 0.5:16.5;
y = [4, 5.3, 6, 6.5, 6.8, 7, 7, 7, 7.5, 6.5, 5.6, 5.2, 4.8, 4.6, 4.8, 6.5, 4];

x2 = 0.5:16.5;
y2 = [4, 3, 2.6, 1.5, 1, 1.9, 1.8, 1.8, 1.9, 2, 2.2, 2.5, 3, 3.5, 3.4, 2, 4];

xInterp = 0.5:0.1:16.5;

interp1_y = interp1(x, y, xInterp, 'nearest');
interp1_y2 = interp1(x2, y2, xInterp, 'nearest');

plot(xInterp, interp1_y, 'b');
hold on;
scatter(x, y, 'r');

plot(xInterp, interp1_y2, 'b');
scatter(x2, y2, 'r');
hold off;

legend('Interpolacja nearest', 'Punkty');
xlabel('x');
ylabel('y');
title('Interpolacja nearest');
