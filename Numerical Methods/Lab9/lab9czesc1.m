clc;
close all;
clear all;

f1 = @(x1, x2) x1.^2 + x2.^2;
f2 = @(x1, x2) 2*x1.^2 + 4*x2.^2 - 2*x1.*x2 + 4*x1 + 2*x2 - 6;



alphaValues = [0.01, 0.1, 1];

for wybor = 1:2
for alpha = alphaValues
    if wybor == 1
        f = f1;
        x1p = -10; x1k = 10;
        x2p = -10; x2k = 10;
        xpocz = 5; ypocz = -5;
        funcName = 'f(x1,x2) = x1^2 + x2^2';
    else
        f = f2;
        x1p = -8; x1k = 6;
        x2p = -6; x2k = 5;
        xpocz = -5; ypocz = 3; % Zmieniony punkt startowy dla funkcji 2
        funcName = 'f(x1,x2) = 2x1^2 + 4x2^2 - 2x1x2 + 4x1 + 2x2 - 6';
    end

    tic;
    [x1, y2, it, dx1, dx2] = swwzmodyfikowane(f, xpocz, ypocz, alpha, 1e-4, x1p, x1k, x2p, x2k);
    elapsedTime = toc;

    fprintf('Funkcja %d, alfa = %f, Punkt startowy: (%f, %f)\n', wybor, alpha, xpocz, ypocz);
    fprintf('Punkt minimum: (%f, %f), f(Pmin) = %f, Iteracje: %d, Czas: %f s\n\n', x1, y2, f(x1, y2), it, elapsedTime);

figure;
subplot(2, 1, 1);
[x, y] = meshgrid(x1p:0.1:x1k, x2p:0.1:x2k);
mesh(x, y, f(x, y));
hold on;
plot3(x1, y2, f(x1, y2), 'r*', 'MarkerSize', 10);
title(sprintf('Wykres 3D - %s, alfa = %f', funcName, alpha));

subplot(2, 1, 2);
z = f(x, y);
[c, h] = contour(x, y, z);
clabel(c, h);
hold on;
plot(xpocz, ypocz, 'bo', 'MarkerSize', 10, 'MarkerFaceColor', 'b');
text(xpocz, ypocz, ' Start', 'VerticalAlignment', 'bottom', 'HorizontalAlignment', 'right');
plot(x1, y2, 'r*', 'MarkerSize', 10);
text(x1, y2, ' Min', 'VerticalAlignment', 'top', 'HorizontalAlignment', 'left');
title(sprintf('Wykres poziomicowy - %s, alfa = %f, f(Pmin) = %f', funcName, alpha, f(x1, y2)));

for i = 1:length(dx1)-1
    line([dx1(i), dx1(i+1)], [dx2(i), dx2(i+1)], 'Color', 'k', 'LineWidth', 1);
end
end
end

%funkcja
function [x1, x2, it, dx1, dx2] = sww(f, xpocz, ypocz, krok, eps, x1p, x1k, x2p, x2k)
x1 = xpocz;
x2 = ypocz;
dx1 = xpocz;
dx2 = ypocz;
it = 0;
min1 = krok^2;
while (min1 > (0.5*krok^2) && min1 > eps)
it = it + 1; 
wersor = [ f(x1, x2), f(x1 + krok, x2), f(x1, x2 + krok), f(x1 - krok, x2), f(x1, x2 - krok) ];

[~, minWersor] = min(wersor); 

if minWersor == 2 
    x1 = x1 + krok;

elseif minWersor == 3 
    x2 = x2 + krok;

elseif minWersor == 4 
    x1 = x1 - krok;

elseif minWersor == 5 
    x2 = x2 - krok;
end

dx1 = [dx1, x1]; 
dx2 = [dx2, x2];

min1 = min((dx1(end)-dx1(1:(end-1))).^2 + (dx2(end)-dx2(1:(end-1))).^2);
end
end



